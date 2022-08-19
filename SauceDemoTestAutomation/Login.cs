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
        public String currentURL = null;

        //Test Scenario: Successfully login with the username "standard_user" and the default password "secret_sauce"
        [Test]
        public void StandardUserTest()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Standard User Login").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                if (currentURL == "https://www.saucedemo.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Find the username field on the login page and key the username above in the text box
                    userName = cdriver.FindElement(By.Id("user-name"));
                    userName.SendKeys("standard_user");


                    //Find the password field on the login page and key the password above in the text box
                    password = cdriver.FindElement(By.Id("password"));
                    password.SendKeys("secret_sauce");

                    //Find and click the login button
                    cdriver.FindElement(By.Name("login-button")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    currentURL = cdriver.Url;
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/inventory.html")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is standard_user");
                        test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
                        test.Log(AventStack.ExtentReports.Status.Info, "User Successfully Logged In");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Standard User Login Passed");
                    }
                    else
                    {
                        test.Log(AventStack.ExtentReports.Status.Fail, "Standard user login attempt failed");
                    }
                }
            } catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Standard user failed login attempt");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Attempt to login with the username "locked_out_user" and the default password "secret_sauce"
        [Test]
        public void LockedOutUserTest()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Locked Out User Login").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                if (currentURL == "https://www.saucedemo.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL is: " + currentURL);

                    //Find the username field on the login page and key the username above in the text box
                    userName = cdriver.FindElement(By.Id("user-name"));
                    userName.SendKeys("locked_out_user");


                    //Find the password field on the login page and key the password above in the text box
                    password = cdriver.FindElement(By.Id("password"));
                    password.SendKeys("secret_sauce");

                    //Find and click the login button
                    cdriver.FindElement(By.Name("login-button")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    currentURL = cdriver.Url;

                    if (currentURL != "https://www.saucedemo.com/inventory.html")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "Current URL after login attempt is: " + currentURL);

                        String accountStatus = cdriver.FindElement(By.ClassName("error-message-container")).Text;

                        if (accountStatus.Contains("locked out"))
                        {
                            test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is locked_out_user");
                            test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
                            test.Log(AventStack.ExtentReports.Status.Info, "Error message: " + accountStatus);
                            test.Log(AventStack.ExtentReports.Status.Pass, "Locked Out User Denied Entry");
                            currentURL = cdriver.Url;
                        }
                    }
                    else if (currentURL == "https://www.saucedemo.com/inventory.html")
                    {
                        
                        test.Log(AventStack.ExtentReports.Status.Info, "Locked account successfully Logged In");
                        
                    }
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Locked Out user failed login attempt");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully login with the username "problem_user" and the default password "secret_sauce"
        [Test]
        public void ProblemUserTest()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Problem User Account Login").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                if (currentURL == "https://www.saucedemo.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Find the username field on the login page and key the username above in the text box
                    userName = cdriver.FindElement(By.Id("user-name"));
                    userName.SendKeys("problem_user");


                    //Find the password field on the login page and key the password above in the text box
                    password = cdriver.FindElement(By.Id("password"));
                    password.SendKeys("secret_sauce");

                    //Find and click the login button
                    cdriver.FindElement(By.Name("login-button")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    currentURL = cdriver.Url;
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/inventory.html")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is problem_user");
                        test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
                        test.Log(AventStack.ExtentReports.Status.Info, "Problem User Successfully Logged In");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Problem User Login Passed");
                    }
                    else
                    {
                        test.Log(AventStack.ExtentReports.Status.Fail, "Problem User login attempt failed");
                    }
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Problem user failed login attempt");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

         //Test Scenario: Successfully login with the username "performance_glitch_user" and the default password "secret_sauce"
        [Test]
        public void PerformanceGlitchUserTest()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Peformance Glitch User Account Login").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                String currentURL = cdriver.Url;

                if (currentURL == "https://www.saucedemo.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Find the username field on the login page and key the username above in the text box
                    userName = cdriver.FindElement(By.Id("user-name"));
                    userName.SendKeys("performance_glitch_user");


                    //Find the password field on the login page and key the password above in the text box
                    password = cdriver.FindElement(By.Id("password"));
                    password.SendKeys("secret_sauce");

                    //Find and click the login button
                    cdriver.FindElement(By.Name("login-button")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    currentURL = cdriver.Url;
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/inventory.html")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is performance_glitch_user");
                        test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
                        test.Log(AventStack.ExtentReports.Status.Info, "Peformance Glitch User Successfully Logged In");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Peformance Glitch User Login Passed");
                    }
                    else
                    {
                        test.Log(AventStack.ExtentReports.Status.Fail, "Peformance Glitch User login attempt failed");
                    }
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Peformance Glitch User failed login attempt");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Fail to login by entering a non authorzed username and the default password "secret_sauce"
        [Test]
        public void UnauthorizedUserTest()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Unauthorized User Login").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                String currentURL = cdriver.Url;

                if (currentURL == "https://www.saucedemo.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    //Find the username field on the login page and key the username above in the text box
                    userName = cdriver.FindElement(By.Id("user-name"));
                    userName.SendKeys("wrong_user");


                    //Find the password field on the login page and key the password above in the text box
                    password = cdriver.FindElement(By.Id("password"));
                    password.SendKeys("secret_sauce");

                    //Find and click the login button
                    cdriver.FindElement(By.Name("login-button")).Click();
                    cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    currentURL = cdriver.Url;
                    test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                    if (currentURL == "https://www.saucedemo.com/inventory.html")
                    {
                        test.Log(AventStack.ExtentReports.Status.Info, "User Name entered is wrong_user");
                        test.Log(AventStack.ExtentReports.Status.Info, "Default Password entered");
                        test.Log(AventStack.ExtentReports.Status.Info, "User Successfully Logged In");
                        test.Log(AventStack.ExtentReports.Status.Pass, "Standard User Login Passed");
                    }
                    else
                    {
                        test.Log(AventStack.ExtentReports.Status.Fail, "User login attempt failed");
                    }
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "User failed login attempt");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }
    }
}