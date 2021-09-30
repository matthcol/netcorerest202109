using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace WineApiRest.Services
{
    public interface IWineService
    {
        Task<Wine> GetWine(uint id);
    }
}
