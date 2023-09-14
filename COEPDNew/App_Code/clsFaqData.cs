using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{
    public class clsFaqData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public virtual void AddUpdate(clsFaq obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("Faq_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@FaqId", obj.FaqId);
                    objCmd.Parameters.AddWithValue("@Faq", obj.Faq);
                    objCmd.Parameters.AddWithValue("@Description", obj.Description);
                    objCmd.Parameters.AddWithValue("@FaqTypeId", obj.FaqTypeId);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public virtual clsFaq Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("Faq_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("FaqId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsFaq objInfo = new clsFaq();
                            objInfo.FaqId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Faq = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.FaqTypeId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[3]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual List<clsFaq> LoadAll(clsFaq obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("Faq_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.keywords);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsFaq> objList = new List<clsFaq>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsFaq objInfo = new clsFaq();
                                objInfo.SNo = cnt + 1;
                                objInfo.FaqId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Faq = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.FaqTypeId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objList.Add(objInfo);
                            }
                            return objList;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual void Remove(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("Faq_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@FaqId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

    }
}