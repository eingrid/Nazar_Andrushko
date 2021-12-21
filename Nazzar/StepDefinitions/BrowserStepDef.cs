using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Nazzar.Drivers;

namespace Nazzar.StepDefinitions
{
    [Binding]
    public sealed class BrowserStepDef
    {
        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public BrowserStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on Work Shifts page")]
        public void GivenIAmOnWorkShiftsPage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");

            IWebElement login = driver.FindElement(By.Id("txtUsername"));
            IWebElement password = driver.FindElement(By.Id("txtPassword"));

            login.SendKeys("Admin");
            password.SendKeys("admin123");

            IWebElement login_button = driver.FindElement(By.Id("btnLogin"));
            login_button.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement workShift_button = driver.FindElement(By.Id("menu_admin_viewAdminModule"));

            workShift_button.Click();

            System.Threading.Thread.Sleep(2000);


            IWebElement hover2 = driver.FindElement(By.Id("menu_admin_Job"));
            hover2.Click();


            System.Threading.Thread.Sleep(2000);

            IWebElement workShift_button2 = driver.FindElement(By.Id("menu_admin_workShift"));

            workShift_button2.Click();



            System.Threading.Thread.Sleep(2000);
        }

        [When(@"I click Add Button")]
        public void WhenIClickAddButton()
        {
            IWebElement btnAdd_workShift = driver.FindElement(By.XPath("//*[@id='btnAdd']"));

            btnAdd_workShift.Click();

        }

        [When(@"I enter Shift Name choose work hours choose available eployees")]
        public void WhenIEnterShiftNameChooseWorkHoursChooseAvailableEployees()
        {

            IWebElement Shift_name = driver.FindElement(By.XPath("//*[@id='workShift_name']"));
            IWebElement time_from = driver.FindElement(By.XPath("//*[@id='workShift_workHours_from']"));
            IWebElement time_to = driver.FindElement(By.XPath("//*[@id='workShift_workHours_to']"));


            
            Shift_name.SendKeys("Some_Shift_Name");
    
            System.Threading.Thread.Sleep(5000);


            IWebElement btnAssignEmployee = driver.FindElement(By.Id("btnAssignEmployee"));

            SelectElement select3 = new SelectElement(driver.FindElement(By.XPath("//*[@id='workShift_availableEmp']")));

            select3.SelectByIndex(0);

            btnAssignEmployee.Click();
            System.Threading.Thread.Sleep(3000);
        }

        [When(@"I click Save button to save Work Shift")]
        public void WhenIClickSaveButtonToSaveWorkShift()
        {
            IWebElement save_btn = driver.FindElement(By.Id("btnSave"));

            save_btn.Click();


            System.Threading.Thread.Sleep(1000);
        }

        [Then(@"I am transfered to page with records and I see my record")]
        public void ThenIAmTransferedToPageWithRecordsAndISeeMyRecord()
        {
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//tr//td//a[text()='Some_Shift_Name']//..//..//td//input")));
        }

        [When(@"I click in checkbox on the left of Shift Name")]
        public void WhenIClickInCheckboxOnTheLeftOfShiftName()
        {
            IWebElement check_box = driver.FindElement(By.XPath("//tr//td//a[text()='Some_Shift_Name']//..//..//td//input"));
            check_box.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [When(@"I click Delete Button")]
        public void WhenIClickDeleteButton()
        {
            IWebElement DeleteBtn = driver.FindElement(By.Id("btnDelete"));
            DeleteBtn.Click();
        }

        [When(@"I click Ok Button in dialog box")]
        public void WhenIClickOkButtonInDialogBox()
        {
            IWebElement Confirm_Button = driver.FindElement(By.Id("dialogDeleteBtn"));
            System.Threading.Thread.Sleep(1000);

            Confirm_Button.Click();

        }

        [Then(@"I am observing Work Shift table without my record")]
        public void ThenIAmObservingWorkShiftTableWithoutMyRecord()
        {
            Assert.IsEmpty(driver.FindElements(By.XPath("//tr//td//a[text()='Some_Shift_Name']//..//..//td//input")));
        }
    }
}