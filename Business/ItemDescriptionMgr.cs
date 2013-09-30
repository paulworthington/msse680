using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Service;

namespace Business
{
    public class ItemDescriptionMgr : Manager
    {
        IGenericRepository<ItemDescription> itemDescRepository = (IGenericRepository<ItemDescription>)repoFactory.getRepository("ItemDescription");
        IItemDescriptionSvc itemDescSvc = (IItemDescriptionSvc)getService("ItemDescription");

        // add an item description
        public void Insert(ItemDescription itemDesc)
        {
            itemDescRepository.Insert(itemDesc);
        }

        public void Delete(ItemDescription itemDesc)
        {
            itemDescRepository.Delete(itemDesc);
        }

        public void Update(ItemDescription itemDesc)
        {
            itemDescRepository.Update(itemDesc);
        }

        public IQueryable<ItemDescription> GetAll()
        {
            return (itemDescRepository.GetAll().OfType<ItemDescription>());
        }

        public IQueryable<ItemDescription> GetItemDesc(String keyName, String keyValue)
        {
            return (itemDescRepository.GetByKey(keyName, keyValue).OfType<ItemDescription>());
        }

        public void addDescToItem(ItemDescription myDesc, Item myItem)
        {
            itemDescSvc.addDescriptionToItem(myDesc, myItem);
        }
    }
}
