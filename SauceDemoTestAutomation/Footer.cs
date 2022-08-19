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
        String currentURL = null;
        public String twitterURL = "https://twitter.com/saucelabs";
        public String fbURL = "https://www.facebook.com/saucelabs";
        public IWebElement linkedinURL;

        public void SwitchToTab(object pageId)
        {
            cdriver.SwitchTo().Window(pageId.ToString());
        }

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
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Standard user successfully logged in");
                ;

                //Click the twitter link
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[1]);

                currentURL = cdriver.Url;

                if (currentURL == twitterURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Twitter link was not detected."); }
                
                //Click the facebook link
                cdriver.FindElement(By.LinkText("Facebook")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[2]);

                currentURL = cdriver.Url;

                if (currentURL == fbURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Facebook link was not detected."); }

                //Click the linkedIn link
               /* linkedinURL = cdriver.FindElement(By.LinkText("LinkedIn"));*/
                cdriver.FindElement(By.LinkText("LinkedIn")).Click();

                cdriver.SwitchTo().Window(cdriver.WindowHandles[3]);

                /*currentURL = linkedinURL.GetAttribute("a href");*/
                String webpageTitle = cdriver.Title;

                
                if (webpageTitle.Contains("LinkedIn"))
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current Title of Web Page: " + webpageTitle /*+ " " + currentURL*/);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The linkedIn link was not detected."); }
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

                //Find the username field on the login page and key the username above in the text box
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("problem_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Problem user successfully logged in");
                ;

                //Click the twitter link
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[1]);

                currentURL = cdriver.Url;

                if (currentURL == twitterURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Twitter link was not detected."); }

                //Click the facebook link
                cdriver.FindElement(By.LinkText("Facebook")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[2]);

                currentURL = cdriver.Url;

                if (currentURL == fbURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Facebook link was not detected."); }

                //Click the linkedIn link
                /* linkedinURL = cdriver.FindElement(By.LinkText("LinkedIn"));*/
                cdriver.FindElement(By.LinkText("LinkedIn")).Click();

                cdriver.SwitchTo().Window(cdriver.WindowHandles[3]);

                /*currentURL = linkedinURL.GetAttribute("a href");*/
                String webpageTitle = cdriver.Title;


                if (webpageTitle.Contains("LinkedIn"))
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current Title of Web Page: " + webpageTitle /*+ " " + currentURL*/);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The linkedIn link was not detected."); }
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

                //Find the username field on the login page and key the username above in the text box
                userName = cdriver.FindElement(By.Id("user-name"));
                userName.SendKeys("performance_glitch_user");

                //Find the password field on the login page and key the password above in the text box
                password = cdriver.FindElement(By.Id("password"));
                password.SendKeys("secret_sauce");

                //Find and click the login button
                cdriver.FindElement(By.Name("login-button")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "Performance Glitch user successfully logged in");
                ;

                //Click the twitter link
                cdriver.FindElement(By.LinkText("Twitter")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[1]);

                currentURL = cdriver.Url;

                if (currentURL == twitterURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Twitter link was not detected."); }

                //Click the facebook link
                cdriver.FindElement(By.LinkText("Facebook")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                cdriver.SwitchTo().Window(cdriver.WindowHandles[2]);

                currentURL = cdriver.Url;

                if (currentURL == fbURL)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);
                    cdriver.SwitchTo().Window(cdriver.WindowHandles[0]);
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The Facebook link was not detected."); }

                //Click the linkedIn link
                /* linkedinURL = cdriver.FindElement(By.LinkText("LinkedIn"));*/
                cdriver.FindElement(By.LinkText("LinkedIn")).Click();

                cdriver.SwitchTo().Window(cdriver.WindowHandles[3]);

                /*currentURL = linkedinURL.GetAttribute("a href");*/
                String webpageTitle = cdriver.Title;


                if (webpageTitle.Contains("LinkedIn"))
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current Title of Web Page: " + webpageTitle /*+ " " + currentURL*/);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
                else { test.Log(AventStack.ExtentReports.Status.Fail, "The linkedIn link was not detected."); }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

    }
}
