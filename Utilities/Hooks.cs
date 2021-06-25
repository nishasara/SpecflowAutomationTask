using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.Utilities
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        //Global Variable for Extent report

        public static ExtentTest test;
        private static ExtentTest featureName;
        private static ExtentReports extent;
        private ExtentTest currentScenarioName;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenariocontext, FeatureContext featurecontext)
        {
            _scenarioContext = scenariocontext;
            _featureContext = featurecontext;
        }

        //Get the browser option from the resource file
        public static int Browser = Int32.Parse(Resources.SkillSwap.Browser);

        //Get the URL from the resource file
        public static string URL = Resources.SkillSwap.URL;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            htmlpath = htmlpath.Substring(0, htmlpath.LastIndexOf("bin")) + "Report\\ExtentReport.html";
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(htmlpath);
            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
            
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();           
            

            if (_scenarioContext.TestError == null)
            {
                
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                var mediaEntity = CaptureScreenShot(driver, _scenarioContext.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
                      

        }



        [BeforeScenario]
             
            public void Setup()
            {
            currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            TestContext.WriteLine(currentScenarioName);
            TestContext.WriteLine("Starting " + _scenarioContext.ScenarioInfo.Title);
            TestContext.WriteLine("Starting " + _scenarioContext.ScenarioInfo.Tags.ToString());
            //Choose the browser as per the input from the resource file
            switch (Browser)
            {
                case 1:
                    //Create an instance of the FireFox driver
                    driver = new FirefoxDriver();
                    break;

                case 2:
                    //Create an instance of the ChromeDriver
                    driver = new ChromeDriver();

                    //Navigate to the required URL
                    driver.Navigate().GoToUrl(URL);

                    //Maximise the window
                    driver.Manage().Window.Maximize();
                    break;
            }
        }    

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
