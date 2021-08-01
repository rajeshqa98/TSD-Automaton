using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MAW.Core.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TSW_Web_UI_Automation.TSDPageObjetPages
{
	public class TSDHome_Page
	{
		// ==================Login======================
		By tsd_Logo = By.XPath("//img[@alt=\"TSD Fleet Management\"]");
		By txt_Login = By.XPath("//h2[contains(.,'Login')]");
		By input_tsdnumber = By.Id("tsd_elmt_cust");
		By input_usernmae = By.Id("tsd_elmt_user");
		By input_password = By.Id("tsd_elmt_pw");
		By btn_login = By.Id("tsd_login_btn");
		By btn_dialog_Cancel = By.Id("tsd-dialog-cancel");
		By txt_TSDID = By.XPath("//*[@id=\"tsd-header\"]/div/div[2]/span[1]");

		// ==================Logout======================
		By btn_Logout = By.XPath("(//span[contains(.,'Log Out')])[1]");

		// ========================Create Account=================
		By btn_New = By.Id("tsd-floating-button");
		By lnk_NewAppointment = By.Id("tsd-new-reservation");
		By btn_Loaner = By.XPath("//button[contains(.,'Loaner')]");
		By input_FirstName = By.XPath("//input[@data-qa=\"firstName\"]");
		By input_LastName = By.XPath("//input[@data-qa=\"lastName\"]");
		By input_MIddleName = By.Id("tsd_elmt_3");
		By input_PhoneNumber = By.XPath("//input[@data-qa=\"phone\"]");
		By select_PhoneType = By.XPath("//label[contains(.,'Phone Type')]/../select");
		By input_Email = By.XPath("//input[@data-qa=\"email\"]");
		By select_Address_County = By.XPath("(//select[@data-qa=\"countries\"])[1]");
		By input_Address1 = By.Id("address1");
		By input_Address2 = By.Id("address2");
		By input_City = By.Id("city");
		By input_State = By.XPath("(//select[@data-qa=\"regions\"])[1]");
		By input_Zip = By.XPath("//input[@data-qa=\"postalCode\"]");
		By input_licenceNumber = By.Id("driver-license-number");
		By input_license_expiration = By.Id("license-expiration");
		By input_dateOfBirth = By.Id("dateOfBirth");
		By select_dl_County = By.Id("countries");
		By select_dl_state = By.Id("regions");
		By input_Customer_Notes = By.XPath("//textarea[@data-qa=\"patron-notes\"]");
		By input_EmployerName = By.XPath("//input[@data-qa=\"employerName\"]");
		By input_insurance_company = By.Id("insurance-company");
		By input_policy_number = By.Id("policy-number");
		By input_insurance_expiration_date = By.Id("insurance-expiration-date");
		By input_insurance_Note = By.XPath("//textarea[@data-qa=\"insurance-notes\"]");
		By input_InsuranceCompany = By.XPath("//input[@data-qa=\"insurance-company\"]");
		By input_PolicyNumber = By.XPath("//input[@data-qa=\"policy-number\"]");
		By input_PolicyExpiryDate = By.XPath("//input[@data-qa=\"insurance-expiration-date\"]");
		By input_InsranceNote = By.XPath("//textarea[@data-qa=\"insurance-notes\"]");
		By btn_Continue = By.XPath("//button[contains(.,'Continue')]");

		BrowserActions browserActions = new BrowserActions();
		
		public void TSD_Login()
		{
			
			//ReportManager.test.Log(Status.Info, "Navigated To URL");
			browserActions.Click(input_tsdnumber, "input_tsdnumber");
			browserActions.SendKeys(input_tsdnumber, "radrive9");
			browserActions.Click(input_usernmae, "input_usernmae");
			browserActions.SendKeys(input_usernmae, "rbuddha");
			browserActions.Click(input_password, "input_password");
			browserActions.SendKeys(input_password, "Quality@123");
			browserActions.Click(btn_login, "Login button");

		}

		public void TSD_Logout()
		{
			Thread.Sleep(5);
			browserActions.Click(btn_Logout, "Logout button");

		}


	}
}
