using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Core.Facades
{
    public interface IDAL : IBaseDAL, IDisposable
    {
        //INterface
    }
    public interface IDALFactory 
    { 
        IDAL Create();
    }

}
