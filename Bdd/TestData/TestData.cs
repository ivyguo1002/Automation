using Bdd.DataModel;
using Framework.Helper.DataDriven;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Specflow.TestData
{
    public static class TestData
    {
        public static IEnumerable<User> CredentialsExcel(string key)
        {
            var testUsers = Framework.Helper.DataDriven.ExcelDataReader.ReadExcel<User>("TestData\\users.xlsx", "credentials");
            return testUsers.Where(user => user.Key == key);
        }

        public static IEnumerable<User> CredentialsJson(string key)
        {
            var testUsers = JsonDataHelper.ToObject<List<User>>("TestData\\users.json");
            return testUsers.Where(user => user.Key == key);
        }


    }
}
