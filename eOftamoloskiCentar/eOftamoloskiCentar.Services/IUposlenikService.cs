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
    public interface IUposlenikService : ICRUDService<Uposlenik, UposlenikSearchObject, KorisnickiRacunInsertRequest, KorisnickiRacunInsertRequest>
    {
        //Model.Uposlenik Login(string username, string password);
    }
}
