using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{
    public class clsLeaveTypeData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public virtual void AddUpdate(clsLeaveType obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeaveType_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeaveTypeId", obj.LeaveTypeId);
                    objCmd.Parameters.AddWithValue("@LeaveType", obj.LeaveType);
                    objCmd.Parameters.AddWithValue("@Description", obj.Description);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public virtual clsLeaveType Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeaveType_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeaveTypeId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsLeaveType objInfo = new clsLeaveType();
                            objInfo.LeaveTypeId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.LeaveType = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual List<clsLeaveType> LoadAll(clsLeaveType obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeaveType_List", objConn))
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
                            List<clsLeaveType> objList = new List<clsLeaveType>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsLeaveType objInfo = new clsLeaveType();
                                objInfo.SNo = cnt + 1;
                                objInfo.LeaveTypeId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.LeaveType = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
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

        public virtual void Remove(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("LeaveType_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@LeaveTypeId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

    }
}
