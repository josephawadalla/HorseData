using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using hoursedata.Model;
using hoursedata.Models.ViewModel;

namespace hoursedata.Models.Repositories
{
    public class ParentRelationRepository
    {
        public static bool AddParentRelation(ParentRelation parentRelation)
        {
            bool result = false;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon);
                SqlCommand cmdadd = new SqlCommand(@"INSERT INTO [ParentRelation]  
                                                              ([FatherID],[MotherID]) 
                                                       Values (@FatherID,@MotherID) ", con);


                cmdadd.Parameters.AddWithValue("@FatherID", parentRelation.FatherID);
                cmdadd.Parameters.AddWithValue("@MotherID", parentRelation.MotherID);

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

        internal static ParentRelation Find(string ParentRelationID)
        {
            SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon);
            ParentRelation parentRelation = new ParentRelation();
            SqlCommand cmd = new SqlCommand("SELECT Top(1) *  FROM  Hourses WHERE (ParentRelationID = @ParentRelationID)", con);
            cmd.Parameters.AddWithValue("@ParentRelationID", ParentRelationID);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                parentRelation.ParentRelationID = Convert.ToInt32(reader["ParentRelationID"]);
                parentRelation.FatherID = Convert.ToInt32(reader["FatherID"]);
                parentRelation.MotherID = Convert.ToInt32(reader["MotherID"]);
            }
            con.Close();
            return parentRelation;
        }

        internal static IList<RelationViewModel> ActiveList()
        {
            List<RelationViewModel> RelatioDataList = new List<RelationViewModel>();
            using (SqlConnection con = new SqlConnection(ConnectionStringHelper.HCon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  ParentRelationData", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RelationViewModel RelationData = new RelationViewModel
                            {
                                ParentRelationID = Convert.ToInt32(reader["ParentRelationID"]),
                                FatherID = Convert.ToInt32(reader["FatherID"]),
                                MotherID = Convert.ToInt32(reader["MotherID"]),
                                FatherName = reader["Father"].ToString(),
                                MotherName = reader["Mother"].ToString(),
                            };

                            RelatioDataList.Add(RelationData);
                        }
                    }
                }
            }

            return RelatioDataList;
        }
    }

}