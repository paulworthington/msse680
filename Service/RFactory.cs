using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public class RFactory
    {
        private static RFactory repoFactory = new RFactory();
        public static RFactory GetInstance()
        {
            return repoFactory;
        }

        public IGenericRepository getRepository(string repositoryName)
        {
            IGenericRepository repositoryInstance;
            switch (repositoryName)
            {
                case "Item":
                    repositoryInstance = new GenericRepository<Item>();
                    break;
                case "ItemDescription":
                    repositoryInstance = new GenericRepository<ItemDescription>();
                    break;
                default:
                    repositoryInstance = null;
                    throw new System.ArgumentException("Unimplemented Repository type: " + repositoryName);
            }
            return repositoryInstance;
        }
    }



}
