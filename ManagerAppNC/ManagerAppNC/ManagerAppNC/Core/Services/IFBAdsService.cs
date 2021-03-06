using ManagerAppNC.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAppNC.Core.Services
{
    interface IFBAdsService
    {
        Task<List<FBAcc>> GetFBAccList();
    }
}
