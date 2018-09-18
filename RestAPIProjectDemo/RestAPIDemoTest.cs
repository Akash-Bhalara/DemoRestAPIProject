using System;
using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using UnitTestProject4.DataReader;

namespace RestAPIProjectDemo
{
   
    [TestClass]
    [DeploymentItem(@"Resources\")]
    public class RestAPIDemoTest
    {
        public TestContext TestContext { get; set; }
   
        [TestMethod]  //This Test using NunitFramework
        
        public void RestApiTestingPOST()   //Sample Test Name of REST API POST Method
        {
            string URL = "https://reqres.in/api/users";  //Rest API URL
            string assmeblypath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string scanJobsDataReader = File.ReadAllText(@assmeblypath + "\\Resources\\data.json");
            string RequestBody = scanJobsDataReader;
            
            var client = new RestClient(URL);
            var request = new RestRequest(Method.POST);    //Selecting Rest API Method Type
            request.AddHeader("cache-control", "no-cache");   //Adding required Header
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", RequestBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode); //Verifying Status Code
        }
    }
}
