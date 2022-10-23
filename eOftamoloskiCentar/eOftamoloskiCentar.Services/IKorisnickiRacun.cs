using eOftamoloskiCentar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.Services
{
    public interface IKorisnickiRacun
    {
        Model.AuthKorisnickiRacun Login(AuthenticationRequest request);
    }
}
