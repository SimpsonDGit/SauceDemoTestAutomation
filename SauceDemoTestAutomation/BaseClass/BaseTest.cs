using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace SauceDemoTestAutomation.BaseClass
{
    public class BaseTest
    {
        public IWebDriver cdriver;
        public ExtentReports extent = null;
        public IWebElement userName = null;
        public IWebElement password = null;

        [SetUp]
        public void Initialize()
        {
            cdriver = new ChromeDriver();
            cdriver.Manage().Window.Maximize();
            cdriver.Url = "https://www.saucedemo.com/";

            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Donovans\SauceDemoTestAutomation\SauceDemoTestAutomation\HtmlReports\ReportLog.html");
            extent.AttachReporter(htmlReporter);
        }

        [TearDown]
        public void CloseSite()
        {
            cdriver.Quit();

            extent.Flush();
        }
        
    }
 }
   

