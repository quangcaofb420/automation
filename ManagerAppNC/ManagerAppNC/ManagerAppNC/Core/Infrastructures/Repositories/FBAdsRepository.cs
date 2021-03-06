using ManagerAppNC.Core.Repositories;
using ManagerAppNC.Core.Repositories.Sdo;
using System.Collections.Generic;

namespace ManagerAppNC.Core.Infrastructures
{
    class FBAdsRepository : IFBAdsRepository
    {
        public List<FBAccSdo> GetFBAccList()
        {
            List<FBAccSdo> list = new List<FBAccSdo>();
            list.Add(new FBAccSdo() { Username = "User name test", Password = "Password test", Phoone = "Phone test" });
            return list;
        }
    }
}
