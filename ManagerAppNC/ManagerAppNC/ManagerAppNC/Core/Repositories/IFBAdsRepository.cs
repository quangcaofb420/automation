using ManagerAppNC.Core.Repositories.Sdo;
using System.Collections.Generic;

namespace ManagerAppNC.Core.Repositories
{
    interface IFBAdsRepository
    {
        List<FBAccSdo> GetFBAccList();
    }
}
