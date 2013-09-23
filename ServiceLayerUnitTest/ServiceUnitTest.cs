using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;

namespace ServiceLayerUnitTest
{
    [TestClass]
    public class ServiceUnitTest
    {

        [TestMethod]
        public void UseRepositoryFactoryToAddItem()
        {
            /*
             * Create an RFactory object
             * Use the factory to create an Item repository object
             * Create an Item object
             * Use the Item repository to add the Item
             */

            RFactory myFactory = new RFactory();
            var itemRepository = myFactory.getRepository("Item");

            Item myItem = new Item();
            myItem.name = "half-coin";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 28;

            itemRepository.Insert(myItem);
        }

        [TestMethod]
        public void UseServiceFactoryToAddItem()
        {
            /*
             * Create an SFactory object
             * Use the factory to create an Item service object
             * Create an Item object
             * Use the Item service object to add the Item
             */

            SFactory myFactory = new SFactory();
            IItemSvc myItemService = (IItemSvc)myFactory.getService("Item");

            Item myItem = new Item();
            myItem.name = "half-coin";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 28;

            myItemService.addItem(myItem);
        }

        [TestMethod]
        public void UseItemServiceToDeleteItem()
        {
            /*
             * No Service Factory in this test
             */

            IItemSvc myItemService = new ItemSvcImpl();

            // add an item I want to delete
            Item myItem = new Item();
            myItem.name = "Pearl River";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 13;

            myItemService.addItem(myItem);

            // delete that item
            myItemService.deleteItem(myItem);
        }

        // get item by key from Item Service, using string name and string value
        [TestMethod]
        public void GetItemByKeyWithItemService()
        {
            IItemSvc myItemService = new ItemSvcImpl();

            String searchName = "name";

            // this is the key value used on insert and again on get
            String searchValue = "Bart Simpson";

            // first add an item I want to be able to get
            Item myItem = new Item();
            myItem.name = searchValue;
            myItem.type = 0;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 0;
            myItemService.addItem(myItem);

            // use the same key to search
            Item resultItem = myItemService.getItem(searchName, searchValue);

            // result will be not null if I found a record with the given search value
            Assert.IsNotNull(resultItem);
        }

        // add a description to an item
        [TestMethod]
        public void AddItemDescriptionToItem()
        {
            /*
             * Create a Service Factory
             * Use the factory to create an Item Service and an Item Description Service
             * Create an Item
             * Add the Item
             * Create an Item Description
             * Add the Item Description
             * Add the description to the item
             */

            SFactory myFactory = new SFactory();
            IItemSvc myItemService = (IItemSvc)myFactory.getService("Item");
            IItemDescriptionSvc myItemDescriptionService = (IItemDescriptionSvc)myFactory.getService("ItemDescription");

            // add an item
            Item myItem = new Item();
            myItem.name = "Pearl River";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 13;
            myItemService.addItem(myItem);

            // add an item description
            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "The Pearl River forms one of the boundaries between Louisiana and Mississippi.";
            myDesc.ItemID = null;
            myItemDescriptionService.addItemDescription(myDesc);
            
            // add the description to the item
            myItemDescriptionService.addDescriptionToItem(myDesc, myItem);
        }

    }
}
