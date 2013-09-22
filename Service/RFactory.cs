using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace Service
{

    // sample code
    public class RFactory
    {
        public IGenericRepository GetRepository(string sRepositoryType)
        {
            IGenericRepository objRepo;
            switch (sRepositoryType)
            {
                case "Item":
                    objRepo = new GenericRepository<Item>();
                    break;
                case "ItemDescription":
                    objRepo = new GenericRepository<ItemDescription>();
                    break;
                default:
                    objRepo = null;
                    throw new System.ArgumentException("Unimplemented Repository type " + sRepositoryType);
            }
            return objRepo;
        }
    }



}
