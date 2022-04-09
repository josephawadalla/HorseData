using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hoursedata.Model;

namespace hoursedata.Models.ViewModel
{
    public class RelationViewModel: ParentRelation
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}