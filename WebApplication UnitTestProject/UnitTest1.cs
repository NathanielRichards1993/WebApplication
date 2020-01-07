using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using WebApplication.Pages;
using System;

namespace WebApplication_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetNewServerAndAlarmData_version1_expectedPass()
        {
            //setup
            var Index = new IndexModel();
            Index.m_InsertText = "The alarm id from video server number 7 is 10.";
            
            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == 10 && int.Parse(Index.m_ServerNumber) == 7);
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_version2_expectedPass()
        {
            //setup
            var Index = new IndexModel();
            Index.m_InsertText = "Alarm id 10 has been received from video server number 7.";

            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == 10 && int.Parse(Index.m_ServerNumber) == 7);
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_LargeNumbers_expectedPass()
        {
            //setup
            var Index = new IndexModel();
            Index.m_InsertText = "The alarm id from video server number 100000000 is 10000000.";

            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(long.Parse(Index.m_AlarmNumber) == 10000000 && long.Parse(Index.m_ServerNumber) == 100000000);
        }

        [TestMethod]
        public void GetDefault_expectedPass()
        {
            //setup
            var Index = new IndexModel();

            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(Index.m_AlarmNumber == "empty" && Index.m_ServerNumber == "empty");
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_version3_expectedPass()
        {

            //setup
            var Index = new IndexModel();
            Index.m_InsertText = "Alarm id 10 has been received from video server number 7.";

            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == 10 && int.Parse(Index.m_ServerNumber) == 7);


            //next entry
            Index.m_InsertText = "Alarm id 18 has been received from video server number 2.";
            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == 18 && int.Parse(Index.m_ServerNumber) == 2);
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_Random1000_expectedPass()
        {
            Random rng = new Random();
            var Index = new IndexModel();
            const int size = 1000;
            int alarmNumber = 0;
            int serverNumber = 0;
            for (int iter = 0; iter < size; ++iter)
            {
                alarmNumber = rng.Next();
                serverNumber = rng.Next();
                //setup
                Index.m_InsertText = "The alarm id from video server number " + serverNumber + " is " + alarmNumber + ".";
                //Excuting
                Index.OnPost();
                //checking result
                Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == alarmNumber && int.Parse(Index.m_ServerNumber) == serverNumber);
            }
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_Random1000OtherFormat_expectedPass()
        {
            Random rng = new Random();
            var Index = new IndexModel();
            const int size = 1000;
            int alarmNumber = 0;
            int serverNumber = 0;
            for (int iter = 0; iter < size; ++iter)
            {
                alarmNumber = rng.Next();
                serverNumber = rng.Next();
                //setup
                Index.m_InsertText = "Alarm id " + alarmNumber + " has been received from video server number " + serverNumber + ".";
                //Excuting
                Index.OnPost();
                //checking result
                Assert.IsTrue(int.Parse(Index.m_AlarmNumber) == alarmNumber && int.Parse(Index.m_ServerNumber) == serverNumber);
            }
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_CheckingFormat_expectedPass()
        {

            var Index = new IndexModel();


            //setup
            Index.m_InsertText = "Alarm id 7 has been recd from video server number 6.";
            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(Index.m_AlarmNumber == "empty" && Index.m_ServerNumber == "empty");
        }

        [TestMethod]
        public void SetNewServerAndAlarmData_CheckingFormatOther_expectedPass()
        {
            var Index = new IndexModel();

            //setup
            Index.m_InsertText = "The alarm id fm video server number 7 is 10.";
            //Excuting
            Index.OnPost();
            //checking result
            Assert.IsTrue(Index.m_AlarmNumber == "empty" && Index.m_ServerNumber == "empty");

        }


    }
}
