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
        [Test]
        //Test Scenario: Successfully logout from the "standard_user" account
        public void StandardUserLogout()
        {  
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Standard User Logout").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                //Find the username field on the login page and key the username above in the text box
                IWebElement userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");

                //Find the password field on the login page and key the password above in the text box
                IWebElement password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Standard user successfully logged in");

                //Open the navigation side pane to access the logout link
                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                test.Log(AventStack.ExtentReports.Status.Info, "Standard user successfully logged out");
                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
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

                IWebElement userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("problem_user");

                IWebElement password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                cdriver.FindElement(By.Name("login-button")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged in");

                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged out");
                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
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

                IWebElement userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("performance_glitch_user");

                IWebElement password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                cdriver.FindElement(By.Name("login-button")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user successfully logged in");

                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("logout_sidebar_link")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user successfully logged out");
                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch User unable to logout");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

    }
}
