using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfStevenClient.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
    }
}