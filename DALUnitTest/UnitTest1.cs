using System;
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

    }
}
