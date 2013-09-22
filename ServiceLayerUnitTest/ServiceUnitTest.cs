using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
//using System.Data;
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
            var itemRepository = myFactory.GetRepository("Item");

            Item myItem = new Item();
            myItem.name = "half-coin";
            myItem.type = 2;
            myItem.firstMentionBook = 0;
            myItem.firstMentionChapter = 28;

            itemRepository.Insert(myItem);

        }
    }
}
