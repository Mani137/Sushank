﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{
    public class clsLeadStatusData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public void AddUpdate(clsLeadStatus obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeadStatus_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeadStatusId", obj.LeadStatusId);
                    objCmd.Parameters.AddWithValue("@LeadStatus", obj.LeadStatus);
                    objCmd.Parameters.AddWithValue("@Description", obj.Description);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }
        public clsLeadStatus Load(int Id)
        {
            using (SqlConnection objconn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeadStatus_Get", objconn))
                {
                    objconn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeadStatusId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsLeadStatus objInfo = new clsLeadStatus();
                            objInfo.LeadStatusId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.LeadStatus = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }
        public List<clsLeadStatus> LoadAll(clsLeadStatus obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeadStatus_List", objConn))
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
                            List<clsLeadStatus> objList = new List<clsLeadStatus>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsLeadStatus objInfo = new clsLeadStatus();
                                objInfo.SNo = cnt + 1;
                                objInfo.LeadStatusId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.LeadStatus = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objList.Add(objInfo);
                            }
                            return objList;
                        }
                    }
                    return null;
                }
            }
        }
        public void Remove(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeadStatus_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeadStatusId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}