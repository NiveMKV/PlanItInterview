using OpenQA.Selenium;
using PlanItTestProject.Pages;

namespace PlanItTestProject.Tests
{

    /// <summary>
    /// Test cases related to contact page function testing.
    /// </summary>
    [TestFixture]
    public class ContactTests
    {

        private PageFactory pageFactory = new PageFactory();

        [SetUp]
        public void BeforeTest()
        {
            pageFactory.VerifyHomePageIsLoaded();
        }

        [TearDown]
        public void AfterTest()
        {
            pageFactory.CloseDriver();
        }

        /// <summary>
        /// Submit the contact w/o entering any  data to verify error msg population and enter mandatory fields to submit the form properly.
        /// </summary>
        [TestCase("Nivedha", "test@mail.com", "Sample Testcase one")]
        public void FillContactPageTest(string foreName, string email, string msg)
        {
            pageFactory.homePage.ClickContactMenu();
            pageFactory.contactPage.VerifyContactPage();
            pageFactory.contactPage.ClickSubmit();
            pageFactory.contactPage.VerifyErrorTagMessage();


            ContactPage cpFormFields = new ContactPage
            {
                ForeName = foreName,
                Email = email,
                Message = msg
            };
            pageFactory.contactPage.FillMandatoryFields(cpFormFields);
            pageFactory.contactPage.VerifyInfoTagMessage();
        }

        [TestCase("Nivedha", "test@mail.com", "Sample Testcase two")]
        public void SubmitContactPageTest(string foreName, string email, string msg)
        {
            pageFactory.homePage.ClickContactMenu();
            pageFactory.contactPage.VerifyContactPage();
            ContactPage cpFormFields = new ContactPage
            {
                ForeName = foreName,
                Email = email,
                Message = msg
            };
            int testCount = 5;
            while (testCount != 0)
            {
                pageFactory.contactPage.FillMandatoryFields(cpFormFields);
                pageFactory.contactPage.ClickSubmit();
                pageFactory.contactPage.VerifySuccessfullSubmissionOfContactForm(foreName);
                pageFactory.contactPage.ClickBackBtn();
                testCount--;
            }
        }




    }
}
