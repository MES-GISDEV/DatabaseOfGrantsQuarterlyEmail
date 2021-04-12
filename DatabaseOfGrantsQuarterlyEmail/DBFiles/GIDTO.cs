using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;

namespace GrantsIdentification
{

    #region UserDto

    public class UserDto
    {

        #region Properties
        private object itblUserID = 0;
        private object sEmail;
        private object sPassword;
        private object sAlias;
        private object sFirstName;
        private object sLastName;
        private object iluRoleID;
        private object sOrganizationShortName;
        private object sOrganizationFullName;
        private object bActive;
        private object iCreatedByUserID;
        private object dDateCreated;
        private object iLastUpdatedByUserID;
        private object dDateLastUpdated;
        private object bVerified;

        public object tblUserID
        {
            get
            {
                if (itblUserID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return itblUserID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        itblUserID = x;
                    }
                    else
                    {
                        throw new Exception("tblUserID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    itblUserID = null;
                }
            }
        }

        public object Email
        {
            get
            {
                if (sEmail == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sEmail;
                }
            }
            set
            {
                sEmail = value;
            }
        }

        public object Password
        {
            get
            {
                if (sPassword == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sPassword;
                }
            }
            set
            {
                sPassword = value;
            }
        }

        public object Alias
        {
            get
            {
                if (sAlias == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sAlias;
                }
            }
            set
            {
                sAlias = value;
            }
        }

        public object FirstName
        {
            get
            {
                if (sFirstName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sFirstName;
                }
            }
            set
            {
                sFirstName = value;
            }
        }

        public object LastName
        {
            get
            {
                if (sLastName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sLastName;
                }
            }
            set
            {
                sLastName = value;
            }
        }

        public object luRoleID
        {
            get
            {
                if (iluRoleID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iluRoleID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iluRoleID = x;
                    }
                    else
                    {
                        throw new Exception("luRoleID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iluRoleID = null;
                }
            }
        }

        public object OrganizationShortName
        {
            get
            {
                if (sOrganizationShortName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sOrganizationShortName;
                }
            }
            set
            {
                sOrganizationShortName = value;
            }
        }

        public object OrganizationFullName
        {
            get
            {
                if (sOrganizationFullName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sOrganizationFullName;
                }
            }
            set
            {
                sOrganizationFullName = value;
            }
        }

        public object Active
        {
            get
            {
                if ((bActive == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return bActive;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (bool.TryParse(value.ToString(), out bool x))
                    {
                        bActive = x;
                    }
                    else
                    {
                        throw new Exception(("Active - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type Boolean.")));
                    }

                }
                else
                {
                    bActive = null;
                }

            }
        }

        public object CreatedByUserID
        {
            get
            {
                if (iCreatedByUserID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iCreatedByUserID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iCreatedByUserID = x;
                    }
                    else
                    {
                        throw new Exception("CreatedByUserID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iCreatedByUserID = null;
                }
            }
        }

        public object DateCreated
        {
            get
            {
                if ((dDateCreated == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return dDateCreated;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                    {
                        dDateCreated = x;
                    }
                    else
                    {
                        throw new Exception(("DateCreated - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type DateTime.")));
                    }

                }
                else
                {
                    dDateCreated = null;
                }

            }
        }

        public object LastUpdatedByUserID
        {
            get
            {
                if (iLastUpdatedByUserID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iLastUpdatedByUserID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iLastUpdatedByUserID = x;
                    }
                    else
                    {
                        throw new Exception("LastUpdatedByUserID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iLastUpdatedByUserID = null;
                }
            }
        }

        public object DateLastUpdated
        {
            get
            {
                if ((dDateLastUpdated == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return dDateLastUpdated;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                    {
                        dDateLastUpdated = x;
                    }
                    else
                    {
                        throw new Exception(("DateLastUpdated - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type DateTime.")));
                    }

                }
                else
                {
                    dDateLastUpdated = null;
                }

            }
        }

