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

        public void Insert(Item item)
        {
            var itemRepo = repoFactory.getRepository("Item");
            itemRepo.Insert(item);
        }

        public void Delete(Item item)
        {
            var itemRepo = repoFactory.getRepository("Item");
            itemRepo.Delete(item);
        }

        public void Update(Item item)
        {
            var itemRepo = repoFactory.getRepository("Item");
            itemRepo.Update(item);
        }

        public IQueryable<Item> GetAll()
        {
            var itemRepo = repoFactory.getRepository("Item");
            return (itemRepo.GetAll().OfType<Item>());
        }

        public IQueryable<Item> GetItem(String keyName, String keyValue)
        {
            var itemRepo = repoFactory.getRepository("Item");
            return (itemRepo.GetByKey(keyName, keyValue).OfType<Item>());
        }

    }
}