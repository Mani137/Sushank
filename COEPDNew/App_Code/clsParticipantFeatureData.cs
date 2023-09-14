﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{
    public class clsParticipantFeatureData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        //Participant Feature
        // This method is used to Add and update the Participant features by using ParticipantFeature_AddUpdate StoredProcedure
        public void AddUpdate(clsParticipantFeature obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("ParticipantFeature_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@FeatureId", obj.FeatureId);//By using FeatureId  Updating the feture deatils  
                    objCmd.Parameters.AddWithValue("@ModuleId", obj.ModuleId);
                    objCmd.Parameters.AddWithValue("@Feature", obj.Feature);
                    objCmd.Parameters.AddWithValue("@PageName", obj.PageName);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }


        public clsParticipantFeature Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("ParticipantFeature_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("FeatureId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsParticipantFeature objInfo = new clsParticipantFeature();
                            objInfo.FeatureId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.ModuleId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Feature = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.PageName = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[3]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }


        public List<clsParticipantFeature> LoadAll(clsParticipantFeature obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("ParticipantFeature_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.keywords);
                    objCmd.Parameters.AddWithValue("@ModuleId", obj.ModuleId);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsParticipantFeature> objList = new List<clsParticipantFeature>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsParticipantFeature objInfo = new clsParticipantFeature();
                                objInfo.SNo = cnt + 1;
                                objInfo.FeatureId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Module = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Feature = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.PageName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objList.Add(objInfo);
                            }
                            return objList;
                        }
                    }
                    return null;
                }
            }
        }

        //Participant Feature
        //This Method is  used to returns List of feature of a perticular Module which are  not assigned to given Participant  from ParticipantFeature_List_Assign.

        public List<clsParticipantFeature> LoadAllAvilable(clsParticipantFeature obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("ParticipantFeature_List_NotAssigned", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    //objCmd.Parameters.AddWithValue("@keywords", obj.keywords);
                    objCmd.Parameters.AddWithValue("@ModuleId", obj.ModuleId);
                    objCmd.Parameters.AddWithValue("@ParticipantId", obj.ParticipantId);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsParticipantFeature> objList = new List<clsParticipantFeature>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsParticipantFeature objInfo = new clsParticipantFeature();
                                objInfo.SNo = cnt + 1;
                                objInfo.FeatureId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Module = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Feature = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.PageName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objList.Add(objInfo);
                            }
                            return objList;
                        }
                    }
                    return null;
                }
            }
        }


    }
}

