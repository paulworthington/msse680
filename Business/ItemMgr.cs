using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Service;

namespace Business
{
    public class ItemMgr : Manager
    {
        IGenericRepository<Item> itemRepository = (IGenericRepository<Item>)repoFactory.getRepository("Item");

        public void Insert(Item item)
        {
            itemRepository.Insert(item);
        }

        public void Delete(Item item)
        {
            itemRepository.Delete(item);
        }

        public void Update(Item item)
        {
            itemRepository.Update(item);
        }

        public IQueryable<Item> GetAll()
        {
            return (itemRepository.GetAll().OfType<Item>());
        }

        public IQueryable<Item> GetItem(String keyName, String keyValue)
        {
            return (itemRepository.GetByKey(keyName, keyValue).OfType<Item>());
        }

    }
}