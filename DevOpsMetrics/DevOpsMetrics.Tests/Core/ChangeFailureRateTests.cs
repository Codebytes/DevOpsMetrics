using DevOpsMetrics.Core;
using DevOpsMetrics.Service.Models.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevOpsMetrics.Tests.Core
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestCategory("UnitTest")]
    [TestClass]
    public class ChangeFailureRateTests
    {

        [TestMethod]
        public void ChangeFailureRateEliteTest()
        {
            //Arrange
            ChangeFailureRate metrics = new ChangeFailureRate();
            int numberOfDays = 1;
            List<KeyValuePair<DateTime, bool>> changeFailureRateList = new List<KeyValuePair<DateTime, bool>>
            {
                new KeyValuePair<DateTime, bool>(DateTime.Now, true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(1), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(2), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(3), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(4), true)
            };

            //Act
            float result = metrics.ProcessChangeFailureRate(changeFailureRateList, numberOfDays);
            ChangeFailureRateModel model = new ChangeFailureRateModel
            {
                ChangeFailureRateMetric = result,
                ChangeFailureRateMetricDescription = metrics.GetChangeFailureRateRating(result),
                IsProjectView = false
            };

            //Assert
            Assert.IsTrue(model != null);
            Assert.AreEqual(0f, model.ChangeFailureRateMetric);
            Assert.AreEqual("Elite", model.ChangeFailureRateMetricDescription);
            Assert.AreEqual(false, model.IsProjectView);
        }

        [TestMethod]
        public void ChangeFailureRateHighTest()
        {
            //Arrange
            ChangeFailureRate metrics = new ChangeFailureRate();
            int numberOfDays = 7;
            List<KeyValuePair<DateTime, bool>> changeFailureRateList = new List<KeyValuePair<DateTime, bool>>
            {
                new KeyValuePair<DateTime, bool>(DateTime.Now, true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(1), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(2), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(3), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(4), false)
            };

            //Act
            float result = metrics.ProcessChangeFailureRate(changeFailureRateList, numberOfDays);
            string rating = metrics.GetChangeFailureRateRating(result);

            //Assert
            Assert.AreEqual(0.2f, result);
            Assert.AreEqual("High", rating);
        }

        [TestMethod]
        public void ChangeFailureRateMediumTest()
        {
            //Arrange
            ChangeFailureRate metrics = new ChangeFailureRate();
            int numberOfDays = 7;
            List<KeyValuePair<DateTime, bool>> changeFailureRateList = new List<KeyValuePair<DateTime, bool>>
            {
                new KeyValuePair<DateTime, bool>(DateTime.Now, true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(1), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(2), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(3), false),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(4), false)
            };

            //Act
            float result = metrics.ProcessChangeFailureRate(changeFailureRateList, numberOfDays);
            string rating = metrics.GetChangeFailureRateRating(result);

            //Assert
            Assert.AreEqual(0.4f, result);
            Assert.AreEqual("Medium", rating);
        }

        [TestMethod]
        public void ChangeFailureRateLowTest()
        {
            //Arrange
            ChangeFailureRate metrics = new ChangeFailureRate();
            int numberOfDays = 7;
            List<KeyValuePair<DateTime, bool>> changeFailureRateList = new List<KeyValuePair<DateTime, bool>>
            {
                new KeyValuePair<DateTime, bool>(DateTime.Now, true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(1), true),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(2), false),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(3), false),
                new KeyValuePair<DateTime, bool>(DateTime.Now.AddDays(4), false)
            };

            //Act
            float result = metrics.ProcessChangeFailureRate(changeFailureRateList, numberOfDays);
            string rating = metrics.GetChangeFailureRateRating(result);

            //Assert
            Assert.AreEqual(0.6f, result);
            Assert.AreEqual("Low", rating);
        }

        [TestMethod]
        public void ChangeFailureRateNullTest()
        {
            //Arrange
            ChangeFailureRate metrics = new ChangeFailureRate();
            int numberOfDays = 1;
            List<KeyValuePair<DateTime, bool>> changeFailureRateList = null;

            //Act
            float result = metrics.ProcessChangeFailureRate(changeFailureRateList, numberOfDays);
            string rating = metrics.GetChangeFailureRateRating(result);

            //Assert
            Assert.AreEqual(-1, result);
            Assert.AreEqual("None", rating);
        }

    }
}