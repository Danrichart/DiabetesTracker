using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiabetesApp.Models;
using System.Collections.Generic;

/*
 * I'm using TDD To create a service layer to remove complexity 
 * from controllers. I want to use a dbcontext initialized in this layer,
 * followed by several methods that can be accessed by the controllers. 
 * 
 */ 
namespace DiabetesApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //create service layer that inits dbcontext
            var service = new AppService();
            
            //getHistoryData()


        }
    }
}
