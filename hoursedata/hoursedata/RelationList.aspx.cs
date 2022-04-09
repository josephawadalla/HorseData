using hoursedata.Models.Repositories;
using hoursedata.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hoursedata
{
    public partial class RelationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<RelationViewModel> RelationDataList = new List<RelationViewModel>();
                RelationDataList.AddRange((IEnumerable<RelationViewModel>)ParentRelationRepository.ActiveList());
                Repeater1.DataSource = RelationDataList;
                Repeater1.DataBind();
            }
        }
    }
}