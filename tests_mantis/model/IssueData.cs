using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tests_mantis
{
    public class IssueData
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
