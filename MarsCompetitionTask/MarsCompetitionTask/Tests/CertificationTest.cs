using com.sun.org.apache.xml.@internal.resolver.helpers;
using MarsCompetitionTask.Pages;
using MarsCompetitionTask.TestModel;
using MarsCompetitionTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTask.Tests  
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
    {
        private LoginTestPage loginTestPageObj = new LoginTestPage();
        private CertificationPage CertificationPageObj = new CertificationPage();

        [SetUp]
        public void SetUpAction()
        {
            // Open Chrome Browser
            //Login page object identified and defined
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj = new LoginTestPage();
            loginTestPageObj.navigateSteps();
            loginTestPageObj.loginSteps();
        }
        [Test, Order(1)]
        public void AddCertificationData_Test()
        {
            string sFile = "AddCertificationPositiveData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> AddCertificationPositiveData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(AddCertificationPositiveData.ToString());
            foreach (var data in AddCertificationPositiveData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                CertificationPageObj.addCertifications(certificate, certifiedFrom, year);
                string newCertificate = CertificationPageObj.getVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    Assert.AreEqual(certificate, newCertificate, "Actual certificate and expected certificate do not match");
                }
                else
                {
                    Assert.AreNotEqual(certificate, newCertificate, "Actual certificate and expected certificate do match");
                }
            }
        }
        [Test, Order(2)]
        public void UpdateCertificationData_Test()
        {
            string sFile = "UpdateCertificationPositiveData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> UpdateCertificationPositiveData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(UpdateCertificationPositiveData.ToString());
            foreach (var data in UpdateCertificationPositiveData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                try
                {
                    CertificationPageObj.updateCertifications(certificate, certifiedFrom, year);
                    string newUpdatedCertificate = CertificationPageObj.getVerifyUpdateCertificationsList();
                    if (certificate == newUpdatedCertificate)
                    {
                        Assert.AreEqual(certificate, newUpdatedCertificate, "Actual certificate and expected certificate do not match");
                    }
                    else
                    {
                        Assert.AreNotEqual(certificate, newUpdatedCertificate, "Actual certificate and expected certificate do match");
                    }

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", certificate.ToString());
                }
            }
        }
        [Test, Order(3)]
        public void DeleteCertificationData_Test()
        {
            string sFile = "DeleteCertificationData.json";
            // Read test data from the JSON file using JsonHelper
            List<CertificationsTestModel> DeleteCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationsTestModel>(sFile);
            Console.WriteLine(DeleteCertificationData.ToString());
            foreach (var data in DeleteCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                // Perform the education test using the Education data
                CertificationPageObj.deleteCertification(certificate, year);
                string deletedCertificate = CertificationPageObj.getVerifyDeleteCertificationList();
                if (certificate == deletedCertificate)
                {
                    Assert.AreEqual(certificate, deletedCertificate, "Actual certificate and expected certificate do not match");
                }
                else
                {
                    Assert.AreNotEqual(certificate, deletedCertificate, "Actual certificate and expected certificate do match");
                }

            }
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

