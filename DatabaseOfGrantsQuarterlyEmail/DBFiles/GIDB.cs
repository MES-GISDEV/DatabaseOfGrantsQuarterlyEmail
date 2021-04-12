using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using System;
using System.IO;
using System.Net;
using System.Configuration;
using SimpleEncryption;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Text;
using DatabaseOfGrantsEmail.Properties;

namespace GrantsIdentification
{
    public class GIDB
    {
        public int RowCount;
        public int Identity;
        public Collection OutputIdentities = new Collection();
        public string ErrMsg = "";

        private readonly SqlConnection Conn;
        private SqlCommand Cmd;
        private SqlDataAdapter da;
        private GILib l = new GILib();
        private int iTimeout = 30;

        #region 'Local Variables and Objects'
        public int Timeout
        {
            get
            {
                return iTimeout;
            }
            set
            {
                iTimeout = value;
            }
        }

        public class SQLParamCollection
        {
            // You can't instantiate the SqlParameterCollection as a variable, you have to get it from the command object
            // which defeats the purpose of passing around a collection.  So we'll create this class and pass it.

            public Collection ParamCollection;

            public SQLParamCollection(string ParamName = "", object Value = null)
            {
                ParamCollection = new Collection();
                if ((ParamName.Length > 0))
                    AddWithValue(ParamName, Value);
            }

            //Buliding the parameter collection, we will want to add to it, this group of code accomplishes this
            //Note the only required values here are the parameter name and the value
            public void AddWithValue(string ParamName, object Value, object SQLDBDataType = null, object ParamDirection = null)
            {
                SqlParameter p = new SqlParameter
                {
                    ParameterName = ParamName
                };
                //Generally there won't be a parameter direction, so the value will be stored
                if (ParamDirection == null)
                    p.Value = Value;
                //Generally this is not done but if we want to declare the data type declare it here
                //Note: if this the case it's very likely the Param Direction is also going to included above
                if (SQLDBDataType != null)
                    p.SqlDbType = (SqlDbType)SQLDBDataType;
                /*By default the parameter direction will be input, 
                If we want an identity value, we will ask for ParameterDirection.Output
                Though below is not limited to identity values*/
                if (ParamDirection != null)
                    p.Direction = (ParameterDirection)ParamDirection;
                else
                    p.Direction = ParameterDirection.Input;
                ParamCollection.Add(p);
            }
        }

        #endregion

        #region 'Select Commands'

        public DataSet SelectAllUsers()
        {
            return SelectCommand("SelectAllUsers");
        }

        public DataSet SelectByIDGrants(int ID)
        {
            SQLParamCollection p = new SQLParamCollection("@ID", ID);
            return SelectCommand("SelectByIDGrants", p);
        }

        public DataSet SelectByEmailUsers(string Email)
        {
            SQLParamCollection p = new SQLParamCollection("@Email", Email);
            return SelectCommand("SelectByEmailUsers", p);
        }

        public DataSet SelectByAliasUsers(string Alias)
        {
            SQLParamCollection p = new SQLParamCollection("@Alias", Alias);
            return SelectCommand("SelectByAliasUsers", p);
        }

        public DataSet SelectByIDUsers(int tblUserID)
        {
            SQLParamCollection p = new SQLParamCollection("@tblUserID", tblUserID);
            return SelectCommand("SelectByIDUsers", p);
        }

        // selects all grants that pertain to a specific filter, used in main search for search table
        public DataSet SelectAllGrantsFilter(int ID, string ProgramName, string GrantSubject, string AgencyName, string LastUpdated, string CostShareType, string FundingType)
        {
            SQLParamCollection p = new SQLParamCollection("@ID", ID);
            p.AddWithValue("@ProgramName", ProgramName);
            p.AddWithValue("@GrantSubject", GrantSubject);
            p.AddWithValue("@AgencyName", AgencyName);
            p.AddWithValue("@LastUpdated", LastUpdated);
            p.AddWithValue("@CostShareType", CostShareType);
            p.AddWithValue("@FundingType", FundingType);
            return SelectCommand("SelectAllGrantsFilter", p);
        }

