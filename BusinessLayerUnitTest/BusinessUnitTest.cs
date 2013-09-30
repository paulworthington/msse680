using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;
using Business;

namespace BusinessLayerUnitTest
{
    [TestClass]
    public class BusinessUnitTest
    {
        [TestMethod]
        public void AddItemByManager()
        {
            // instantiate an Item
            // instantiate an ItemMgr
            // use the ItemMgr to add the Item to the table

            Item myItem = new Item();
            myItem.name = "half-coin";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 28;

            ItemMgr myItemMgr = new ItemMgr();
            myItemMgr.Insert(myItem);
        }

        [TestMethod]
        public void AddItemDescriptionByManager()
        {
            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "The Pearl River forms one of the boundaries between Louisiana and Mississippi.";
            myDesc.ItemID = null;

            ItemDescriptionMgr myItemDescMgr = new ItemDescriptionMgr();
            myItemDescMgr.Insert(myDesc);
        }

        [TestMethod]
        public void DeleteItemByManager()
        {
            // create an item I want to delete
            Item myItem = new Item();
            myItem.name = "Pearl River";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 13;

            // create an ItemMgr and add the Item
            ItemMgr myItemMgr = new ItemMgr();
            myItemMgr.Insert(myItem);

            // delete that item
            myItemMgr.Delete(myItem);
        }

        // get item by key via the ItemMgr, using string name and string value
        [TestMethod]
        public void GetItemByKeyWithItemMgr()
        {
            String searchName = "name";

            // this is the key value used on insert and again on get
            String searchValue = "Bart Simpson";

            // first add an item I want to be able to get
            Item myItem = new Item();
            myItem.name = searchValue;
            myItem.type = 0;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 0;

            // create an ItemMgr and add the Item
            ItemMgr myItemMgr = new ItemMgr();
            myItemMgr.Insert(myItem);

            // use the same key to search
            IQueryable<Item> resultItem = myItemMgr.GetItem(searchName, searchValue);

            // result will be not null if I found a record with the given search value
            Assert.IsNotNull(resultItem);
        }

        // add a description to an item
        [TestMethod]
        public void AddItemDescToItemByManager()
        {
            // this business layer component uses the service factory to create an ItemDescriptionSvc

            // create an item
            Item myItem = new Item();
            myItem.name = "Pearl River";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 13;

            // create an ItemMgr and add the Item
            ItemMgr myItemMgr = new ItemMgr();
            myItemMgr.Insert(myItem);

            // create an item description
            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "The Pearl River forms one of the boundaries between Louisiana and Mississippi.";
            myDesc.ItemID = null;

            // create an ItemDescriptionMgr and add the ItemDescription
            ItemDescriptionMgr myItemDescMgr = new ItemDescriptionMgr();
            myItemDescMgr.Insert(myDesc);

            // add the description to the item using the ItemDescriptionMgr
            myItemDescMgr.addDescToItem(myDesc, myItem);
        }


    }
}
