using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json; 
using System;
using Microsoft.Azure.Documents;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace APITestingAutomationFramework
{
    public class Program
    {
        string BaseUri = Properties.Settings.Default.Uri;

        [Test]
        public void GetMethod()
        {
           
            var client = new RestClient(BaseUri);
            var request = new RestRequest(BaseUri, Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json; 

            RestResponse restResponse = client.Execute(request);
            var StatusCode = restResponse.StatusCode;
            Console.WriteLine(StatusCode);
            var content = restResponse.Content;
            Console.WriteLine(content);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

        [Test]
        public void PostMethod()
        {
            string body = Properties.Settings.Default.body; 
            var client = new RestClient(BaseUri);
            var request = new RestRequest(BaseUri, Method.Post); 
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddBody(body); 
            request.RequestFormat = DataFormat.Json;
            RestResponse restResponse = client.Execute(request); 
            var StatusCode = restResponse.StatusCode;
            Console.WriteLine(StatusCode);
            Assert.AreEqual(201, (int) restResponse.StatusCode);
            Assert.AreEqual(body, Properties.Settings.Default.body);
            //Console.WriteLine(body);
            //Console.WriteLine(Properties.Settings.Default.body);    
         }


        [Test]
        public void PutMethod()
        {
            string putBody = Properties.Settings.Default.putBody;
            string putUri = Properties.Settings.Default.putUri; 
            var client = new RestClient(putUri);
            var request = new RestRequest(putUri, Method.Put);
            request.AddHeader("Content-Type", "applicaion/json; charset=utf-8");
            request.AddBody(putBody);
            request.RequestFormat = DataFormat.Json;
            RestResponse restResponse = client.Execute(request);
            var StatusCode = restResponse.StatusCode;
            //Assert.AreEqual(StatusCode, (int)restResponse.StatusCode);
            Console.WriteLine((StatusCode).ToString() + "  ");
            Console.WriteLine(putBody);
            Console.WriteLine(Properties.Settings.Default.body);
            Assert.AreNotEqual(putBody, Properties.Settings.Default.body); 
        }

        [Test]
        public void DeleteMethod()
        {
            string putUri = Properties.Settings.Default.putUri;
            var client = new RestClient(putUri);
            var request = new RestRequest(putUri, Method.Delete);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;
            RestResponse restResponse = client.Execute(request);
            var StatusCode = restResponse.StatusCode;
            Console.WriteLine((StatusCode).ToString() + "  ");
        }





    }
}