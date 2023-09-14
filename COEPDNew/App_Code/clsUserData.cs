using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerHelper
{
    public class clsUserData
    {
        public string Constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString.ToString();

        public virtual void AddUpdate(clsUser obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_AddUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    objCmd.Parameters.AddWithValue("@Username", obj.Username);
                    objCmd.Parameters.AddWithValue("@Pwd", obj.Pwd);
                    objCmd.Parameters.AddWithValue("@Fullname", obj.Fullname);
                    objCmd.Parameters.AddWithValue("@RoleId", obj.RoleId);
                    objCmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    objCmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    objCmd.Parameters.AddWithValue("@ParticipantId", obj.ParticipantId);
                    objCmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                    objCmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    objCmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
                    objCmd.Parameters.AddWithValue("@Description", obj.Description);

                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public virtual clsUser Load(int Id)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_Get", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("UserId", Id);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsUser objInfo = new clsUser();
                            objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Pwd = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[3]);
                            objInfo.RoleId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[4]);
                            objInfo.BranchId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[5]);
                            objInfo.ParticipantId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[6]);
                            objInfo.Mobile = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[7]);
                            objInfo.EmployeeId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[8]);
                            objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[9]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual clsUser LoadByParticipantId(int ParticipantId)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_Get_ParticipantId", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("ParticipantId", ParticipantId);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsUser objInfo = new clsUser();
                            objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Pwd = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[3]);

                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual List<clsUser> LoadAll(clsUser obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.keywords);
                    objCmd.Parameters.AddWithValue("@RoleId", obj.RoleId);
                    objCmd.Parameters.AddWithValue("@UserId", obj.UserId);

                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsUser> objList = new List<clsUser>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsUser objInfo = new clsUser();
                                objInfo.SNo = cnt + 1;
                                objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Pwd = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objInfo.RoleId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[4]);
                                objInfo.Rolename = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[5]);
                                objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[cnt].ItemArray[6]);
                                objInfo.BranchName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[7]);
                                objInfo.CreatedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[8]);
                                objInfo.Mobile = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[9]);
                                objInfo.EmployeeId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[10]);
                                objInfo.LocationId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[11]);
                                objInfo.Location = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[12]);
                                objInfo.Description = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[13]);
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
                using (SqlCommand objCmd = new SqlCommand("User_Remove", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@UserId", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public virtual clsUser CheckExist(string Username)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_CheckExists", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@Username", Username);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsUser objInfo = new clsUser();
                            objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.RoleId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[3]);
                            objInfo.BranchId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[4]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual clsUser CheckValidate(clsUser obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_Validate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@Username", obj.Username);
                    objCmd.Parameters.AddWithValue("@Pwd", obj.Pwd);
                    objCmd.Parameters.AddWithValue("@LoginIPAddress", obj.LoginIPAddress);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            clsUser objInfo = new clsUser();
                            objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[0]);
                            objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[1]);
                            objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[2]);
                            objInfo.RoleId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[3]);
                            objInfo.BranchId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[4]);
                            objInfo.ParticipantId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[5]);
                            objInfo.EmployeeId = Convert.ToInt32(objDset.Tables[0].Rows[0].ItemArray[6]);
                            objInfo.Mobile = Convert.ToString(objDset.Tables[0].Rows[0].ItemArray[7]);
                            return objInfo;
                        }
                    }
                    return null;
                }
            }
        }

        public virtual string ChangePassword(clsUser obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("User_PasswordUpdate", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    objCmd.Parameters.AddWithValue("@Pwd", obj.Pwd);
                    objCmd.Parameters.AddWithValue("@NewPwd", obj.NewPwd);

                    SqlParameter paramout = new SqlParameter("@Out_msg", SqlDbType.VarChar, 500);
                    paramout.Direction = ParameterDirection.Output;
                    objCmd.Parameters.Add(paramout);
                    objCmd.ExecuteNonQuery();
                    string outmsg = paramout.SqlValue.ToString();
                    return outmsg;
                }
            }
        }

        public virtual List<clsUser> LoadAllEmployees(clsUser obj)
        {
            using (SqlConnection objConn = new SqlConnection(Constr))
            {
                using (SqlCommand objCmd = new SqlCommand("UserEmployee_List", objConn))
                {
                    objConn.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@keywords", obj.keywords);
                    objCmd.Parameters.AddWithValue("@RoleId", obj.RoleId);
                    DataSet objDset = new DataSet();
                    SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
                    objAdp.Fill(objDset);
                    if (objDset.Tables.Count > 0)
                    {
                        if (objDset.Tables[0].Rows.Count > 0)
                        {
                            List<clsUser> objList = new List<clsUser>();
                            for (int cnt = 0; cnt < objDset.Tables[0].Rows.Count; cnt++)
                            {
                                clsUser objInfo = new clsUser();
                                objInfo.SNo = cnt + 1;
                                objInfo.UserId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[0]);
                                objInfo.Username = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[1]);
                                objInfo.Pwd = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[2]);
                                objInfo.Fullname = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[3]);
                                objInfo.RoleId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[4]);
                                objInfo.Rolename = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[5]);
                                objInfo.IsActive = Convert.ToBoolean(objDset.Tables[0].Rows[cnt].ItemArray[6]);
                                objInfo.BranchName = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[7]);
                                objInfo.CreatedOn = Convert.ToDateTime(objDset.Tables[0].Rows[cnt].ItemArray[8]);
                                objInfo.Mobile = Convert.ToString(objDset.Tables[0].Rows[cnt].ItemArray[9]);
                                objInfo.EmployeeId = Convert.ToInt32(objDset.Tables[0].Rows[cnt].ItemArray[10]);
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
