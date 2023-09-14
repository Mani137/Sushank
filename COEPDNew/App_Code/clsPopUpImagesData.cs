﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayerHelper
{
    public class clsPopUpImagesData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public void AddUpdate(clsPopUpImages obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("PopUpImages_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@PopUpImageId", obj.PopUpImageId);
                    objCmd.Parameters.AddWithValue("@PopUpImageName", obj.PopUpImageName);
                    objCmd.Parameters.AddWithValue("@PopUpImagePath", obj.PopUpImagePath);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }
        public clsPopUpImages Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("PopUpImages_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@PopUpImageId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsPopUpImages objInfo = new clsPopUpImages();
                            objInfo.PopUpImageId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.PopUpImageName = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.PopUpImagePath = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[0].ItemArray[3]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }
        public List<clsPopUpImages> LoadAll(clsPopUpImages obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("PopUpImages_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.Keywords);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);

                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsPopUpImages> objList = new List<clsPopUpImages>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsPopUpImages objInfo = new clsPopUpImages();
                                objInfo.SNo = cnt + 1;
                                objInfo.PopUpImageId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.PopUpImageName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.PopUpImagePath = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[cnt].ItemArray[3]);
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
                using (SqlCommand objCmd = new SqlCommand("PopUpImages_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@PopUpImageId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

    }
}