using AventStack.ExtentReports.Configuration;
using Framework.Config;
using Framework.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.IdentityAPI
{
    public class IdentityAPI
    {
        public static JToken GetToken(string userEmail, string userPassword)
        {
            var client = new RestClient(ConfigManager.Settings.IdentityAPI);
            var request = new RestRequest("/api/auth/signin", Method.POST);
            request.AddJsonBody(new
            {
                email = userEmail,
                password = userPassword
            });

            var response = client.Execute(request);
            return JObject.Parse(response.Content)["token"];
        }
    }
}