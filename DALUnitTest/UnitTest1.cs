using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using DAL;

namespace DALUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddItem()
        {
            worthingtonEntities db = new worthingtonEntities();

            Item myItem = new Item();

            myItem.name = "Travis Wilder";
            myItem.type = 0;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 0;

            db.Items.Add(myItem);
            db.SaveChanges();

            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "Travis Wilder is the owner of the Mine Shaft Saloon in Castle City, Colorado. He is tall, lean, and 33 years old. Travis has a beard, pale blond hair, and he wears wire-rimmed glasses.";
            myDesc.ItemID = myItem.ItemID;

            db.ItemDescriptions.Add(myDesc);
            db.SaveChanges();
        }

        [TestMethod]
        public void DeleteItem()
        {
            worthingtonEntities db = new worthingtonEntities();

            Item myItem = new Item();

            // first add an item I want to delete
            myItem.name = "Colfax Avenue";
            myItem.type = 1;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 18;

            db.Items.Add(myItem);
            db.SaveChanges();

            Item deleteItem = (from d in db.Items where d.name == "Colfax Avenue" select d).Single();
            db.Items.Remove(deleteItem);
            db.SaveChanges();
        }

        // run this one last, so there is a record to select
        [TestMethod]
        public void TestMethod1()
        {
            // database context
            worthingtonEntities db = new worthingtonEntities();

            // act -- go get the first record
            Item savedItem = (from d in db.Items where d.ItemID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedItem.ItemID, 1);
        }

        // test create and insert ItemInventory
        [TestMethod]
        public void AddInventory()
        {
            worthingtonEntities db = new worthingtonEntities();

            ItemInventory myItemInv = new ItemInventory();
            myItemInv.ItemID = 1;

            db.ItemInventories.Add(myItemInv);
            db.SaveChanges();
        }

        // test create and insert a Book
        [TestMethod]
        public void AddBook()
        {
            worthingtonEntities db = new worthingtonEntities();

            Book myBook = new Book();
            myBook.number = 0;
            myBook.title = "Beyond The Pale";

            db.Books.Add(myBook);
            db.SaveChanges();
        }

        // test create and insert an ItemType
        [TestMethod]
        public void AddItemType()
        {
            worthingtonEntities db = new worthingtonEntities();

            ItemType myItemType = new ItemType();
            myItemType.ItemType1 = 5;

            db.ItemTypes.Add(myItemType);
            db.SaveChanges();
        }

        // test create and insert a SpoilerFilter
        [TestMethod]
        public void AddSpoilerFilter()
        {
            worthingtonEntities db = new worthingtonEntities();

            SpoilerFilter mySpoilerFilter = new SpoilerFilter();
            mySpoilerFilter.latestRead = 1;

            db.SpoilerFilters.Add(mySpoilerFilter);
            db.SaveChanges();
        }

        // use repository to insert an item
        [TestMethod]
        public void InsertItemWithRepo()
        {
            var itemRepository = new GenericRepository<Item>();

            Item myItem = new Item();
            myItem.name = "half-coin";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 28;

            itemRepository.Insert(myItem);
        }

        // use repository to insert an item description
        [TestMethod]
        public void InsertItemDescWithRepo()
        {
            var itemDescRepository = new GenericRepository<ItemDescription>();

            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "The half-coin given to Grace Beckett by Brother Cy enables her to understand languages other than English.";
            myDesc.ItemID = 1;

            itemDescRepository.Insert(myDesc);
        }

        // use repository to get all items from the database
        [TestMethod]
        public void GetAllFromRepo()
        {
            var itemRepo = new GenericRepository<Item>();

            List<Item> myList = itemRepo.GetAll().ToList<Item>();
            Assert.IsTrue(myList.Count > 0);
        }

        // use repository to delete an item
        [TestMethod]
        public void DeleteItemWithRepo()
        {
            var itemRepository = new GenericRepository<Item>();

            // first add an item I want to delete
            Item myItem = new Item();
            myItem.name = "Pearl River";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 13;

            itemRepository.Insert(myItem);

            // now delete that item
            itemRepository.Delete(myItem);
        }

        // get item from repository by key, using string name and string value
        [TestMethod]
        public void GetItemByKeyWithRepo()
        {
            var itemRepository = new GenericRepository<Item>();

            String searchName = "name";

            // this is the key value used on insert and again on get
            String searchValue = "Bart Simpson";

            // first add an item I want to be able to get
            Item myItem = new Item();
            myItem.name = searchValue;
            myItem.type = 0;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 0;
            itemRepository.Insert(myItem);

            // use the same key to search
            List<Item> resultList = itemRepository.GetByKey(searchName, searchValue).ToList<Item>();

            // list will have more than zero items if I found a record with the given search value
            Assert.IsTrue(resultList.Count > 0);
        }

        // get an item description from repository by key, using string name and int value
        [TestMethod]
        public void GetItemByKeyIntWithRepo()
        {
            var itemDescRepo = new GenericRepository<ItemDescription>();

            String searchName = "bookNumber";

            // this is the key value used on insert and again on get
            int searchValue = 0;

            // first add an item description I want to be able to get
            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "The half-coin given to Grace Beckett by Brother Cy enables her to understand languages other than English.";
            myDesc.ItemID = 1;
            itemDescRepo.Insert(myDesc);

            // use the same key to search
            List<ItemDescription> resultList = itemDescRepo.GetByKey(searchName, searchValue).ToList<ItemDescription>();

            // list will have more than zero items if I found a record with the given search value
            Assert.IsTrue(resultList.Count > 0);
        }

        // use repository to update an item description
        [TestMethod]
        public void UpdateItemDescWithRepo()
        {
            var itemDescRepo = new GenericRepository<ItemDescription>();

            // first add an item description that I will later update
            ItemDescription myDesc = new ItemDescription();
            myDesc.bookNumber = 0;
            myDesc.description = "This is wrong.";
            myDesc.ItemID = 1;
            itemDescRepo.Insert(myDesc);

            // change the description string and then update
            myDesc.description = "This is right.";
            itemDescRepo.Update(myDesc);
        }


    }
}
