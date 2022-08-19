using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTestAutomation
{
    [TestFixture]
    public class StandardUserInventoryTests
    {
        public IWebDriver cdriver;
        public ExtentReports extent = null;
        public IWebElement visible;
        


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
        //Test Scenario: Successfully add and remove backpack from cart with the "standard_user" account
        public void Add_RemoveBackpack_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Backpack to Cart as a Standard User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Backpack added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                }

                cdriver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();

                try { bool isElementDisplayed = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Displayed; }
                catch (NoSuchElementException n)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Backpack removed from cart ");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Backpack not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Go to the correct About page with the "standard_user" account
        public void ViewAboutPage_SU()
        {
            ExtentTest test = null;
            String currentURL = null;
            try
            {
                test = extent.CreateTest("View About Page as a Standard User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                // Open the navigation side pane to access the logout link
                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                cdriver.FindElement(By.Id("about_sidebar_link")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Standard user clicked ABOUT from side navigation pane");

                currentURL = cdriver.Url;
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                if (currentURL == "https://saucelabs.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Fail, "Link is Broken");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to access About Page");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }


        [Test]
        //Test Scenario: Reset the Application State with the "standard_user" account
        public void ResetAppState_SU()
        {
            ExtentTest test = null;
            String currentURL = null;
            try
            {
                test = extent.CreateTest("Reset App State as a Standard User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Info, "Onesie added to cart");
                }

                // Open the navigation side pane to access the logout link
                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                cdriver.FindElement(By.Id("reset_sidebar_link")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Standard user clicked RESET APP STATE from side navigation pane");


                try { bool isElementDisplayed = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Displayed; }
                catch(NoSuchElementException n)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Shopping Cart is empty");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Sort products from high to low prices as a Standard User account
        public void Sort_HiLo_SU()
        {
            ExtentTest test = null;
            WebDriverWait wait = new WebDriverWait(cdriver, TimeSpan.FromSeconds(10));

            try
            {
                test = extent.CreateTest("Sort from High to Low as a Standard User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                var sortProducts = cdriver.FindElement(By.ClassName("product_sort_container"));
                var selectOption = new SelectElement(sortProducts);
                
                // select by value
                selectOption.SelectByValue("hilo");

                test.Log(AventStack.ExtentReports.Status.Info, "Products Sorted from high to low price ");
                
                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Error when trying to sort products");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add bikelight to cart with the "standard_user" account
        [Test]
        public void AddBikeLightToCart_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Bike Light to Cart as a Standard User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bike Light added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Bike Light not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully add bolt shirt to cart with the "standard_user" account
        [Test]
        public void AddBoltShirtToCart_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Bolt Shirt to Cart as a Standard User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add fleece jacket to cart with the "standard_user" account
        [Test]
        public void AddFleeceJacketToCart_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Fleece Jacket to Cart as a Standard User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {                    
                    test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add onesi to cart with the "standard_user" account
        [Test]
        public void AddOnesieToCart_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Onesie to Cart as a Standard User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Onesie added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Onesi not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add red t shirt to cart with the "standard_user" account
        [Test]
        public void AddRedTShirtToCart_SU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add red t shirt to Cart as a Standard User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt not added to cart");
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
    public class ProblemUserInventoryTests
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
            userName.SendKeys("problem_user");

            //Find the password field on the login page and key the password above in the text box
            IWebElement password = cdriver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            //Find and click the login button
            cdriver.FindElement(By.Name("login-button")).Click();
        }

        [Test]
        //Test Scenario: Sort produxta from high to low prices with the "standard_user" account
        public void Sort_ZtoA_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Sort from Z to A as a Problem User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                var sortProducts = cdriver.FindElement(By.ClassName("product_sort_container"));
                var selectOption = new SelectElement(sortProducts);

                // select by value
                selectOption.SelectByValue("za");
                String sortValueText = cdriver.FindElement(By.ClassName("product_sort_container")).Text;
                test.Log(AventStack.ExtentReports.Status.Info, sortValueText);

                test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Error when trying to sort products");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Click the saucelabs backpack label to view the item details
        public void ViewBackpack_PU()
        {
            ExtentTest test = null;
            String currentURL = null;
            try
            {
                test = extent.CreateTest("View Backpack Page as a Problem User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                String itemName = cdriver.FindElement(By.LinkText("Sauce Labs Backpack")).Text;
                cdriver.FindElement(By.LinkText("Sauce Labs Backpack")).Click();

                test.Log(AventStack.ExtentReports.Status.Info, "User clicked: " + itemName);

                String inventoryItem = cdriver.FindElement(By.ClassName("inventory_details_name")).Text;
                test.Log(AventStack.ExtentReports.Status.Info, "Item Displayed: " + inventoryItem);

                if (itemName != inventoryItem)
                {
                    test.Log(AventStack.ExtentReports.Status.Fail, "Items do not match");
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to View Item");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        [Test]
        //Test Scenario: Go to the correct About page as a Problem User 
        public void ViewAboutPage_PU()
        {
            ExtentTest test = null;
            String currentURL = null;
            try
            {
                test = extent.CreateTest("View About Page as a Problem User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                currentURL = cdriver.Url;

                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

               // Open the navigation side pane to access the logout link
                cdriver.FindElement(By.Id("react-burger-menu-btn")).Click();
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                cdriver.FindElement(By.Id("about_sidebar_link")).Click();
                test.Log(AventStack.ExtentReports.Status.Info, "Problem user clicked ABOUT from side navigation pane");

                currentURL = cdriver.Url;
                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                test.Log(AventStack.ExtentReports.Status.Info, "Current URL: " + currentURL);

                if (currentURL == "https://saucelabs.com/")
                {
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
                else
                {
                    test.Log(AventStack.ExtentReports.Status.Fail, "Link is Broken");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Unable to access About Page");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }
        //Test Scenario: Successfully add bikelight to cart with the "problem_user" account

        [Test]
        public void Add_RemoveBikeLight_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add and Remove Bike Light from Cart as a Problem User").Info("Test Started");


                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bike Light added to cart");
                    test.Log(AventStack.ExtentReports.Status.Info, "No. of Items in Cart: " + cartNo);

                }

                cdriver.FindElement(By.Id("remove-sauce-labs-bike-light")).Click();

                try 
                { 
                    bool isElementDisplayed = cdriver.FindElement(By.ClassName("add-to-cart-sauce-labs-bike-light")).Displayed;
                    if (isElementDisplayed == true)
                    {
                        test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                    }    
                }
                catch (NoSuchElementException n)
                {
                    test.Log(AventStack.ExtentReports.Status.Fail, "Unable to Remove Bike Light from cart");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully add bolt shirt to cart with the "problem_user" account
        [Test]
        public void AddBoltShirtToCart_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Bolt Shirt to Cart as a Problem User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }

            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add fleece jacket to cart with the "problem_user" account
        [Test]
        public void AddFleeceJacketToCart_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Fleece Jacket to Cart as a Problem User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add onesi to cart with the "problem_user" account
        [Test]
        public void AddOnesieToCart_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Onesie to Cart as a Problem User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Onesie added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Onesi not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add red t shirt to cart with the "problem_user" account
        [Test]
        public void AddRedTShirtToCart_PU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add red t shirt to Cart as a Problem User").Info("Test Started");

                cdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                cdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt not added to cart");
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
    public class PerformanceGlitchUserInventoryTests
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
        public void AddBackpackToCart_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Backpack to Cart as a Performance Glitch User").Info("Test Started");
                test.Log(AventStack.ExtentReports.Status.Info, "Chrome Browser Launched");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).ToString();

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Backpack added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Backpack not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
            
        }

        //Test Scenario: Successfully add bikelight to cart with the "performance_glitch_user" account
        [Test]
        public void AddBikeLightToCart_PGU()
        {
            ExtentTest test = null;

            try
            { 
                test = extent.CreateTest("Add Bike Light to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bike Light added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Bike Light not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }
        }

        //Test Scenario: Successfully add bolt shirt to cart with the "performance_glitch_user" account
        [Test]
        public void AddBoltShirtToCart_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Bolt Shirt to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Bolt Shirt not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add fleece jacket to cart with the "performance_glitch_user" account
        [Test]
        public void AddFleeceJacketToCart_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Fleece Jacket to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Fleece Jacket not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add onesi to cart with the "performance_glitch_user" account
        [Test]
        public void AddOnesieToCart_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add Onesie to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;

                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Onesie added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Onesi not added to cart");
                test.Log(AventStack.ExtentReports.Status.Fail, e.ToString());
            }

        }

        //Test Scenario: Successfully add red t shirt to cart with the "performance_glitch_user" account
        [Test]
        public void AddRedTShirtToCart_PGU()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Add red t shirt to Cart as a Performance Glitch User").Info("Test Started");

                cdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();

                //The number displayed in above the shopping cart icon when an item is added
                String cartNo = cdriver.FindElement(By.ClassName("shopping_cart_badge")).Text;
        
                //Check if the shopping cart badge number is empty 
                if (cartNo != null)
                {
                    test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt added to cart");
                    test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");
                }
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Info, "Red T-Shirt not added to cart");
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