        public object Verified
        {
            get
            {
                if ((bVerified == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return bVerified;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (bool.TryParse(value.ToString(), out bool x))
                    {
                        bVerified = x;
                    }
                    else
                    {
                        throw new Exception(("Verified - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type Boolean.")));
                    }

                }
                else
                {
                    bVerified = null;
                }

            }
        }

        #endregion

        public void Populate(int ID)
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();

            try
            {
                DataSet ds = db.SelectByIDUsers(ID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    this.tblUserID = Convert.ToInt32(dr["tblUserID"]);
                    this.Email = Convert.ToString(dr["Email"]);
                    this.Alias = Convert.ToString(dr["Alias"]);
                    this.FirstName = Convert.ToString(dr["FirstName"]);
                    this.LastName = Convert.ToString(dr["LastName"]);
                    this.luRoleID = Convert.ToInt32(dr["luRoleID"]);
                    this.OrganizationShortName = Convert.ToString(dr["OrganizationShortName"]);
                    this.OrganizationFullName = Convert.ToString(dr["OrganizationFullName"]);
                    this.Active = Convert.ToBoolean(dr["Active"]);
                    this.CreatedByUserID = Convert.ToString(dr["CreatedByUserID"]);
                    this.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                    this.LastUpdatedByUserID = Convert.ToString(dr["LastUpdatedByUserID"]);
                    this.DateLastUpdated = Convert.ToDateTime(dr["DateLastUpdated"]);
                    this.Verified = Convert.ToBoolean(dr["Verified"]);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error UserDTO.Populate: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
        }

        public bool Save()
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();
            bool retval = false;

            try
            {
                UserDto obj = this;
                retval = db.SaveUser(ref obj);
                this.tblUserID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("UserDto.Save: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
            return retval;
        }

        public bool SaveProf()
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();
            bool retval = false;

            try
            {
                UserDto obj = this;
                retval = db.SaveProfile(ref obj);
                this.tblUserID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("UserDto.SaveProfile: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
            return retval;
        }

        public bool SavePasswordChange()
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();
            bool retval = false;

            try
            {
                UserDto obj = this;
                retval = db.SavePassword(ref obj);
                this.tblUserID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("UserDto.SavePasswordChange: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
            return retval;
        }

    }

    #endregion

    #region GrantsDto



public class GrantsDto
    {
        //private readonly GIDB objdb;

        private object iID = 0;
        private object iGrantID;
        private object sProgramName;
        private object sAgencyName;
        private object sContactInformation;
        private object sGrantSubject;
        private object sEligibleActivities;
        private object sLastUpdated;
        private object sCostShareType;
        private object sCostShareDescription;
        private object sOtherProgramCharacteristics;
        private object sApplicationDueDate;
        private object dDueDate;
        private object sApplicationSubType;
        private object sFundingType;
        private object bActive;
        private object sCreatedByUserID;
        private object dDateCreated;
        private object sLastUpdatedByUserID;
        private object dDateLastUpdated;

        public object ID
        {
            get
            {
                if (iID == null)
                    return DBNull.Value;
                else
                    return iID;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                        iID = x;
                    else
                        throw new Exception("ID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                }
                else
                    iID = null;
            }
        }

        public object GrantID
        {
            get
            {
                if (iGrantID == null)
                    return DBNull.Value;
                else
                    return iGrantID;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                        iGrantID = x;
                    else
                        throw new Exception("GrantID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                }
                else
                    iGrantID = null;
            }
        }

        public object ProgramName
        {
            get
            {
                if (sProgramName == null)
                    return DBNull.Value;
                else
                    return sProgramName;
            }
            set
            {
                sProgramName = value.ToString();
            }
        }

        public object AgencyName
        {
            get
            {
                if (sAgencyName == null)
                    return DBNull.Value;
                else
                    return sAgencyName;
            }
            set
            {
                sAgencyName = value.ToString();
            }
        }

        public object ContactInformation
        {
            get
            {
                if (sContactInformation == null)
                    return DBNull.Value;
                else
                    return sContactInformation;
            }
            set
            {
                sContactInformation = value.ToString();
            }
        }

        public object GrantSubject
        {
            get
            {
                if (sGrantSubject == null)
                    return DBNull.Value;
                else
                    return sGrantSubject;
            }
            set
            {
                sGrantSubject = value.ToString();
            }
        }

        public object EligibleActivities
        {
            get
            {
                if (sEligibleActivities == null)
                    return DBNull.Value;
                else
                    return sEligibleActivities;
            }
            set
            {
                sEligibleActivities = value.ToString();
            }
        }

        public object LastUpdated
        {
            get
            {
                if (sLastUpdated == null)
                    return DBNull.Value;
                else
                    return sLastUpdated;
            }
            set
            {
                sLastUpdated = value.ToString();
            }
        }

        public object CostShareType
        {
            get
            {
                if (sCostShareType == null)
                    return DBNull.Value;
                else
                    return sCostShareType;
            }
            set
            {
                sCostShareType = value.ToString();
            }
        }

        public object CostShareDescription
        {
            get
            {
                if (sCostShareDescription == null)
                    return DBNull.Value;
                else
                    return sCostShareDescription;
            }
            set
            {
                sCostShareDescription = value.ToString();
            }
        }

        public object OtherProgramCharacteristics
        {
            get
            {
                if (sOtherProgramCharacteristics == null)
                    return DBNull.Value;
                else
                    return sOtherProgramCharacteristics;
            }
            set
            {
                sOtherProgramCharacteristics = value.ToString();
            }
        }

        public object ApplicationDueDate
        {
            get
            {
                if (sApplicationDueDate == null)
                    return DBNull.Value;
                else
                    return sApplicationDueDate;
            }
            set
            {
                sApplicationDueDate = value.ToString();
            }
        }

        public object DueDate
        {
            get
            {
                if (dDueDate == null)
                    return DBNull.Value;
                else
                    return dDueDate;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                        dDueDate = x;
                    else
                        throw new Exception("DueDate - Invalid data type.  '" + value.ToString() + "' is not of type DateTime.");
                }
                else
                    dDueDate = null;
            }
        }

        public object ApplicationSubType
        {
            get
            {
                if (sApplicationSubType == null)
                    return DBNull.Value;
                else
                    return sApplicationSubType;
            }
            set
            {
                sApplicationSubType = value.ToString();
            }
        }

        public object FundingType
        {
            get
            {
                if (sFundingType == null)
                    return DBNull.Value;
                else
                    return sFundingType;
            }
            set
            {
                sFundingType = value.ToString();
            }
        }

        public object Active
        {
            get
            {
                if (bActive == null)
                    return DBNull.Value;
                else
                    return bActive;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (bool.TryParse(value.ToString(), out bool x))
                        bActive = x;
                    else
                        throw new Exception("Active - Invalid data type.  '" + value.ToString() + "' is not of type Boolean.");
                }
                else
                    bActive = null;
            }
        }

        public object CreatedByUserID
        {
            get
            {
                if (sCreatedByUserID == null)
                    return DBNull.Value;
                else
                    return sCreatedByUserID;
            }
            set
            {
                sCreatedByUserID = value.ToString();
            }
        }

        public object DateCreated
        {
            get
            {
                if (dDateCreated == null)
                    return DBNull.Value;
                else
                    return dDateCreated;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                        dDateCreated = x;
                    else
                        throw new Exception("DateCreated - Invalid data type.  '" + value.ToString() + "' is not of type DateTime.");
                }
                else
                    dDateCreated = null;
            }
        }

        public object LastUpdatedByUserID
        {
            get
            {
                if (sLastUpdatedByUserID == null)
                    return DBNull.Value;
                else
                    return sLastUpdatedByUserID;
            }
            set
            {
                sLastUpdatedByUserID = value.ToString();
            }
        }

        public object DateLastUpdated
        {
            get
            {
                if (dDateLastUpdated == null)
                    return DBNull.Value;
                else
                    return dDateLastUpdated;
            }
            set
            {
                if (!(value == DBNull.Value) & !(value == null))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                        dDateLastUpdated = x;
                    else
                        throw new Exception("DateLastUpdated - Invalid data type.  '" + value.ToString() + "' is not of type DateTime.");
                }
                else
                    dDateLastUpdated = null;
            }
        }

        public void Populate(ref int ID, ref GIDB db)
        {
            bool bDBIsNothing = db == null;
            if (bDBIsNothing)
                db = new GIDB();

            try
            {
                DataSet ds = db.SelectByIDGrants(ID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    this.ID = dr["ID"];
                    this.GrantID = dr["GrantID"];
                    this.ProgramName = dr["ProgramName"];
                    this.AgencyName = dr["AgencyName"];
                    this.ContactInformation = dr["ContactInformation"];
                    this.GrantSubject = dr["GrantSubject"];
                    this.EligibleActivities = dr["EligibleActivities"];
                    this.LastUpdated = dr["LastUpdated"];
                    this.CostShareType = dr["CostShareType"];
                    this.CostShareDescription = dr["CostShareDescription"];
                    this.OtherProgramCharacteristics = dr["OtherProgramCharacteristics"];
                    this.ApplicationDueDate = dr["ApplicationDueDate"];
                    this.DueDate = dr["DueDate"];
                    this.ApplicationSubType = dr["ApplicationSubType"];
                    this.FundingType = dr["FundingType"];
                    this.Active = dr["Active"];
                    this.CreatedByUserID = dr["CreatedByUserID"];
                    this.DateCreated = dr["DateCreated"];
                    this.LastUpdatedByUserID = dr["LastUpdatedByUserID"];
                    this.DateLastUpdated = dr["DateLastUpdated"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error GrantsDTO.Populate: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing)
                    db = null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public bool Save(GIDB db = null/* TODO Change to default(_) if this is not a reference type */)
        {
            bool bDBIsNothing = db == null;
            if (bDBIsNothing)
                db = new GIDB();
            bool retval = false;

            try
            {
                GrantsDto obj = this;
                retval = db.SaveGrants(ref obj);
                this.ID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("GrantsDto.Save: " + ex.Message + Constants.vbCrLf);
            }

            finally
            {
                if (bDBIsNothing)
                    db = null/* TODO Change to default(_) if this is not a reference type */;
            }

            return retval;
        }

        public bool UpdateActive(GIDB db = null/* TODO Change to default(_) if this is not a reference type */)
        {
            bool bDBIsNothing = db == null;
            if (bDBIsNothing)
                db = new GIDB();
            bool retval = false;

            try
            {
                GrantsDto obj = this;
                retval = db.UpdateGrantActive(ref obj);
                this.ID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("GrantsDto.Delete: " + ex.Message + Constants.vbCrLf);
            }

            finally
            {
                if (bDBIsNothing)
                    db = null/* TODO Change to default(_) if this is not a reference type */;
            }

            return retval;
        }
    }




    #endregion

    #region SearchRecordsDto

    public class SearchRecordsDto
    {

        #region Properties
        private object iID = 0;
        private object itblUserID;
        private object sProgramName;
        private object sGrantSubject;
        private object sAgencyName;
        private object sLastUpdated;
        private object sCostShareType;
        private object sFundingType;
        private object dCreatedAt;

        public object ID
        {
            get
            {
                if (iID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iID = x;
                    }
                    else
                    {
                        throw new Exception("ID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iID = null;
                }
            }
        }

        public object tblUserID
        {
            get
            {
                if (itblUserID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return itblUserID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        itblUserID = x;
                    }
                    else
                    {
                        throw new Exception("tblUserID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    itblUserID = null;
                }
            }
        }

        public object ProgramName
        {
            get
            {
                if (sProgramName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sProgramName;
                }
            }
            set
            {
                sProgramName = value;
            }
        }

        public object GrantSubject
        {
            get
            {
                if (sGrantSubject == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sGrantSubject;
                }
            }
            set
            {
                sGrantSubject = value;
            }
        }

        public object AgencyName
        {
            get
            {
                if (sAgencyName == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sAgencyName;
                }
            }
            set
            {
                sAgencyName = value;
            }
        }

        public object LastUpdated
        {
            get
            {
                if (sLastUpdated == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sLastUpdated;
                }
            }
            set
            {
                sLastUpdated = value;
            }
        }

        public object CostShareType
        {
            get
            {
                if (sCostShareType == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sCostShareType;
                }
            }
            set
            {
                sCostShareType = value;
            }
        }

        public object FundingType
        {
            get
            {
                if (sFundingType == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return sFundingType;
                }
            }
            set
            {
                sFundingType = value;
            }
        }

        public object CreatedAt
        {
            get
            {
                if ((dCreatedAt == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return dCreatedAt;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                    {
                        dCreatedAt = x;
                    }
                    else
                    {
                        throw new Exception(("CreatedAt - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type DateTime.")));
                    }

                }
                else
                {
                    dCreatedAt = null;
                }

            }
        }

        #endregion

        public bool Save()
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();
            bool retval = false;

            try
            {
                SearchRecordsDto obj = this;
                retval = db.SaveSearchRecords(ref obj);
                this.ID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("SearchRecordsDto.Save: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
            return retval;
        }

    }

    #endregion

    #region SearchGrantsDto

    public class SearchGrantsDto
    {

        #region Properties
        private object iID = 0;
        private object itblUserID;
        private object iMoreInfoID;
        private object dCreatedAt;

        public object ID
        {
            get
            {
                if (iID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iID = x;
                    }
                    else
                    {
                        throw new Exception("ID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iID = null;
                }
            }
        }

        public object tblUserID
        {
            get
            {
                if (itblUserID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return itblUserID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        itblUserID = x;
                    }
                    else
                    {
                        throw new Exception("tblUserID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    itblUserID = null;
                }
            }
        }

        public object moreInfoID
        {
            get
            {
                if (iMoreInfoID == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return iMoreInfoID;
                }
            }
            set
            {
                if (!(value == DBNull.Value) && !(value == null))
                {
                    if (Int32.TryParse(value.ToString(), out int x))
                    {
                        iMoreInfoID = x;
                    }
                    else
                    {
                        throw new Exception("moreInfoID - Invalid data type.  '" + value.ToString() + "' is not of type Int32.");
                    }
                }
                else
                {
                    iMoreInfoID = null;
                }
            }
        }

        public object CreatedAt
        {
            get
            {
                if ((dCreatedAt == null))
                {
                    return DBNull.Value;
                }
                else
                {
                    return dCreatedAt;
                }

            }
            set
            {
                if ((!(value == DBNull.Value)
                            && !(value == null)))
                {
                    if (DateTime.TryParse(value.ToString(), out DateTime x))
                    {
                        dCreatedAt = x;
                    }
                    else
                    {
                        throw new Exception(("CreatedAt - Invalid data type.  \'"
                                        + (value.ToString() + "\' is not of type DateTime.")));
                    }

                }
                else
                {
                    dCreatedAt = null;
                }

            }
        }

        #endregion

        public bool Save()
        {
            GIDB db = new GIDB();
            bool bDBIsNothing = db == null;
            if (bDBIsNothing) db = new GIDB();
            bool retval = false;

            try
            {
                SearchGrantsDto obj = this;
                retval = db.SaveGrantRecords(ref obj);
                this.ID = db.Identity;
            }
            catch (Exception ex)
            {
                throw new Exception("GrantRecordsDto.Save: \r\n" + ex.Message);
            }
            finally
            {
                if (bDBIsNothing) db = null;
            }
            return retval;
        }

    }

    #endregion
    
}