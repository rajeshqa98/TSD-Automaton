
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
	public class TSDCreateAccount_Page
	{

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
		
		public void TSD_CreateAccount()
		{
			Thread.Sleep(5);
			string strFirstName = browserActions.RandomString(10);
			String strMiddlename = browserActions.RandomString(10);
			browserActions.SendKeys(input_FirstName, strFirstName);
			browserActions.SendKeys(input_MIddleName, strMiddlename);
			browserActions.Click(input_PhoneNumber, "input_PhoneNumber");
			browserActions.SendKeys(input_PhoneNumber, "9787941400");
			// browserActions.sendKeyswithJSE(input_PhoneNumber, "9787941400");
			browserActions.selectByVisibleText(select_PhoneType, "Mobile");// Work, Home
			browserActions.SendKeys(input_Email, "wmullek@tsdweb.com");
			browserActions.selectByVisibleText(select_Address_County, "United States");//
			browserActions.SendKeys(input_Address1, "1620 Turnpike Street");
			browserActions.SendKeys(input_Address2, "");
			browserActions.SendKeys(input_City, "North Andover");
			browserActions.selectByVisibleText(input_State, "Massachusetts");
			browserActions.SendKeys(input_Zip, "01845");
			browserActions.SendKeys(input_licenceNumber, "65564877");
			browserActions.SendKeys(input_license_expiration, "10/18/2022");
			browserActions.SendKeys(input_dateOfBirth, "10/18/1974");
			browserActions.SendKeys(select_dl_County, "United States");
			browserActions.selectByVisibleText(select_dl_state, "Massachusetts");
			browserActions.SendKeys(input_Customer_Notes, "Test Notes");
			browserActions.SendKeys(input_EmployerName, "QualityMatrix");
			browserActions.SendKeys(input_InsuranceCompany, "Insurance Company");
			browserActions.SendKeys(input_PolicyNumber, "0123456789");
			browserActions.SendKeys(input_PolicyExpiryDate, "12/12/2022");
			browserActions.Click(input_InsranceNote, "input_InsranceNote");
			browserActions.SendKeys(input_InsranceNote, "Insurance Note");

		}	

		}
}
