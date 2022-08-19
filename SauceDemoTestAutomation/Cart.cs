using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using OpenQA.Selenium.Chrome;

namespace SauceDemoTestAutomation
{
    [TestFixture]
    public class CartCheckout_SU 
    {
        public IWebDriver cdriver;
        public ExtentReports extent = null;
        

        [OneTimeSetUp]
        public void Initialize()
        {
            cdriver = new ChromeDriver();
            cdriver.Manage().Window.Maximize();
            cdriver.Url = "https://www.saucedemo.com/";

            //Create instance of extent report and direct the path to desired folder
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Donovans\SauceDemoTestAutomation\SauceDemoTestAutomation\HtmlReports\ReportLog.html");
            extent.AttachReporter(htmlReporter);

            //Find the username field on the login page and key the username above in the text box
            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("standard_user");

            //Find the password field on the login page and key the password above in the text box
            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            //Find and click the login button
            cdriver.FindElement(By.Name("login-button")).Click();
        }

        [Test]
        //Test Scenario: Successfully add backpack to cart with the "standard_user" account
        public void CheckoutBackpack_SU()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Checkout Backpack as a Standard User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");
                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click(); 
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Backpack added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Backpack");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully Checkout bikelight to cart with the "standard_user" account
        [Test]
        public void CheckoutBikeLight_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Bike Light as a Standard User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Bike Light added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Bike Light");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully add bolt shirt to cart with the "standard_user" account
        [Test]
        public void CheckoutBoltShirt_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Bolt Shirt as a Standard User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                
                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    

                    test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Bike Light");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add fleece jacket to cart with the "standard_user" account
        [Test]
        public void CheckoutFleeceJacket_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Fleece Jacket as a Standard User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                
                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    

                    test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Fleece Jacket");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add onesi to cart with the "standard_user" account
        [Test]
        public void CheckoutOnesie_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Onesie as a Standard User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    

                    test.Log(AventStack.ExtentReports.Status.Info, "Onesi added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Onesi");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add red t shirt to cart with the "standard_user" account
        [Test]
        public void CheckoutRedTShirt_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout red t-shirt to Cart as a Standard User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Red T-shirt added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Onesi");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [OneTimeTearDown]
        public void CloseSite()
        {
            cdriver.Quit();
            extent.Flush();
        }

    }

    [TestFixture]
    public class CartCheckout_PGU
    {
        public IWebDriver cdriver;
        public ExtentReports extent = null;


        [OneTimeSetUp]
        public void Initialize()
        {
            cdriver = new ChromeDriver();
            cdriver.Manage().Window.Maximize();
            cdriver.Url = "https://www.saucedemo.com/";

            //Create instance of extent report and direct the path to desired folder
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Donovans\SauceDemoTestAutomation\SauceDemoTestAutomation\HtmlReports\ReportLog.html");
            extent.AttachReporter(htmlReporter);

            //Find the username field on the login page and key the username above in the text box
            IWebElement userName = cdriver.FindElement(By.Id("user-name"));
            userName.SendKeys("performance_glitch_user");

            //Find the password field on the login page and key the password above in the text box
            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            //Find and click the login button
            cdriver.FindElement(By.Name("login-button")).Click();
        }

        [Test]
        //Test Scenario: Successfully add backpack to cart with the "performance_glitch_user" account
        public void CheckoutBackpack_PGU()
        {
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Checkout Backpack as a Performance Glitch User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");
                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
                

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Backpack added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    
                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Backpack");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully Checkout bikelight to cart with the "performance_glitch_user" account
        [Test]
        public void CheckoutBikeLight_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Bike Light as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Bike Light added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    cdriver.FindElement(By.Id("cancel")).Click();
                    
                    cdriver.FindElement(By.Name("continue-shopping")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Bike Light");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully add bolt shirt to cart with the "performance_glitch_user" account
        [Test]
        public void CheckoutBoltShirt_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Bolt Shirt as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Bike Light");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add fleece jacket to cart with the "performance_glitch_user" account
        [Test]
        public void CheckoutFleeceJacket_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Fleece Jacket as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text; 

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Fleece Jacket");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add onesi to cart with the "performance_glitch_user" account
        [Test]
        public void CheckoutOnesie_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout Onesie as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Onesi added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    
                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Onesi");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add red t shirt to cart with the "performance_glitch_user" account
        [Test]
        public void CheckoutRedTShirt_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Checkout red t-shirt to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    cdriver.FindElement(By.ClassName("shopping_cart_link")).Click();

                    test.Log(AventStack.ExtentReports.Status.Info, "Red T-shirt added to cart ");

                    cdriver.FindElement(By.Name("checkout")).Click();
                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Successfully able to navigate from cart to checkout");

                    cdriver.FindElement(By.Id("cancel")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Cancel checkout and returned to cart page");
                    

                    cdriver.FindElement(By.Name("continue-shopping")).Click();
                    test.Log(AventStack.ExtentReports.Status.Info, "Continue shopping and return to inventory page");

                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to checkout Onesi");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [OneTimeTearDown]
        public void CloseSite()
        {
            cdriver.Quit();
            extent.Flush();
        }

    }
}
