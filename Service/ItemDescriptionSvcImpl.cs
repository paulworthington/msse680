using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public class ItemDescriptionSvcImpl : IItemDescriptionSvc
    {
        // class data members
        public GenericRepository<ItemDescription> itemDescriptionRepository;

        // constructor
        public ItemDescriptionSvcImpl()
        {
            itemDescriptionRepository = new GenericRepository<ItemDescription>();
        }

        // methods
        public void addItemDescription(ItemDescription myItemDesc)
        {
            itemDescriptionRepository.Insert(myItemDesc);
        }

        public void deleteItemDescription(ItemDescription myItemDesc)
        {
            itemDescriptionRepository.Delete(myItemDesc);
        }

        public List<ItemDescription> getAllItemDescriptions()
        {
            return itemDescriptionRepository.GetAll().ToList<ItemDescription>();
        }

        public void updateItemDescription(ItemDescription myItemDesc)
        {
            itemDescriptionRepository.Update(myItemDesc);
        }

        public ItemDescription getItemDescription(String keyName, String keyValue)
        {
            return itemDescriptionRepository.GetByKey(keyName, keyValue).FirstOrDefault<ItemDescription>();
        }

        public ItemDescription getItemDescription(String keyName, int keyValue)
        {
            return itemDescriptionRepository.GetByKey(keyName, keyValue).FirstOrDefault<ItemDescription>();
        }

        public void addDescriptionToItem(ItemDescription myItemDesc, Item myItem)
        {
            /*
             * Multiple ItemDescription records can have the same ItemID.
             * One Item will have multiple ItemDescriptions.
             * Each ItemDescription is related to its Item by its ItemID field.
             * Therefore, to "add a description to an Item" means to add the
             * Item's ID to the ItemDescription.
             */
            myItemDesc.ItemID = myItem.ItemID;
            /*
             * Now the Item and ItemDescription are related to each other.
             * Update the ItemDescription via the itemDescriptionRepository.
             */
            updateItemDescription(myItemDesc);
        }

        public void deleteDescriptionFromItem(ItemDescription myItemDesc, Item myItem)
        {
            myItemDesc.ItemID = null;
            updateItemDescription(myItemDesc);
        }
    }
}

