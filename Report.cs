using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication14
{
    public class Report
    {
        public string ReportType { get; set; }
        public string ReportHeader { get; set; }
        public string ReportFooter { get; set; }
        public string ReportContent { get; set; }
        public string DisplayReport()
        {
            string hold = "";
            hold += "" + ReportType + "\n";
            hold += "" + ReportHeader + "\n";
            hold += "" + ReportContent + "\n";
            hold += "" + ReportFooter + "\n";

            return hold;
        }
    }
}
