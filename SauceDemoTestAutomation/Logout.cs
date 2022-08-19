using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoTestAutomation.BaseClass;
using AventStack.ExtentReports;

namespace SauceDemoTestAutomation
{
    [TestFixture]
    public class LogoutTests : BaseTest
    {
        public String currentURL = null;
        public String inventoryPage = "https://www.saucedemo.com/inventory.html";

        [Test]
        //Test Scenario: Successfully logout from the "standard_user" account
        public void StandardUserLogout()
        {  
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Standard User Logout").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;
                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                //Find the username field on the login page and key the username above in the text box
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                currentURL = cdriver.Url;
                if (currentURL == inventoryPage)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Standard user successfully logged in");
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Open the navigation side pane to access the logout link
                    cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Standard user clicked LOGOUT from side navigation pane");

                    currentURL = cdriver.Url;
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "Standard user successfully logged out");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                    }
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Standard user not redirected");
                    test.Log(AventStack.ExtentReports.Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Standard User unable to logout");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
            
        }

        [Test]
        //Test Scenario: Successfully logout from the "problem_user" account
        public void ProblemUserLogout()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Problem User Logout").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;
                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                //Find the username field on the login page and key the username above in the text box
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("problem_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                currentURL = cdriver.Url;
                if (currentURL == inventoryPage)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged in");
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Open the navigation side pane to access the logout link
                    cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Problem user clicked LOGOUT from side navigation pane");

                    currentURL = cdriver.Url;
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged out");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                    }
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Problem user not redirected");
                    test.Log(AventStack.ExtentReports.Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Problem User unable to logout");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully logout from the "performance_glitch_user" account 
        [Test]
        public void PerformanceGlitchUserLogout()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Performance Glitch User Logout").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;
                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                //Find the username field on the login page and key the username above in the text box
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("performance_glitch_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                currentURL = cdriver.Url;
                if (currentURL == inventoryPage)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user successfully logged in");
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Open the navigation side pane to access the logout link
                    cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user clicked LOGOUT from side navigation pane");

                    currentURL = cdriver.Url;
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user successfully logged out");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                    }
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user not redirected");
                    test.Log(AventStack.ExtentReports.Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch User unable to logout");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

    }
}
