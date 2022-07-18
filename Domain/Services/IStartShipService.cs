using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IStartShipService
    {
        Task<IEnumerable<BasicStarShipModel>> GetStarShipInfo(int? page = null, int? limit = null);
        Task<StarShipModel> GetStarShipInfoById(string id);
    }
}
