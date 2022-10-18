using AutoMapper;
using eOftamoloskiCentar.Model;
using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public class SpolService : BaseCRUDService<Model.Spol, Database.Spol, SpolSearchObject, SpolUpsertRequest, SpolUpsertRequest>, ISpolService
    {
        public SpolService(OftamoloskiCentarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
