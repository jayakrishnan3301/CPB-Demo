using CPB.Core.Facades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Repository
{
    internal class DAL : BaseDAL, IDAL
    {
        public DAL(string connectionName) : base(connectionName)
        {
            //user interface
        }

        //user interface

        public class DALFactory:IDALFactory
        {
            public IDAL Create()
            {
                return new DAL("Slot_BookingEntities");
            }
        }
    }

}
