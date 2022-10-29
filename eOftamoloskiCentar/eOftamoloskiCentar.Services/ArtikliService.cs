using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.ArtikalStateMachine;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.EntityFrameworkCore;

namespace eOftamoloskiCentar.Services 
{
    public class ArtikliService : BaseCRUDService<Model.Artikal, Database.Artikal, ArtikalSearchObject, ArtikalInsertRequest, ArtikalUpdateRequest>, IArtikliService
    {
        public BaseState BaseState { get; set; }
        public ArtikliService(OftamoloskiCentarContext context, IMapper mapper, BaseState baseState)
            : base(context, mapper)
        {
            BaseState = baseState;
        }
        public override Model.Artikal Insert(ArtikalInsertRequest insert)
        {
            //return base.Insert(insert);
            var state = BaseState.CreateState("initial");

            return state.Insert(insert);
            
        }

        public override Model.Artikal Update(int id, ArtikalUpdateRequest update)
        {
            var product = Context.Artikals.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Update(update);

            return GetById(id);
        }
        //PAZITI I OGRANICITI DA NE MOZE IZBRISATI ARTIKAL KOJI JE VEC NA RACUNU STAVKA RACUNA
        public override Model.Artikal Delete(int id)
        {
            foreach (var item in Context.StavkaRacunas)
            {
                if(id==item.ArtikalId)
                {
                  Context.StavkaRacunas.Remove(item);
                }
            }
            
            var entity = Context.Artikals.Find(id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            Context.Artikals.Remove(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Artikal>(x);
        }
        public Model.Artikal Activate(int id)
        {
            var product = Context.Artikals.Find(id);
            //return base.Update(id, update);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;

            state.Activate();

            return GetById(id);
        }
        public List<string> AllowedActions(int id)
        {
            var product = GetById(id);
            var state = BaseState.CreateState(product.StateMachine);

            return state.AllowedActions();
        }

        //public override IEnumerable<Model.Artikal> Get(ArtikalSearchObject search = null)
        //{
        //    return base.Get(search);
        //}

        public override IQueryable<Database.Artikal> AddInclude(IQueryable<Database.Artikal> query, ArtikalSearchObject search = null)
        {
            //if (search?.IncludeRoles == true)
            //{
            query = query.Include(x => x.VrstaArtikla).AsQueryable();
            //}
            return query;
        }

        public override IQueryable<Database.Artikal> AddFilter(IQueryable<Database.Artikal>query, ArtikalSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.Naziv));
            }
            return filteredQuery;
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        
        public List<Model.Artikal> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = Context.Racuns.Include("StavkaRacunas").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.StavkaRacunas.Count > 1)
                        {
                            var distinctItemId = x.StavkaRacunas.Select(y => y.ArtikalId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.StavkaRacunas.Where(z => z.ArtikalId != y).ToList();

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.ArtikalId,
                                    });
                                }
                            });
                        }
                    }

                    var traindata = mlContext.Data.LoadFromEnumerable(data);


                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;

                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);
                    IDataView  _traindata = traindata;
                    model = est.Fit(_traindata);
                }
            }

            var allItems = Context.Artikals.Where(x => x.ArtikalId != id);


            var predictionResult = new List<Tuple<Database.Artikal, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.ArtikalId
                });

                predictionResult.Add(new Tuple<Database.Artikal, float>(item, prediction.Score));
            }
            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();

            return Mapper.Map<List<Model.Artikal>>(finalResult);
        }


    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
