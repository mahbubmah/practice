using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web
{
    public partial class UserRegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //LoadClientTypeDropDownInfo();

                    //Get countryIID for Location
                    int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    hdCountryID.Value = countryID.ToString();
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }

        }



        //private void LoadClientTypeDropDownInfo()
        //{
        //    try
        //    {
        //        DropDownListHelper.Bind(dropDownClientType, EnumHelper.EnumToList<EnumCollection.ClientType>());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public AdGiver CreateAdGiver()
        {
            AdGiver adgiver = new AdGiver();
            try
            {

                using (AdGiverRT adGiverRt = new AdGiverRT())
                {

                    bool IsThisEmailAlreadyExist = adGiverRt.GetAdGiverIDByEmail(txtEmail.Text) != null;
                    if (txtPassword.Text.Length < 6 || IsThisEmailAlreadyExist || (txtPassword.Text != txtConfirmPassword.Text) || txtPassword.Text == string.Empty || txtPassword.Text == "" || txtConfirmPassword.Text == "" || txtConfirmPassword.Text == string.Empty)
                    {
                        return null;
                    }

                    adgiver.Name = txtFirstName.Text + " " + txtLastname.Text;
                    adgiver.ClientTypeID = Convert.ToInt32(dropDownClientType.SelectedValue);

                    //if (txtNationalID.Text != "" && txtNationalID.Text != string.Empty)
                    //{
                    //    adgiver.NationalID = txtNationalID.Text;
                    //}

                    if (adgiver.ClientTypeID == Convert.ToInt32(EnumCollection.ClientType.OrganiztionOrCompany))
                    {
                        //adgiver.CompanyOrOrganizationName = txtCompanyName.Text;
                        //adgiver.ComOrOrgAddress = txtCompanyAddress.Text;
                        //adgiver.ComOrOrgPhone = txtCompanyPhoneNo.Text;
                    }

                    adgiver.EmailID = txtEmail.Text;
                    adgiver.PhoneNo1 = txtContactNo.Text;

                    //if (txtNationalID.Text != "" && txtNationalID.Text != string.Empty)
                    //{
                    //    //adgiver.PhoneNo2 = txtPhNoOptional.Text;
                    //}


                    //if (txtLocationID.Text != "" || txtLocationID.Text != string.Empty)
                    //{
                    //    adgiver.LocationID = Convert.ToInt64(txtLocationID.Text);
                    //}
                    //else
                    //{
                        //try
                        //{
                        //    using (LocationRT aLocationRt = new LocationRT())
                        //    {
                        //        Location aLocation = new Location();
                        //        if (txtLocation.Text != "" || txtLocation.Text != string.Empty)
                        //        {
                        //            aLocation.CurrentLocation = txtLocation.Text;
                        //            aLocation.DistrictID = Convert.ToInt64(txtDistrictID.Text.Trim() != null ? txtDistrictID.Text.Trim() : null);
                        //            aLocation.PoliceStationID = Convert.ToInt64(txtPoliceStationID.Text.Trim() != null ? txtPoliceStationID.Text.Trim() : null);
                        //            aLocation.CountryID = Convert.ToInt32(hdCountryID.Value);
                        //            aLocation.CurrentLocation = txtLocation.Text;
                        //            aLocationRt.AddLocation(aLocation);
                        //            adgiver.LocationID = aLocation.IID;
                        //        }
                        //    }
                        //}
                        //catch (Exception exception)
                        //{
                        //    throw new Exception(exception.Message, exception);
                        //}

                    //}
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return adgiver;
        }


        private UserInfo CreateUserInfo(Int64 adGiverID)
        {
            var aUserInfo = new UserInfo();

            try
            {
                aUserInfo.AdGiverID = adGiverID;
                aUserInfo.LoginName = txtEmail.Text.Trim();
                using (var aUserGroupRt=new UserGroupRT())
                {
                    var userGroup=aUserGroupRt.GetUserGroupAll();
                    aUserInfo.UserGroupID =userGroup.FirstOrDefault(x => x.TypeID == Convert.ToInt32(EnumCollection.UserGrpType.Add_Giver)).IID;
                }
             
                aUserInfo.IsActiveUser = true;

                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    var encriptedPass = txtPassword.Text.Trim();
                    encriptedPass = StringCipher.Encrypt(encriptedPass);
                    var salt = StringCipher.Salt;

                    aUserInfo.Salt = salt;
                    aUserInfo.LoginPassword = encriptedPass;
                }
                //if (chkEmail.Checked == true)
                //{
                //    aUserInfo.IsEmail = chkEmail.Checked;
                //}
                aUserInfo.IsEmail = chkEmail.Checked;
                aUserInfo.IsSMS = chkSMS.Checked;
                aUserInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                aUserInfo.CreatedDate = GlobalRT.GetServerDateTime();
                aUserInfo.IsRemoved = false;


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }


            return aUserInfo;


        }

        public void ClearField()
        {
            txtFirstName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtConEmailAdd.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
           // txtConfirmPassword.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            dropDownClientType.SelectedValue = "-1";

            //txtNationalID.Text = string.Empty;
            //txtCompanyName.Text = string.Empty;
            //txtCompanyAddress.Text = string.Empty;
            //txtCompanyPhoneNo.Text = string.Empty;
           
            //txtPhNoOptional.Text = string.Empty;
            //txtLocation.Text = string.Empty;
            //txtDistrict.Text = string.Empty;
            //txtPoliceStation.Text = string.Empty;
           
        }


        protected void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdGiverRT adGiverRt = new AdGiverRT())
                {
                    UserInformationRT aUserInformationRt = new UserInformationRT();
                    UserInfo aUserInfo = new UserInfo();
                    AdGiver adGiver = new AdGiver();
                    adGiver = CreateAdGiver();
                    if (adGiver != null)
                    {
                       // const int userInGroup = 7; //for addgiver
                        adGiverRt.AddAdGiver(adGiver);
                        aUserInfo = CreateUserInfo(adGiver.IID);
                        aUserInformationRt.AddUserInfo(aUserInfo);

                    }
                    else
                    {
                        if (txtPassword.Text == string.Empty || txtPassword.Text == "")
                        {
                            labelMessage.Text = "Please enter your password";
                        }
                        else if (txtConfirmPassword.Text == "" || txtConfirmPassword.Text == string.Empty)
                        {
                            labelMessage.Text = "Please comfirm your password";
                        }
                        else if (txtPassword.Text != txtConfirmPassword.Text)
                        {
                            labelMessage.Text = "password doesn't match";
                        }
                        else if (txtPassword.Text.Length < 6)
                        {
                            labelMessage.Text = "password too short, enter at least 6 character";
                        }
                        else
                        {
                            labelMessage.Text = string.Format("The email address {0} already registered ",
                                txtEmail.Text.Trim());
                        }
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        //ClearField();
                        return;
                    }

                    labelMessage.Text = "you have registered successfully...and your user ID is " + adGiver.EmailID;
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                    ClearField();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearField();
                Response.Redirect("~/Default");
            }
            catch(Exception ex)
            {

            }
        }

    }
}