using System;
//using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using NUnit.Framework;

namespace PlanItTestProject.Pages
{
    public class ContactPage
    {
        #region Properties
        public string ForeName;
        public string Email;
        public string Message;
        #endregion

        #region Fields

        private IWebDriver Driver;
        private string ContactPageUrl = "contact";
        private string ContactPageForm = "//form[contains(@class,'form-horizontal')]";
        private string ForeNameTxt = ".//*[@id='forename']";
        private string EmailTxt = ".//*[@id='email']";
        private string MessageTxt = ".//*[@id='message']";
        private string SubmitBtn = ".//a[contains(text(), 'Submit')]";
        private string ErrorTag = "//div[contains(@class,'alert-error')]";
        private string InfoTag = "//div[contains(@class,'alert-info')]";
        private string ErrorTagMsg = "we won't get it unless you complete the form correctly";
        private string InfoTagMsg = "tell it how it is";
        private string SendFeedbackModal = ".//*[contains(@class, 'modal')]//*[contains(text(), 'Sending Feedback')]";
        private string SuccessTagMsg = ".//*[contains(@class, 'alert-success')]";
        private string BackBtn = ".//*[contains(@class, 'alert-success')]/following-sibling::a";
        private string SuccessMsg = "Thanks {Forename}";
        #endregion


        public ContactPage()
        {
            //paramterless construcotr
        }

        public ContactPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region Methods
        public void VerifyContactPage()
        {
            Assert.That(Driver.Url.Contains(ContactPageUrl), "The contact page isn't loaded correctly!!!");
            WaitExtension.WaitElementVisible(Driver, By.XPath(ForeNameTxt));
        }

        //public void SwitchToContactPageForm()
        //{

        //    Driver.FindElement(By.XPath(ContactPageForm));
        //}

        public void FillMandatoryFields(string foreName, string email, string msg)
        {
            EnterForeName(foreName);
            EnterEmail(email);
            EnterMessage(msg);
        }

        public void FillMandatoryFields(ContactPage contactPageFormFields)
        {
            EnterForeName(contactPageFormFields.ForeName);
            EnterEmail(contactPageFormFields.Email);
            EnterMessage(contactPageFormFields.Message);
        }

        public void ClickSubmit()
        {
            WaitExtension.WaitElementToBeClickable(Driver, By.XPath(SubmitBtn)).Click();
        }

        public void VerifyErrorTagMessage()
        {
            string ActualErrorMsg = WaitExtension.WaitElementVisible(Driver, By.XPath(ErrorTag)).Text;
            //string ActualErrorMsg = Driver.FindElement(By.XPath(ErrorTag)).Text;
            Assert.That(ActualErrorMsg.Contains(ErrorTagMsg), "The Error message when form is filled partially is not appropriate!!!");
        }

        public void VerifyErrorTagMessageNotVisible()
        {
            Assert.That(WaitExtension.WaitInvisibilityOfElement(Driver, By.XPath(ErrorTag)), "The Error message is still visible");
        }

        public void VerifyInfoTagMessage()
        {
            string InfoText = WaitExtension.WaitElementVisible(Driver, By.XPath(InfoTag)).Text;
            Assert.That(InfoText.Contains(InfoTagMsg), "The Info tag message when form is filled with mandatory fields is not appropriate!!!");
        }

        public void VerifySuccessfullSubmissionOfContactForm(string ForeName)
        {
            VerifySendFeedbackModalDisappears();
            string ActualSuccessMsg = Driver.FindElement(By.XPath(SuccessTagMsg)).Text;
            string ExpectedSuccessMsg = SuccessMsg.Replace("{Forename}", ForeName);
            Assert.That(ActualSuccessMsg.Contains(ExpectedSuccessMsg), "The form is not successfully submitted as the success message isn't appropriate!!!");
        }

        public void ClickBackBtn()
        {
            Driver.FindElement(By.XPath(BackBtn)).Click();
        }
        #endregion

        #region Private Methods
        private void EnterForeName(string foreName)
        {
            Driver.FindElement(By.XPath(ForeNameTxt)).SendKeys(foreName);
        }

        private void EnterEmail(string email)
        {
            Driver.FindElement(By.XPath(EmailTxt)).SendKeys(email);
        }

        private void EnterMessage(string msg)
        {
            Driver.FindElement(By.XPath(MessageTxt)).SendKeys(msg);
        }

        private void VerifySendFeedbackModalDisappears()
        {
            Assert.That(WaitExtension.WaitInvisibilityOfElement(Driver, By.XPath(SendFeedbackModal), TimeSpan.FromSeconds(30)),
                "The 'Send Feedback' modal is still visible on the screen!!!");
        }
        #endregion

    }
}

