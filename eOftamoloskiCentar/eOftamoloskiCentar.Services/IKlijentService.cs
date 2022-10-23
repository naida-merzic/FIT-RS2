using eOftamoloskiCentar.Model.Requests;
using eOftamoloskiCentar.Model.SearchObjects;
using eOftamoloskiCentar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public interface IKlijentService : ICRUDService<Klijent, KlijentSearchObject, KlijentInsertRequest, KlijentUpdateRequest>
    {
        public Klijent Login(AuthenticationRequest request);
    }
}
