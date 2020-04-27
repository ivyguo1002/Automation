using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Framework.Helper
{
    public class JsonDataHelper
    {
        public static Ttype ToObject<Ttype>(string filePath)
        {
            var path = PathHelper.BaseDir() + filePath;

            if (!File.Exists(path))
            {
                throw new ArgumentNullException("The data file doesn't exist");
            }

            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Ttype>(data);
        }
    }
}