        // selects all grants that are due in the next 8 weeks or less
        public DataSet SelectAllGrantsNearDue()
        {
            return SelectCommand("SelectAllGrantsNearDue");
        }

        public DataSet SelectAllFiscalYear()
        {
            return SelectCommand("SelectAllFiscalYear");
        }

        public DataSet SelectAllCostShareType()
        {
            return SelectCommand("SelectAllCostShareType");
        }

        public DataSet SelectAllFundingType()
        {
            return SelectCommand("SelectAllFundingType");
        }

        public DataSet SelectAllRoles()
        {
            return SelectCommand("SelectAllRoles");
        }

        // verify a user can successfully login
        public DataSet VerifyLogin(string email, string password)
        {
            SQLParamCollection p = new SQLParamCollection("@Email", email);
            p.AddWithValue("@Password", password);

            return SelectCommand("VerifyLogin", p);
        }
        
        /*This is the main function that is used to retreive data from a SQL select stored procedure
        QueryName is the name of SQL stored procedure, Params is the SQLParamCollection generated from
        the "child function"*/
        private DataSet SelectCommand(string SPName, SQLParamCollection Params = null/* TODO Change to default(_) if this is not a reference type */)
        {
            DataSet ds = new DataSet();
            string ErrMsg = ""; //used in case there is an error message
            OutputIdentities.Clear();

            try
            {
                /*Set up a new SQL command
                Call the stored procedure to the server on the connection string, indicated it is
                a stored procedure*/
                Identity = 0;

                Cmd = new SqlCommand(SPName, Conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //Set the sql data adapter to a new version
                da = new SqlDataAdapter(Cmd);

                /*If the SQL Param Collection isn't empty then add the parameter to the data
                adapator select command that will be performed*/
                if ((Params != null))
                {
                    foreach (SqlParameter p in Params.ParamCollection)
                    {
                        // da.SelectCommand.Parameters.AddWithValue(p.ParameterName, p.Value)
                        SqlParameter pOut = Cmd.CreateParameter();
                        if (p.Direction == ParameterDirection.Output)
                        {
                            pOut.ParameterName = p.ParameterName;
                            pOut.Direction = ParameterDirection.Output;
                            pOut.SqlDbType = p.SqlDbType;
                            da.SelectCommand.Parameters.Add(pOut);
                        }
                        else if (p.SqlDbType == SqlDbType.NVarChar)
                            da.SelectCommand.Parameters.AddWithValue(p.ParameterName, p.Value);
                        else
                        {
                            SqlParameter sp = new SqlParameter
                            {
                                ParameterName = p.ParameterName,
                                Value = p.Value,
                                SqlDbType = p.SqlDbType
                            };
                            da.SelectCommand.Parameters.Add(sp);
                        }
                    }
                }

                RowCount = da.Fill(ds);

                //This is the goal of this function, returning the dataset that will be used to present data
                return ds;
            }
            //Try to return a slightly more detailed message if there is an error
            catch (Exception ex)
            {
                ErrMsg = "SelectCommand: " + Constants.vbCrLf + SPName + Constants.vbCrLf + ex.Message;
                l.LogIt(ErrMsg, true, "DB Error", Params);
            }

            return ds;
        }
        #endregion

        #region UpdateProcedures

        public bool UpdateGrantActive(ref GrantsDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@ID", dto.ID);
            p.AddWithValue("@Active", dto.Active);

            return UpdateCommand("UpdateGrantActive", p);
        }

        public bool UpdateUserActive(int tblUserID, bool Active)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@tblUserID", tblUserID);
            p.AddWithValue("@Active", Active);

            return UpdateCommand("UpdateUserActive", p);
        }

