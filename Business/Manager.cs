using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Service;

namespace Business
{
    public abstract class Manager
    {
        protected static RFactory repoFactory = RFactory.GetInstance();
        protected static SFactory svcFactory = SFactory.GetInstance();

        protected static IService getService(String name)
        {
            return svcFactory.getService(name);
        }
    }
}
