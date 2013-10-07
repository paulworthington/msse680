using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using DAL;

namespace Presentation
{
    public partial class ItemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // instantiate an Item object
            // populate the Item object from the text boxes
            // instantiate an ItemManager object
            // call the ItemManager's Insert method and pass the Item

            Item myItem = new Item();

            myItem.name = this.TextBox1.Text;
            myItem.type = this.DropDownList1.SelectedIndex;
            myItem.firstMentionBook = this.DropDownList2.SelectedIndex;
            myItem.firstMentionChapter = Convert.ToInt32(this.TextBox4.Text);

            ItemMgr itemManager = new ItemMgr();
            itemManager.Insert(myItem);
        }

    }
}
