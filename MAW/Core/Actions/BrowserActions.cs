using MAW.Core.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace MAW.Core.Actions
{
    class BrowserActions
    {
    
        public static ReadOnlyCollection<IWebElement> elements(By locator)
        {
           return Browser.GetBrowser().FindElements(locator);

        }

        public static IWebElement element(By locator) {
             return Browser.Wait()
                .Until(el => el.FindElement(locator));
        }
      public static void Click(By locator)
        {
            element(locator).Click();
       }

        public static void ClickJS(By locator)
        {
           // NSelene.Selene.GetWebBrowser.GetBrowser()();
            //NSelene.Selene.ExecuteScript("arg[0].click();",locator);
        }

        public static void ClearAndSendKey(By locator)
        {
           /* NSelene.Selene
                .GetWebBrowser.GetBrowser()()
                .FindElement(locator).Click();*/
            //NSelene.Selene.ExecuteScript("arg[0].click();",locator);
        }

		IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)Browser.GetBrowser();
		//Actions action = new Actions(Browser.GetBrowser());

		/**
		 * =============================================================================
		 * Method: waitForVisible | Author: Rajesh Buddha | Date:16 Jan 2020 |
		 * Description: This method wait for element it will check every 5 sec its
		 * present or not until 60 sec | Parameters: locator | Return: element
		 * =============================================================================
		 */
		public static bool WaitForElementToBeVisible(By by)
		{
			int attemptToFindElement = 0;
			bool elementFound = false;
			IWebElement elementIdentifier = null;
			do
			{
				attemptToFindElement++;
				try
				{
					elementIdentifier = Browser.GetBrowser().FindElement(by);
					elementFound = (elementIdentifier.Displayed && elementIdentifier.Enabled) ? true : false;
				}
				catch (Exception)
				{
					elementFound = false;
				}

			}
			while (elementFound == false && attemptToFindElement < 60);

			return elementFound;
		}


		/**
		 * =============================================================================
		 * Method: openURL | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method open url | Parameters: URL | Return: none
		 * =============================================================================
		 */
		public void openURL(string URL)
		{
			Browser.GetBrowser().Navigate().GoToUrl(URL);
			string strURL = Browser.GetBrowser().Url;
			
			WebReporter.Log.Info("Successfully Entered URL - " + "<b style=\"color:green;\">" + URL + "</b>");
			Console.WriteLine("Successfully Entered URL - " + URL);
		}

		/**
		 * =============================================================================
		 * Method: Click | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method click on element | Parameters: locator, info | Return: none
		 * =============================================================================
		 */
		public void Click(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Click();
			WebReporter.Log.Info("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
			Console.WriteLine("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
		}

		/**
		 * =============================================================================
		 * Method: Click | Author: Rajesh Buddha | Date:16 Jan 2020 | Description: This
		 * method click on element | Parameters: locator, info | Return: none
		 * =============================================================================
		 */
		public void ClickJSE(By locator, String info)
		{
			WaitForElementToBeVisible(locator);
			javascriptExecutor.ExecuteScript("arguments[0].click();", Browser.GetBrowser().FindElement(locator));
			WebReporter.Log.Info("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
			Console.WriteLine("Successfully clicked on - " + "<b style=\"color:green;\">" + info + "</b>");
		}

		/**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
		public void SendKeys(By locator, String text)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).Click();
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
			Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
		}

		/**
		 * =============================================================================
		 * Method: sendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method enter text input text using element | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 */
		public void sendKeyswithoutClick(By locator, String text)
		{
			WaitForElementToBeVisible(locator);
			Browser.GetBrowser().FindElement(locator).SendKeys(text);
			WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
			Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
		}

		/**
		 * =============================================================================
		 * Method: fileUploadsendKeys | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
		 * This method upload file | Parameters: locator, text |
		 * Return: none
		 * =============================================================================
		 * @throws IOException 
		 */
		/*public void fileUploadsendKeys(By locator, String path){
		WaitForElementToBeVisible(locator);
		Thread.Sleep(2000);
		File f = new File(path); //file name will be entered by user at runtime
      //  Console.WriteLine(f.exists()); //will print "true" if the file name given by user exists, false otherwise

        if(f.exists())
        {
        	Browser.GetBrowser().FindElement(locator).Click();
        	Console.WriteLine("File exists at give path");
		StringSelection ss = new StringSelection(path);
		Toolkit.getDefaultToolkit().getSystemClipboard().setContents(ss, null); // copy the above string to clip board
		Robot robot;
		robot = new Robot();
		robot.delay(1000);
    		robot.keyPress(KeyEvent.VK_ENTER);
    		robot.keyRelease(KeyEvent.VK_ENTER);
    		robot.delay(2000);
    		robot.keyPress(KeyEvent.VK_CONTROL);
    		robot.keyPress(KeyEvent.VK_V);
    		robot.keyRelease(KeyEvent.VK_V);
    		robot.delay(2000);
    		robot.keyRelease(KeyEvent.VK_CONTROL); // paste the copied string into the dialog box
    		robot.keyPress(KeyEvent.VK_ENTER);
    		robot.keyRelease(KeyEvent.VK_ENTER); // enter
        }else {
        	BufferedImage image = new Robot().createScreenCapture(new Rectangle(Toolkit.getDefaultToolkit().getScreenSize()));
	ImageIO.write(image, "png", new File("D:\\POCs\\Maxval\\Reports\\Screenshots\\screenshot.png"));
        	Console.WriteLine("File Not exists at give pat");
	ReportManager.logScreenshotInfo();
        	ReportManager.logFail("File Not exists at give path");;
    		assertEquals(f.exists(), true);
}
		
		
	}*/

	/**
	 * =============================================================================
	 * Method: sendKeysfromKeyboard | Author: Rajesh Buddha | Date:16 Jan 2020 | Description:
	 * This method will keyboard actions | Parameters: locator, text |
	 * Return: none
	 * =============================================================================
	 */
	public void sendKeysfromKeyboard(By locator, string keyboardAction)
{
	WaitForElementToBeVisible(locator);
	Browser.GetBrowser().FindElement(locator).SendKeys(keyboardAction+ Keys.Enter);
	WebReporter.Log.Info("Successfully Entered text - " + keyboardAction);
	Console.WriteLine("Successfully Entered text - " + keyboardAction);
}

public Boolean isDisplayed(By locator, String info)
{
	WaitForElementToBeVisible(locator);
			Boolean isPresent = Browser.GetBrowser().FindElement(locator).Displayed;
	if (isPresent)
	{
		WebReporter.Log.Info("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
		Console.WriteLine("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
	}
	else
	{
		WebReporter.Log.Info("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
		Console.WriteLine("element not displayed: " + info);
	}
	return isPresent;
}

public Boolean isEnabled(By locator, String info)
{
	WaitForElementToBeVisible(locator);
			Boolean isPresent = Browser.GetBrowser().FindElement(locator).Enabled;
	if (isPresent)
	{
		WebReporter.Log.Info("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
		Console.WriteLine("Successfully element displayed: " + "<b style=\"color:green;\">" + info + "</b>");
	}
	else
	{
		WebReporter.Log.Info("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
		Console.WriteLine("element not displayed: " + "<b style=\"color:green;\">" + info + "</b>");
	}
	return isPresent;
}

public void clearAndSendKeys(By locator, String text)
{
	WaitForElementToBeVisible(locator);
	Browser.GetBrowser().FindElement(locator).Clear();
	Browser.GetBrowser().FindElement(locator).SendKeys(text);
	WebReporter.Log.Info("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
	Console.WriteLine("Successfully Entered text - " + "<b style=\"color:green;\">" + text + "</b>");
}

public void verifyText(String actualText, String expectedText)
{
	WebReporter.Log.Info("Actual Text - " + "<b style=\"color:green;\">" + actualText + "</b>");
	WebReporter.Log.Info("Expected Text - " + "<b style=\"color:green;\">" + expectedText + "</b>");
	Console.WriteLine("Actual Text - " + actualText);
	Console.WriteLine("Expected Text - " + expectedText);
	Assert.AreEqual(expectedText, actualText);
}

public void verifyIntValues(int actualValue, int expectedValue)
{
	WebReporter.Log.Info("Actual Value - " + actualValue);
	WebReporter.Log.Info("Expected Value - " + expectedValue);
	Console.WriteLine("Actual Value - " + actualValue);
	Console.WriteLine("Expected Value - " + expectedValue);
	Assert.AreEqual(actualValue, expectedValue);
}

public String getAttributeValue(By locator, String name)
{
	WaitForElementToBeVisible(locator);
	String attributeText = Browser.GetBrowser().FindElement(locator).GetAttribute(name);
	WebReporter.Log.Info("Successfully get attribute text - " + attributeText);
	Console.WriteLine("Successfully get attribute text - " + attributeText);
	return attributeText;
}

public Boolean isScrollPresent()
{
	String execScript = "return document.documentElement.scrollHeight>document.documentElement.clientHeight;";
	Boolean isScroll_Present = (Boolean) (javascriptExecutor.ExecuteScript(execScript));
		return isScroll_Present;

}

public void scrollDownUsingJS()
{

	javascriptExecutor.ExecuteScript(
			"window.scrollBy(0,document.body.scrollHeight || document.documentElement.scrollHeight)", "");
}

/*public void mouseHover(By locator)
{
			WaitForElementToBeVisible(locator);
	action.moveToElement(Browser.GetBrowser().FindElement(locator)).build().perform();
	String Browser.GetBrowser().FindElement(locator)Text = Browser.GetBrowser().FindElement(locator).getText();
	WebReporter.Log.Info("Successfully mouse hover and get text - " + Browser.GetBrowser().FindElement(locator)Text);
	Console.WriteLine("Successfully mouse hover and get text - " + Browser.GetBrowser().FindElement(locator)Text);
}*/

public void switchToFrame(By locator)
{
	WaitForElementToBeVisible(locator);
	Browser.GetBrowser().SwitchTo().Frame(Browser.GetBrowser().FindElement(locator));
	WebReporter.Log.Info("Successfully switched to frame ");
	Console.WriteLine("Successfully switched to frame ");
}

public ReadOnlyCollection<IWebElement> getListofElements(By locator, String name)
{
	WaitForElementToBeVisible(locator);
	ReadOnlyCollection<IWebElement> lst_Elements = Browser.GetBrowser().FindElements(locator);
	WebReporter.Log.Info("Successfully get element size - " + lst_Elements.Count);
	Console.WriteLine("Successfully get element size - " + lst_Elements.Count);
	return lst_Elements;
}

public void selectByVisibleText(By locator, string value)
{
	WaitForElementToBeVisible(locator);
	IWebElement selElm = Browser.GetBrowser().FindElement(locator);
	SelectElement SelectAnEducation = new SelectElement(selElm);
	SelectAnEducation.SelectByText(value);
	WebReporter.Log.Info("Successfully selected dropdown value - " + "<b style=\"color:green;\">" + value + "</b>");

}

public void switchTab()
{
			WebDriverWait wait = new WebDriverWait(Browser.GetBrowser(), TimeSpan.FromSeconds(10));

			string originalWindow = Browser.GetBrowser().CurrentWindowHandle;

			//Check we don't have other windows open already
			Assert.AreEqual(Browser.GetBrowser().WindowHandles.Count, 1);

			//Click the link which opens in a new window
			Browser.GetBrowser().FindElement(By.LinkText("new window")).Click();

			//Wait for the new window or tab

			wait.Until(wd => wd.WindowHandles.Count == 2);

			//Loop through until we find a new window handle
			foreach (string window in Browser.GetBrowser().WindowHandles)
			{
				if (originalWindow != window)
				{
					Browser.GetBrowser().SwitchTo().Window(window);
					break;
				}
			}
			//Wait for the new tab to finish loading content
			wait.Until(wd => wd.Title == "Selenium documentation");
		}

public void switchDefaultWindow()
{

	Browser.GetBrowser().SwitchTo().DefaultContent();

}

		private Random random = new Random();
		public string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

	}
}
