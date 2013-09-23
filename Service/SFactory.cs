using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public class SFactory
    {
        public IService getService(String serviceName)
        {
            IService serviceInstance = null;

            switch (serviceName)
            {
                case "Item":
                    serviceInstance = (IService)new ItemSvcImpl();
                    break;
                case "ItemDescription":
                    serviceInstance = (IService)new ItemDescriptionSvcImpl();
                    break;
                default:
                    throw new System.ArgumentException("Unimplemented Service type: " + serviceName);
            }
            return serviceInstance;
        }
    }
}