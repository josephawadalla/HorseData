using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hoursedata.Model;

namespace hoursedata.Models.ViewModel
{
    public class HoursesData :Hourses
    {
        public int FatherID { get; set; }
        public string FatherName { get; set; }
        public int MotherID { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public int LevelID { get; set; }
        public int LevelCount { get; set; }

    }
}