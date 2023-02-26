using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class DBProvider
    {
        private static DBProvider _Instance;
        public static DBProvider Instance { get { if (Instance == null) Instance = new DBProvider(); return Instance; } set { Instance = value; } }
        public FStoreContext DBContext { get; set; }
        private DBProvider()
        {
            DBContext = new FStoreContext();
        }
    }
}