        public bool UpdateUserVerified(int tblUserID, bool Verified)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@tblUserID", tblUserID);
            p.AddWithValue("@Verified", Verified);

            return UpdateCommand("UpdateUserVerified", p);
        }

        bool UpdateCommand(string queryName, SQLParamCollection Params)
        {
            bool retVal = false;
            SqlParameter s = new SqlParameter();

            try
            {
                Identity = 0;
                Cmd = new SqlCommand(queryName, Conn);
                foreach (SqlParameter p in Params.ParamCollection)
                {
                    Cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.ExecuteNonQuery();
                retVal = true;
            }
            catch (Exception ex)
            {
                ErrMsg = "UpdateCommand: " + Constants.vbCrLf + queryName + Constants.vbCrLf + ex.Message;
                l.LogIt(ErrMsg, true, "DB Error", Params);
            }

            return retVal;
        }

        #endregion

        #region "Save Commands"
        public bool SaveUser(ref UserDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@tblUserID", dto.tblUserID);
            p.AddWithValue("@Email", dto.Email);
            p.AddWithValue("@Password", dto.Password);
            p.AddWithValue("@Alias", dto.Alias);
            p.AddWithValue("@FirstName", dto.FirstName);
            p.AddWithValue("@LastName", dto.LastName);
            p.AddWithValue("@luRoleID", dto.luRoleID);
            p.AddWithValue("@OrganizationShortName", "MES");
            p.AddWithValue("@OrganizationFullName", "Maryland Environmental Service");
            p.AddWithValue("@Active", dto.Active);
            p.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
            p.AddWithValue("@DateCreated", DateTime.Now);
            p.AddWithValue("@LastUpdatedByUserID", dto.LastUpdatedByUserID);
            p.AddWithValue("@DateLastUpdated", DateTime.Now);
            p.AddWithValue("@Verified", dto.Verified);
            p.AddWithValue("@IdentityVal", 0, SqlDbType.Int, ParameterDirection.Output);

            return SaveCommand("SaveUser", p);
        }

        public bool SaveProfile(ref UserDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@tblUserID", dto.tblUserID);
            p.AddWithValue("@Email", dto.Email);
            p.AddWithValue("@Alias", dto.Alias);
            p.AddWithValue("@FirstName", dto.FirstName);
            p.AddWithValue("@LastName", dto.LastName);
            p.AddWithValue("@IdentityVal", 0, SqlDbType.Int, ParameterDirection.Output);

            return SaveCommand("SaveProfile", p);
        }

        public bool SavePassword(ref UserDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@tblUserID", dto.tblUserID);
            p.AddWithValue("@Password", dto.Password);
            p.AddWithValue("@IdentityVal", 0, SqlDbType.Int, ParameterDirection.Output);

            return SaveCommand("SavePassword", p);
        }

        public bool SaveSearchRecords(ref SearchRecordsDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@ID", dto.ID);
            p.AddWithValue("@tblUserID", dto.tblUserID);
            p.AddWithValue("@ProgramName", dto.ProgramName);
            p.AddWithValue("@GrantSubject", dto.GrantSubject);
            p.AddWithValue("@AgencyName", dto.AgencyName);
            p.AddWithValue("@LastUpdated", dto.LastUpdated);
            p.AddWithValue("@CostShareType", dto.CostShareType);
            p.AddWithValue("@FundingType", dto.FundingType);
            p.AddWithValue("@IdentityVal", 0, SqlDbType.Int, ParameterDirection.Output);

            return SaveCommand("SaveSearchRecords", p);
        }

        public bool SaveGrantRecords(ref SearchGrantsDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@ID", dto.ID);
            p.AddWithValue("@tblUserID", dto.tblUserID);
            p.AddWithValue("@moreInfoID", dto.moreInfoID);
            p.AddWithValue("@IdentityVal", 0, SqlDbType.Int, ParameterDirection.Output);

            return SaveCommand("SaveGrantRecords", p);
        }

        public bool SaveGrants(ref GrantsDto dto)
        {
            SQLParamCollection p = new SQLParamCollection();
            p.AddWithValue("@ID", dto.ID);
            p.AddWithValue("@GrantID", dto.GrantID);
            p.AddWithValue("@ProgramName", dto.ProgramName);
            p.AddWithValue("@AgencyName", dto.AgencyName);
            p.AddWithValue("@ContactInformation", dto.ContactInformation);
            p.AddWithValue("@GrantSubject", dto.GrantSubject);
            p.AddWithValue("@EligibleActivities", dto.EligibleActivities);
            p.AddWithValue("@LastUpdated", dto.LastUpdated);
            p.AddWithValue("@CostShareType", dto.CostShareType);
            p.AddWithValue("@CostShareDescription", dto.CostShareDescription);
            p.AddWithValue("@OtherProgramCharacteristics", dto.OtherProgramCharacteristics);
            p.AddWithValue("@ApplicationDueDate", dto.ApplicationDueDate);
            p.AddWithValue("@DueDate", dto.DueDate);
            p.AddWithValue("@ApplicationSubType", dto.ApplicationSubType);
            p.AddWithValue("@FundingType", dto.FundingType);
            p.AddWithValue("@Active", dto.Active);
            p.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
            p.AddWithValue("@LastUpdatedByUserID", dto.LastUpdatedByUserID);
            p.AddWithValue("@IdentityVal", 0, System.Data.SqlDbType.Int, ParameterDirection.Output);


            return SaveCommand("SaveGrants", p);

        }
        
        private bool SaveCommand(string queryName, SQLParamCollection Params)
        {
            bool retVal = false;
            SqlParameter s = new SqlParameter();

            try
            {
                Identity = 0;
                Cmd = new SqlCommand(queryName, Conn);
                foreach (SqlParameter p in Params.ParamCollection)
                {
                    if (p.Direction == ParameterDirection.Output)
                    {
                        SqlParameter pOut = Cmd.CreateParameter();
                        pOut.ParameterName = p.ParameterName;
                        pOut.Direction = ParameterDirection.Output;
                        pOut.SqlDbType = p.SqlDbType;
                        Cmd.Parameters.Add(pOut);
                    }
                    else
                    {
                        if (p.SqlDbType == SqlDbType.NVarChar)
                        {
                            Cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                        }
                        else
                        {
                            SqlParameter sp = new SqlParameter
                            {
                                ParameterName = p.ParameterName,
                                Value = p.Value,
                                SqlDbType = p.SqlDbType
                            };
                            Cmd.Parameters.Add(sp);
                        }
                    }
                }

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.ExecuteNonQuery();
                retVal = true;
                Identity = Int32.Parse(Cmd.Parameters["@IdentityVal"].Value.ToString());
            }
            catch (Exception ex)
            {
                ErrMsg = "SaveCommand: " + Constants.vbCrLf + queryName + Constants.vbCrLf + ex.Message;
                l.LogIt(ErrMsg, true, "DB Error", Params);
            }
            return retVal;
        }
        #endregion

        /*This references the namespace here, when called as new it automatically connects to the SQL
        database and once established it can be used to execute stored procedures with the connection
        already in plac*/
        public GIDB()
        {
            try
            {
                Settings settings = new Settings();
                string sConnString = "";
                string eKey = "cT@7-0Xz6Y"; //randomly created key value from dto builder
                //The encrypted connection value should be available in myLocal.config
                //web.config include a reference for this.
                sConnString = Crypto.Decrypt(settings.MyConnection, eKey);
                this.Conn = new SqlConnection(sConnString);
                this.Conn.Open();
                this.RowCount = 0;
                this.Identity = 0;
            }
            catch (Exception ex)
            {
                throw (new Exception("Unable to connect to the database.  Please check your configuration settings or contact your adminstrator. : " + ex.ToString()));
            }
        }

    }
}