using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoTestAutomation.BaseClass;

namespace SauceDemoTestAutomation
{
    [TestFixture]
    public class FooterLinkTests : BaseTest
    {
        [Test]
        //Test Scenario: Check if each of the social links in the page footer are clickable for the "standard_user" account
        public void SocialLinks_SU()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Standard User Footer Links Test").Info("Test Started");
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

                //Click each social link in the footer to navigate to the respective page
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Twitter link opened by standard user");


                cdriver.FindElement(By.LinkText("Facebook")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Facebook link opened by standard user");

                cdriver.FindElement(By.LinkText("LinkedIn")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "LinkedIn link opened by standard user");

                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Check if each of the social links in the page footer are clickable for the "performance_glitch_user" account
        public void SocialLinks_PU()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Problem User Footer Links Test").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");
                IWebElement userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("performance_glitch_user");

                IWebElement password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged in");

                //Click each social link in the footer to navigate to the respective page
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Twitter link opened by problem user");

                cdriver.FindElement(By.LinkText("Facebook")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Facebook link opened by problem user");

                cdriver.FindElement(By.LinkText("LinkedIn")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "LinkedIn link opened by problem user");

                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Check if each of the social links in the page footer are clickable for the "performance_glitch_user" account
        public void SocialLinks_PGU()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Performance Glitch User Footer Links Test").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");
                IWebElement userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("performance_glitch_user");

                IWebElement password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch User successfully logged in");

                //Click each social link in the footer to navigate to the respective page
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Twitter link opened by Performance Glitch User");

                cdriver.FindElement(By.LinkText("Facebook")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Facebook link opened by Performance Glitch User");

                cdriver.FindElement(By.LinkText("LinkedIn")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "LinkedIn link opened by Performance Glitch User");

                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

    }
}
