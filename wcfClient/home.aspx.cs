using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace wcfClient
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sr.IService1 si = new sr.Service1Client();
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(si.GetData(9));
            xmlDoc.LoadXml(si.GetData(9));


            string xpath = "bookstore/book";
            //XmlNodeList parentNode = xmlDoc.GetElementsByTagName("bookstore");


            var nodes = xmlDoc.SelectNodes(xpath);

            List<Panel> pl_container = new List<Panel>();



            foreach (XmlNode cn in nodes)
            {
                Panel pl = new Panel();

                Label lbTitle = new Label();
                lbTitle.Text = cn.ChildNodes[0].Name;
                TextBox txtTitle = new TextBox();
                txtTitle.Text = cn.ChildNodes[0].InnerText;

                Label lbTitle1 = new Label();
                lbTitle1.Text = cn.ChildNodes[1].ChildNodes[0].Name;
                TextBox txtTitle1 = new TextBox();
                txtTitle1.Text = cn.ChildNodes[1].ChildNodes[0].InnerText;


                Label lbTitle2 = new Label();
                lbTitle2.Text = cn.ChildNodes[1].ChildNodes[1].Name;
                TextBox txtTitle2 = new TextBox();
                txtTitle2.Text = cn.ChildNodes[1].ChildNodes[1].InnerText;
                

                pl.Controls.Add(lbTitle);
                pl.Controls.Add(txtTitle);
                pl.Controls.Add(lbTitle1);
                pl.Controls.Add(txtTitle1);
                pl.Controls.Add(lbTitle2);
                pl.Controls.Add(txtTitle2);


                pl_container.Add(pl);
                
            }

            foreach (Panel p in pl_container)
            {
                form1.Controls.Add(p);
            }

            
            //lbResult.InnerText=si.GetData(9);
        }
    }
}