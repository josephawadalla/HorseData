using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using hoursedata.Model;
using hoursedata.Models.ViewModel;

namespace hoursedata.Models.Repositories
{
    public class HourseRepository
    {

        public static bool AddHourse(Hourses hourse)
        {
            bool result = false;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon);
                SqlCommand cmdadd = new SqlCommand(@"INSERT INTO [Hourses]  
                                                              ([HourseName],[GenderID],[ParentRelationID]) 
                                                       Values (@HourseName,@GenderID,@ParentRelationID) ", con);


                cmdadd.Parameters.AddWithValue("@HourseName", hourse.HourseName);
                cmdadd.Parameters.AddWithValue("@GenderID", hourse.GenderID);
                cmdadd.Parameters.AddWithValue("@ParentRelationID", hourse.ParentRelationID);

                cmdadd.Connection = con;
                con.Open();
                int exc = cmdadd.ExecuteNonQuery();
                con.Close();
                if (exc == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }



        internal static Hourses Find(string HourseID)
        {
            SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon);
            Hourses hourse = new Hourses();
            SqlCommand cmd = new SqlCommand("SELECT Top(1) *  FROM  Hourses WHERE (HourseID = @HourseID)", con);
            cmd.Parameters.AddWithValue("@HourseID", HourseID);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                hourse.HourseID = Convert.ToInt32(reader["HourseID"]);
                hourse.HourseName = reader["HourseName"].ToString();
                hourse.GenderID = Convert.ToInt32(reader["Gender"]);
                hourse.ParentRelationID = Convert.ToInt32(reader["ParentRelationID"]);
            }
            con.Close();
            return hourse;
        }

        internal static IList<HoursesData> ActiveList()
        {
            List<HoursesData> hoursesDataList = new List<HoursesData>();
            using (SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  HoursesData", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoursesData hoursesData = new HoursesData
                            {
                                HourseID = Convert.ToInt32(reader["HourseID"]),
                                HourseName = reader["HourseName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                FatherName = reader["FatherName"].ToString(),
                                MotherName = reader["MotherName"].ToString(),
                            };

                            hoursesDataList.Add(hoursesData);
                        }
                    }
                }
            }

            return hoursesDataList;
        }

        internal static IList<HourseCertificateViewModel> CertificateList()
        {
            List<HourseCertificateViewModel> hoursesDataList = new List<HourseCertificateViewModel>();
            using (SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  HoursesData", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HourseCertificateViewModel hoursesData = new HourseCertificateViewModel
                            {
                                HourseID = Convert.ToInt32(reader["HourseID"]),
                                HourseName = reader["HourseName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                FatherID = Convert.ToInt32(reader["FatherID"]),
                                MotherID = Convert.ToInt32(reader["MotherID"]),
                            };

                            hoursesDataList.Add(hoursesData);
                        }
                    }
                }
            }

            return hoursesDataList;
        }

        internal static HoursesDatalist hoursesDatalist(int hourseid)
        {
            List<int> parentid = new List<int>();
            HoursesDatalist hoursesDatalist = new HoursesDatalist();
            HoursesData hoursesData1 = HourseDataFind(hourseid);
            hoursesDatalist.hoursesDatalist1.Add(hoursesData1);

            parentid.Add(hoursesData1.MotherID);
            parentid.Add(hoursesData1.FatherID);
            hoursesDatalist.hoursesDatalist2 = HoursesDataFind(parentid.ToList());

            List<int> parentid2 = new List<int>();
            foreach (var item in hoursesDatalist.hoursesDatalist2)
            {
                parentid2.Add(item.FatherID);
                parentid2.Add(item.MotherID);
            }

            hoursesDatalist.hoursesDatalist3 = HoursesDataFind(parentid2.ToList());

            List<int> parentid3 = new List<int>();
            foreach (var item in hoursesDatalist.hoursesDatalist3)
            {
                parentid3.Add(item.FatherID);
                parentid3.Add(item.MotherID);
            }

            hoursesDatalist.hoursesDatalist4 = HoursesDataFind(parentid3.ToList());

            List<int> parentid4 = new List<int>();
            foreach (var item in hoursesDatalist.hoursesDatalist4)
            {
                parentid4.Add(item.FatherID);
                parentid4.Add(item.MotherID);
            }

            hoursesDatalist.hoursesDatalist5 = HoursesDataFind(parentid4.ToList());

            List<int> parentid5 = new List<int>();
            foreach (var item in hoursesDatalist.hoursesDatalist5)
            {
                parentid5.Add(item.FatherID);
                parentid5.Add(item.MotherID);
            }

            hoursesDatalist.hoursesDatalist6 = HoursesDataFind(parentid5.ToList());
            return hoursesDatalist;
        }

        private static List<HoursesData> HoursesDataFind(List<int> parentid)
        {
            List<HoursesData> hoursesDatalist = new List<HoursesData>();
            int parentcount =parentid.Count;
           // List<int> myparent = parentid.ToList();
            for (int i = 0; i < parentcount; i++)
            {
                using (SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM  HoursesData Where HourseID =@hourseID", con);
                    cmd.Parameters.AddWithValue("@hourseID", parentid[i]);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoursesData hoursesData = new HoursesData
                            {
                                HourseID = Convert.ToInt32(reader["HourseID"]),
                                HourseName = reader["HourseName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                FatherID = Convert.ToInt32(reader["FatherID"]),
                                MotherID = Convert.ToInt32(reader["MotherID"]),
                            };
                            hoursesDatalist.Add(hoursesData);
                        }
                    }
                }
            }
         

            return hoursesDatalist;
        }

        internal static HoursesData HourseDataFind(int hourseID)
        {
            SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon);
            HoursesData hourse = new HoursesData();
            SqlCommand cmd = new SqlCommand("SELECT Top(1) *  FROM  HoursesData WHERE (HourseID = @HourseID)", con);
            cmd.Parameters.AddWithValue("@HourseID", hourseID);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                hourse.HourseID = Convert.ToInt32(reader["HourseID"]);
                hourse.HourseName = reader["HourseName"].ToString();
                hourse.Gender = reader["Gender"].ToString();
                hourse.FatherID = Convert.ToInt32(reader["FatherID"]);
                hourse.MotherID = Convert.ToInt32(reader["MotherID"]);
            }
            con.Close();
            return hourse;
        }
    }
}