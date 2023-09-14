﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{

    public class clsCoepdWebinarValueData
    {

        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();
        public void AddUpdate(clsCoepdWebinarValue obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("CoepdWebinarValue_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeadId", obj.LeadId);
                    objCmd.Parameters.AddWithValue("@Offer", obj.Offer);
                    objCmd.Parameters.AddWithValue("@Name", obj.Name);
                    objCmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    objCmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
                    objCmd.Parameters.AddWithValue("@Location", obj.Location);
                    objCmd.Parameters.AddWithValue("@Date", obj.Date);
                    objCmd.Parameters.AddWithValue("@SpecificEnquiry", obj.SpecificEnquiry);

                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public clsCoepdWebinarValue Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("CoepdWebinarValue_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeadId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsCoepdWebinarValue objInfo = new clsCoepdWebinarValue();
                            objInfo.LeadId = Convert.ToInt32(objDset.Tables[0].Rows[0]["LeadId"]);
                            objInfo.Offer = Convert.ToInt32(objDset.Tables[0].Rows[0]["Offer"]);
                            objInfo.Name = Convert.ToString(objDset.Tables[0].Rows[0]["Name"]);
                            objInfo.EmailId = Convert.ToString(objDset.Tables[0].Rows[0]["EmailId"]);
                            objInfo.MobileNo = Convert.ToString(objDset.Tables[0].Rows[0]["MobileNo"]);
                            objInfo.Location = Convert.ToString(objDset.Tables[0].Rows[0]["Location"]);
                            objInfo.SpecificEnquiry = Convert.ToString(objDset.Tables[0].Rows[0]["SpecificEnquiry"]);

                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }
        public List<clsCoepdWebinarValue> LoadAll(clsCoepdWebinarValue obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("CoepdWebinarValue_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@Title", obj.Title);
                    objCmd.Parameters.AddWithValue("@Location", obj.Location);
                    objCmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
                    objCmd.Parameters.AddWithValue("@ToDate", obj.ToDate);

                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsCoepdWebinarValue> objList = new List<clsCoepdWebinarValue>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsCoepdWebinarValue objInfo = new clsCoepdWebinarValue();
                                objInfo.SNO = cnt + 1;
                                objInfo.LeadId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Offer = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Name = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.EmailId = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objInfo.MobileNo = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[4]);
                                objInfo.SpecificEnquiry = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[5]);
                                objInfo.Location = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[6]);
                                objInfo.Date = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[7]);
                                objInfo.Title = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[8]);
                                objInfo.CreatedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[9]);
                                objInfo.FullName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[10]);
                                objList.Add(objInfo);
                            }
                            return objList;
                        }
                    }
                    return null;
                }
            }
        }
        public int LoadCoepdValueMobileValidation(clsCoepdWebinarValue obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("CoepdWebinarValue_MobileValidation", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
                    int Count = Convert.ToInt32(objCmd.ExecuteScalar());
                    return Count;
                }
            }
        }
        public int LoadCoepdValueEmailValidation(clsCoepdWebinarValue obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("CoepdWebinarValue_EmailValidation", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    int Count = Convert.ToInt32(objCmd.ExecuteScalar());
                    return Count;
                }
            }
        }
    }
}


