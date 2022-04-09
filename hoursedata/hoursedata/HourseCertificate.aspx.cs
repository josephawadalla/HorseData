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
    public partial class HourseCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int hourseid = 0;
                if (Request.QueryString["HourseID"] != null)
                {
                    hourseid = Convert.ToInt32(Request.QueryString["HourseID"]);
                }
                HoursesDatalist hoursesDatalist = new HoursesDatalist();
                hoursesDatalist = HourseRepository.hoursesDatalist(hourseid);
                            
                Repeater1.DataSource = hoursesDatalist.hoursesDatalist1;
                Repeater1.DataBind();

                Repeater2.DataSource = hoursesDatalist.hoursesDatalist2;
                Repeater2.DataBind();

                Repeater3.DataSource = hoursesDatalist.hoursesDatalist3;
                Repeater3.DataBind();

                Repeater4.DataSource = hoursesDatalist.hoursesDatalist4;
                Repeater4.DataBind();

                Repeater5.DataSource = hoursesDatalist.hoursesDatalist5;
                Repeater5.DataBind();

                Repeater6.DataSource = hoursesDatalist.hoursesDatalist6;
                Repeater6.DataBind();
            }
        }
    }
}