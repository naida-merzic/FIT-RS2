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
using System.Data;
using System.Reflection;

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
        static ITransformer modeltr = null;
        
        public List<Model.Artikal> Recommend(int id)
        {
            
                mlContext = new MLContext();

                var tmpData = Context.Racuns.Include("StavkaRacunas").ToList();

                var data = new List<RatingEntry>();

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
                                data.Add(new RatingEntry()
                                {
                                    RatingId = (uint)y,
                                    CoRatingId = (uint)z.ArtikalId,
                                });
                            }
                        });
                    }
                };

                DataTable dataTable = new DataTable(typeof(RatingEntry).Name);

                PropertyInfo[] Props = typeof(RatingEntry).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (var item in data)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                if(dataTable.Rows.Count == 0)
                    return null;
                string myTableAsString =
                String.Join(Environment.NewLine, dataTable.Rows.Cast<DataRow>().
                    Select(r => r.ItemArray).ToArray().
                    Select(x => String.Join("\t", x.Cast<string>())));

                /* StreamWriter myFile = new StreamWriter("fileName.txt");
                 myFile.WriteLine(myFile);
                 myFile.Close();*/
                File.WriteAllTextAsync("img/WriteText.txt", myTableAsString);


                var putanja1 = System.Environment.CurrentDirectory + @"\img\" + "WriteText.txt";
            if (putanja1 == null)
                throw new Exception("Nema putanje");

                //var traindata = mlContext.Data.LoadFromTextFile(path: putanja1, columns: new[]
                //                                                {
                //                                                    new TextLoader.Column("Label", DataKind.Single, 0),
                //                                                    new TextLoader.Column(name:nameof(RatingEntry.RatingId), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(0) }, keyCount: new KeyCount(262111)),
                //                                                    new TextLoader.Column(name:nameof(RatingEntry.CoRatingId), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(1) }, keyCount: new KeyCount(262111))
                //                                                },
                //                                      hasHeader: true,
                //                                      separatorChar: '\t');
                var traindata = mlContext.Data.LoadFromEnumerable(data);
                //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer. 
                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(RatingEntry.RatingId);
                options.MatrixRowIndexColumnName = nameof(RatingEntry.CoRatingId);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                // For better results use the following parameters
                //options.K = 100;
                //options.C = 0.00001;
                //Step 4: Call the MatrixFactorization trainer by passing options.
                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                //STEP 5: Train the model fitting to the DataSet
                //Please add Amazon0302.txt dataset from https://snap.stanford.edu/data/amazon0302.html to Data folder if FileNotFoundException is thrown.
                modeltr = est.Fit(traindata);


                var allItems = Context.Artikals.Where(x => x.ArtikalId != id);


                var predictionResult = new List<Tuple<Database.Artikal, float>>();

                foreach (var item in allItems)
                {
                    var predictionEngine = mlContext.Model.CreatePredictionEngine<RatingEntry, Copurchase_prediction>(modeltr);
                    var prediction = predictionEngine.Predict(new RatingEntry()
                    {
                        RatingId = (uint)id,
                        CoRatingId = (uint)item.ArtikalId
                    });

                    predictionResult.Add(new Tuple<Database.Artikal, float>(item, prediction.Score));
                }
                var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();
            
            if(finalResult!=null)
                return Mapper.Map<List<Model.Artikal>>(finalResult);
            return null;


        }
    }
    public class CoRating_prediction
    {
        public float Score { get; set; }
    }
    public class RatingEntry
    {
        [KeyType(count: 262111)]
        public uint RatingId { get; set; }
        [KeyType(count: 262111)]
        public uint CoRatingId { get; set; }
        public float Label { get; set; }

    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }
}
    //public class Copurchase_prediction
    //{
    //    public float Score { get; set; }
    //}

    //public class ProductEntry
    //{
    //    [KeyType(count: 10)]
    //    public uint ProductID { get; set; }

    //    [KeyType(count: 10)]
    //    public uint CoPurchaseProductID { get; set; }

    //    public float Label { get; set; }
    //}

