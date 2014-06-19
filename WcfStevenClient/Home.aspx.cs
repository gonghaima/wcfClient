using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WcfStevenClient.Models;
namespace WcfStevenClient
{
    public partial class Home : System.Web.UI.Page
    {
        //Table xmlTable = new Table();
        //SessionParameter spb = new SessionParameter();


        static WebRef.IStevenService serviceClient = new WebRef.StevenServiceClient();
        List<Employee> lstEmployees = new List<Employee>();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        [WebMethod]
        public static string updateEmployees(WebRef.Employee[] lsEMP)
        {
            string strResult="Failed to update Employees!";
            try 
            { 
                serviceClient.SetEmployees(lsEMP);
                strResult = "Record saved successfully via web service!";
            }
            catch (Exception e)
            {

            }
            
            return strResult;
        }

        [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }

        public List<Employee> getEmployees()
        {
            XDocument xDoc = XDocument.Parse(serviceClient.GetXml());
            var employees = from em in xDoc.Descendants("Employee")
                            select new Employee
                            {
                                FirstName = (string)em.Elements("Name").FirstOrDefault().Elements("FirstName").FirstOrDefault().Value,
                                LastName = (string)em.Elements("Name").FirstOrDefault().Elements("LastName").FirstOrDefault().Value,
                                Age = (string)em.Descendants("Age").FirstOrDefault().Value,
                                Department = (string)em.Descendants("Department").FirstOrDefault().Attribute("Name").Value
                            };
            return employees.ToList();
        }


        protected void btnGetXML_Click(object sender, EventArgs e)
        {
            string strXmlContent = serviceClient.GetXml();
            addHeader();

            XDocument xDoc = XDocument.Parse( serviceClient.GetXml());

            var employees = xDoc.Root.Elements("Employee");

            foreach (var employee in employees)
            {
                TableRow newRow = new TableRow();

                string id = employee.Elements("Id").FirstOrDefault().Value.ToString();
                var firstName = employee.Elements("Name").FirstOrDefault().Elements("FirstName").FirstOrDefault().Value;
                var lastName = employee.Elements("Name").FirstOrDefault().Elements("LastName").FirstOrDefault().Value;
                var age = employee.Elements("Age").FirstOrDefault().Value;
                var department = employee.Elements("Department").FirstOrDefault().Attribute("Name").Value;

                TableCell tableCellId = createTBCell(id.ToString(),"id", id,false);
                
                newRow.Cells.Add(tableCellId);

                newRow.Cells.Add(createTBCell(firstName.ToString(),"firstName", id,true));
                newRow.Cells.Add(createTBCell(lastName.ToString(), "lastName", id, true));
                newRow.Cells.Add(createTBCell(age.ToString(), "age", id, true));
                newRow.Cells.Add(createTBCell(department.ToString(), "department", id, true));

                xmlTable.Rows.Add(newRow);
                
                
            }
            xmlTable.CssClass = "table table-striped table-bordered table-condensed table-hover";
            xmlTable.Attributes.Add("runat", "server");
            xmlTable.Attributes.Add("id", "tbXML");

            Button btUpdate = new Button();
            btUpdate.Text = "Update";
            btUpdate.Attributes.Add("id", "btUpdate");
            btUpdate.CssClass = "btn btn-info btn-large";
            GridViewEm.Visible = false;
            form1.Controls.Add(xmlTable);
            form1.Controls.Add(btUpdate);
        }

        void addHeader()
        {
            TableHeaderRow newRowHeader = new TableHeaderRow();

            newRowHeader.Cells.Add(createTBHeaderCell("Employee ID"));
            newRowHeader.Cells.Add(createTBHeaderCell("First Name"));
            newRowHeader.Cells.Add(createTBHeaderCell("Last Name"));
            newRowHeader.Cells.Add(createTBHeaderCell("Age"));
            newRowHeader.Cells.Add(createTBHeaderCell("Department"));
            xmlTable.Rows.Add(newRowHeader);
            
        }


        protected void btnGV_Click(object sender, EventArgs e)
        {
            List<Employee> le = getEmployees();
            GridViewEm.DataSource = getEmployees();
            GridViewEm.Visible = true;
            GridViewEm.DataBind();
        }

        protected void btXml_Click(object sender, EventArgs e)
        {
        }

        private TableCell createTBCell(string strContent, string cat, string id, bool editable)
        {
            TableCell tc = new TableCell();
            tc.Text = strContent;
            if (editable)
            {
                tc.Attributes.Add("contenteditable", "true");
            }
            
            tc.Attributes.Add("id", cat+id);
            return tc;
        }

        private TableHeaderCell createTBHeaderCell(string strContent)
        {
            TableHeaderCell tc = new TableHeaderCell();
            tc.Text = strContent;
            return tc;
        }
    }
}