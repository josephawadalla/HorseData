using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hoursedata.Model
{
    public class Hourses
    {
        public int HourseID { get; set; }
        public string HourseName { get; set; }
        public int GenderID { get; set; }
        public int ParentRelationID { get; set; }

    }
}