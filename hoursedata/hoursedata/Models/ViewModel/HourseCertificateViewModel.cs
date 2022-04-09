using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hoursedata.Model;
using hoursedata.Models.ViewModel;
namespace hoursedata.Models.ViewModel
{
    public class HourseCertificateViewModel: HoursesData
    {
        public int LevelID { get; set; }
        public int LevelCount { get; set; }
    }
}