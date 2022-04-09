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
    public partial class HorsesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<HoursesData> hoursesDatalist = new List<HoursesData>();
                hoursesDatalist.AddRange((IEnumerable<HoursesData>)HourseRepository.ActiveList());
                Repeater1.DataSource = hoursesDatalist;
                Repeater1.DataBind();
            }
        }
    }
}