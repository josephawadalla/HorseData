using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hoursedata.Model
{
    public class ParentRelation
    {
        public int ParentRelationID { get; set; }
        public int FatherID { get; set; }
        public int MotherID { get; set; }
    }
}