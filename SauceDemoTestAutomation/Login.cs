using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTestAutomation.BaseClass;
using AventStack.ExtentReports;
using System;

namespace SauceDemoTestAutomation
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        //Test Scenario: Successfully login with the username "standard_user" and the default password "secret_sauce"
        [Test]
        public void StandardUserTest()
        {
            ExtentTest test = null;

            test = extent.CreateTest("Standard User Login").Info("Test Started");
            test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

            //Find the username field on the login page and key the username above in the text box
            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("standard_user");
            

            //Find the password field on the login page and key the password above in the text box
            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            //Find and click the login button
            cdriver.FindElement(By.Name("login-button")).Click();

            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is standard_user");
            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
            test.Log(AventStack.ExtentReports.Status.Info, "User Successfully Logged In");
            test.Log(AventStack.ExtentReports.Status.Pass, "Standard User Login Passed");
            
        }

        //Test Scenario: Attempt to login with the username "locked_out_user" and the default password "secret_sauce"
        [Test]
        public void LockedOutUserTest()
        {
            ExtentTest test = null;

            test = extent.CreateTest("LockedOut User Login").Info("Test Started");
            test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("locked_out_user");

            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            cdriver.FindElement(By.Name("login-button")).Click();

            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is locked_out_user");
            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
            test.Log(AventStack.ExtentReports.Status.Info, "User denied login due to account being locked");
            test.Log(AventStack.ExtentReports.Status.Pass, "LockedOut User Login Passed");
        }

        //Test Scenario: Successfully login with the username "problem_user" and the default password "secret_sauce"
        [Test]
        public void ProblemUserTest()
        {
            ExtentTest test = null;

            test = extent.CreateTest("Problem User Login").Info("Test Started");
            test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("problem_user");

            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            cdriver.FindElement(By.Name("login-button")).Click();

            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is problem_user");
            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
            test.Log(AventStack.ExtentReports.Status.Info, "User Successfully Logged In");
            test.Log(AventStack.ExtentReports.Status.Pass, "Problem User Login Passed");
        }

        //Test Scenario: Successfully login with the username "performance_glitch_user" and the default password "secret_sauce"
        [Test]
        public void PerformanceGlitchUserTest()
        {
            ExtentTest test = null;

            test = extent.CreateTest("Performance Glitch User Login").Info("Test Started");
            test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("performance_glitch_user");

            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            cdriver.FindElement(By.Name("login-button")).Click();

            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is performance_glitch_user");
            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
            test.Log(AventStack.ExtentReports.Status.Info, "User Successfully Logged In");
            test.Log(AventStack.ExtentReports.Status.Pass, "Performance Glitch User Login Passed");
        }

        //Test Scenario: Fail to login by entering a non authorzed username and the default password "secret_sauce"
        [Test]
        public void UnauthorizedUser()
        {
            ExtentTest test = null;

            test = extent.CreateTest("Unathoried User Attempted Login").Info("Test Started");
            test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("wronguser");

            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            cdriver.FindElement(By.Name("login-button")).Click();

            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is not accepted by the system");
            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
            test.Log(AventStack.ExtentReports.Status.Info, "User was not permitted access to the site.");
            test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
        }
    }
}