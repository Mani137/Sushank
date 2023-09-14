﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayerHelper
{
    public class clsTrainerProfileData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public void AddUpdate(clsTrainerProfile obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("TrainerProfile_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@TrainerProfileId", obj.TrainerProfileId);
                    objCmd.Parameters.AddWithValue("@Name", obj.Name);
                    objCmd.Parameters.AddWithValue("@Description", obj.Description);
                    objCmd.Parameters.AddWithValue("@Profile", obj.Profile);
                    objCmd.Parameters.AddWithValue("@ImageThumbPath", obj.ImageThumbPath);
                    objCmd.Parameters.AddWithValue("@IsFeatured", obj.IsFeatured);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public clsTrainerProfile Load(int Id)
        {
            using (SqlConnection objconn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("TrainerProfile_Get", objconn))
                {
                    objconn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@TrainerProfileId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsTrainerProfile objInfo = new clsTrainerProfile();
                            objInfo.TrainerProfileId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Name = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.Profile = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[3]);
                            objInfo.ImageThumbPath = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[4]);
                            objInfo.IsFeatured = Convert.ToBoolean(objDset.Tables[0].Rows[0].ItemArray[5]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public List<clsTrainerProfile> LoadAll(clsTrainerProfile obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("TrainerProfile_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.Keywords);
                    objCmd.Parameters.AddWithValue("@IsFeatured", obj.IsFeatured);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsTrainerProfile> objList = new List<clsTrainerProfile>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsTrainerProfile objInfo = new clsTrainerProfile();
                                objInfo.SNo = cnt + 1;
                                objInfo.TrainerProfileId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Name = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.Profile = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objInfo.ImageThumbPath = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[4]);
                                objInfo.IsFeatured = Convert.ToBoolean(objDset.Tables[0].Rows[cnt].ItemArray[5]);
                                objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[cnt].ItemArray[6]);
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
                using (SqlCommand objCmd = new SqlCommand("TrainerProfile_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@TrainerProfileId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

    }
}
