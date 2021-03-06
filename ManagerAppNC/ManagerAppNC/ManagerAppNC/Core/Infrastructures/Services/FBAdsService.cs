using ManagerAppNC.Core.Services;
using ManagerAppNC.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAppNC.Core.Infrastructures.Services
{
    class FBAdsService : IFBAdsService
    {
        async Task<List<FBAcc>> IFBAdsService.GetFBAccList()
        {
            List<FBAcc> list = new List<FBAcc>();
            list.Add(new FBAcc() { Username="User name test", Password = "Password test", Phoone = "Phone test"});
            return list;
        }
    }
}
