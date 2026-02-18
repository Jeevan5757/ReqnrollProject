using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using ReqnrollProject.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Hooks
{
    [Binding]
    public class ExtentReportHooks
    {
        private static ExtentReports _extent;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private readonly DriverContext _driverContext;
        private DateTime _scenarioStartTime;
        private readonly double SlowThresholdSeconds = 10.0;

        public ExtentReportHooks(DriverContext driverContext)
        {
            _driverContext = driverContext;
            
        }

        
        

        [BeforeTestRun]
        public static void initializeReport()
        {
            String workingdirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(workingdirectory).Parent.Parent.FullName;
            String reportPath = $"{ProjectDirectory}//Reports";
            String reportFile = Path.Combine(reportPath, $"{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.html");
            
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }
            var htmlreporter = new ExtentSparkReporter(reportFile);
            htmlreporter.Config.Theme = Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlreporter);
            _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
            _extent.AddSystemInfo("Machine", Environment.MachineName);
            _extent.AddSystemInfo("User", Environment.UserName);
            _extent.AddSystemInfo("Browser", Configreader.Browser);
            _extent.AddSystemInfo("Base URL", Configreader.BaseUrl);
        }

        
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            _scenarioStartTime = DateTime.Now;
        }
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            TimeSpan duration = DateTime.Now - _scenarioStartTime;

            string durationStr = duration.TotalSeconds < 1
    ?       $"{duration.TotalMilliseconds:F0} ms"
    :       $"{duration.TotalSeconds:F2} sec";

            // 2. Color code long durations (MarkupHelper)
            var performanceNode = _scenario.CreateNode<And>("Performance");
            if (duration.TotalSeconds > SlowThresholdSeconds)
            {
                performanceNode.Warning(MarkupHelper.CreateLabel(durationStr, ExtentColor.Amber));
            }
            else
            {
                performanceNode.Info(MarkupHelper.CreateLabel(durationStr, ExtentColor.Green));
            }

            //_scenario.CreateNode<And>("Execution Summary")
            // .Info($"Execution Time: {duration.TotalSeconds:F2} seconds");
            //_scenario.Info($"Execution Time: {duration.TotalSeconds} seconds");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var stepInfo = ScenarioStepContext.Current.StepInfo.Text;


            ExtentTest stepNode = stepType switch
            {
                "Given" => _scenario.CreateNode<Given>(stepInfo),
                "When" => _scenario.CreateNode<When>(stepInfo),
                "Then" => _scenario.CreateNode<Then>(stepInfo),
                "And" => _scenario.CreateNode<And>(stepInfo)
            };

            if (scenarioContext.TestError != null)
            {
                Logging.Error(scenarioContext.TestError.Message);
                string screenshotPath = CaptureScreenshot(scenarioContext);
                stepNode.Fail(scenarioContext.TestError.Message)
                        .AddScreenCaptureFromPath(screenshotPath);

            }
            else
            {
                stepNode.Pass("Step passed");

            }
        }



        [AfterTestRun]
        public static void flushReport()
        {
            _extent.Flush();
        }

        private string CaptureScreenshot(ScenarioContext scenarioContext)
        {
            var driver = _driverContext.Driver;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string projectRoot = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            
            string screenshotsDir = Path.Combine(
                projectRoot,
                "Reports",
                "Screenshots"
            );

            if (!Directory.Exists(screenshotsDir))
            {
                Directory.CreateDirectory(screenshotsDir);
            }
            string safeScenarioTitle = string.Concat(
                scenarioContext.ScenarioInfo.Title
                .Split(Path.GetInvalidFileNameChars())
                ).Replace(" ", "_");
            TestContext.Progress.WriteLine($"scenario title: {scenarioContext.ScenarioInfo.Title}");

            string filePath = Path.Combine(screenshotsDir,
                $"{safeScenarioTitle}_{System.DateTime.Now:ddMMyyyy_HHmmss}.png");

            screenshot.SaveAsFile(filePath);
            return filePath;
        }

        public static void Log(string level, string message)
        {
            if (_scenario == null)
                return;

            switch (level)
            {
                case "INFO":
                    _scenario.Info(message);
                    break;

                case "WARN":
                    _scenario.Warning(message);
                    break;

                case "ERROR":
                    _scenario.Fail(message);
                    break;
            }
        }


    }
}
