﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;



namespace DataAccessLayerHelper
{

    public class clsParticipantFeePaymentData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public void AddUpdate(clsParticipantFeePayment obj)
        {
            using (SqlConnection objconn = new SqlConnection(Constr))
            {
                using (SqlCommand objcmd = new SqlCommand("Activity_AddUpdate", objconn))
                {
                    objconn.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.AddWithValue("@ActivityId", obj.ActivityId);
                    objcmd.Parameters.AddWithValue("@ActivitySubCategoryId", obj.ActivitySubCategoryId);
                    objcmd.Parameters.AddWithValue("@ActivityCategoryId", obj.ActivityCategoryId);
                    objcmd.Parameters.AddWithValue("@Activity", obj.Activity);
                    //objcmd.Parameters.AddWithValue("@ActivityModeofSelection", obj.ActivityModeofSelection);
                    objcmd.Parameters.AddWithValue("@Description", obj.Description);
                    objcmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objcmd.ExecuteNonQuery();
                }
            }
        }
        //This method is used to get Selected  Activity record  From Activity_Get StoredProcedure
        public clsParticipantFeePayment Load(int id)
        {
            using (SqlConnection objconn = new SqlConnection(Constr))
            {
                using (SqlCommand objcmd = new SqlCommand("ParticipantFeePayment_Get", objconn))
                {
                    objconn.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.AddWithValue("@LeadId", id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsParticipantFeePayment objInfo = new clsParticipantFeePayment();
                            objInfo.Location = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.ServiceId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Employee = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.AgreedFee = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[3]);
                            //  objInfo.ActivityModeofSelection = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[4]);
                            //objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[4]);
                            //objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[0].ItemArray[5]);
                            return objInfo;
                        }
                    }
                    return null;
                }

            }

        }
        //This method is used to get All  Activity records  From Activity_List StoredProcedure
        public List<clsParticipantFeePayment> LoadAll(clsParticipantFeePayment obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objcmd = new SqlCommand("Activity_List", objConn))
                {
                    objConn.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    //objcmd.Parameters.AddWithValue("@keywords", obj.Keywords);
                    objcmd.Parameters.AddWithValue("@Activity", obj.Activity);
                    objcmd.Parameters.AddWithValue("@ActivityCategory", obj.ActivityCategory);
                    objcmd.Parameters.AddWithValue("@ActivitySubCategory", obj.ActivitySubCategory);
                    objcmd.Parameters.AddWithValue("@Fullname", obj.Fullname);
                    objcmd.Parameters.AddWithValue("@ActivityCategoryId", obj.ActivityCategoryId);
                    objcmd.Parameters.AddWithValue("@ActivitySubCategoryId", obj.ActivitySubCategoryId);
                    objcmd.Parameters.AddWithValue("Modifiedname", obj.Modifiedname);
                    //  objcmd.Parameters.AddWithValue("@Description", obj.Description);
                    //objcmd.Parameters.AddWithValue("@ActivityModeofSelection", obj.ActivityModeofSelection);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsParticipantFeePayment> objList = new List<clsParticipantFeePayment>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsParticipantFeePayment objInfo = new clsParticipantFeePayment();
                                objInfo.SNo = cnt + 1;
                                objInfo.ActivityId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.ActivitySubCategoryId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.ActivityCategoryId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.Activity = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[4]);
                                objInfo.ActivityCategory = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[5]);
                                objInfo.CreatedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[6]);
                                objInfo.CreatedBy = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[7]);
                                if (objDset.Tables[0].Rows[cnt].ItemArray[8] != DBNull.Value)
                                    objInfo.ModifiedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[8]);
                                if (objDset.Tables[0].Rows[cnt].ItemArray[9] != DBNull.Value)
                                    objInfo.ModifiedBy = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[9]);
                                objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[10]);
                                objInfo.ActivitySubCategory = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[11]);
                                objInfo.Employee = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[12]);
   
                                objList.Add(objInfo);
                            }
                            return objList;
                        }

                    }
                    return null;
                }
            }
        }

        //public List<clsParticipantFeePayment> LoadAllActivityActivityModeofSelection(clsParticipantFeePayment obj)
        //{
        //    using (SqlConnection objConn = new SqlConnection(Constr))
        //    {
        //        using (SqlCommand objcmd = new SqlCommand("ActivityModeofSelection_List", objConn))
        //        {
        //            objConn.Open();
        //            objcmd.CommandType = CommandType.StoredProcedure;

        //            objcmd.Parameters.AddWithValue("@ActivityModeofSelection", obj.ActivityModeofSelection);
        //            DataSet objDset = new DataSet();
        //            SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
        //            objAdp.Fill(objDset);
        //            if (objDset.Tables.Count > 0)
        //            {
        //                if (objDset.Tables[0].Rows.Count > 0)
        //                {
        //                    List<clsParticipantFeePayment> objList = new List<clsParticipantFeePayment>();
        //                    for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
        //                    {
        //                        clsParticipantFeePayment objInfo = new clsParticipantFeePayment();
        //                        objInfo.SNo = cnt + 1;
        //                        objInfo.ActivityId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
        //                        objInfo.ActivitySubCategoryId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[1]);
        //                        objInfo.ActivityCategoryId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[2]);
        //                        objInfo.Activity = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
        //                        objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[4]);
        //                        objInfo.ActivityCategory = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[5]);
        //                        objInfo.CreatedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[6]);
        //                        objInfo.CreatedBy = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[7]);
        //                        if (objDset.Tables[0].Rows[cnt].ItemArray[8] != DBNull.Value)
        //                        {
        //                            objInfo.ModifiedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[8]);
        //                        }
        //                        if (objDset.Tables[0].Rows[cnt].ItemArray[9] != DBNull.Value)
        //                        {
        //                            objInfo.ModifiedBy = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[9]);
        //                        }

        //                        objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[10]);
        //                        objInfo.ActivitySubCategory = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[11]);
        //                        objInfo.Employee = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[12]);
        //                        objInfo.ActivityModeofSelection = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[13]);
        //                        objList.Add(objInfo);
        //                    }
        //                    return objList;
        //                }

        //            }
        //            return null;
        //        }
        // }
        // }
        //This method is used to Remove to validate  Activity   From Activity_Remove StoredProcedure
        public void Remove(int id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("Activity_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@ActivityId", id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
