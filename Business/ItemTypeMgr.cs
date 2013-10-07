using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Service;

namespace Business
{
    public class ItemTypeMgr : Manager
    {
        IGenericRepository<ItemType> itemTypeRepository = (IGenericRepository<ItemType>)repoFactory.getRepository("ItemType");

        public void Insert(ItemType itemType)
        {
            itemTypeRepository.Insert(itemType);
        }

        public void Delete(ItemType itemType)
        {
            itemTypeRepository.Delete(itemType);
        }

        public void Update(ItemType itemType)
        {
            itemTypeRepository.Update(itemType);
        }

        public IQueryable<ItemType> GetAll()
        {
            return (itemTypeRepository.GetAll().OfType<ItemType>());
        }

        public IQueryable<ItemType> GetItem(String keyName, String keyValue)
        {
            return (itemTypeRepository.GetByKey(keyName, keyValue).OfType<ItemType>());
        }

    }
}