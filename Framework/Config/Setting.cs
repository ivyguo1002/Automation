using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Config
{
    public class Setting
    {
        [JsonProperty(PropertyName = "BaseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty(PropertyName = "IdentityAPI")]
        public string IdentityAPI { get; set; }
        [JsonProperty(PropertyName = "TalentAPI")]
        public string TalentAPI { get; set; }
        [JsonProperty(PropertyName = "ReportPath")]
        public string ReportPath { get; set; }
        [JsonProperty(PropertyName = "ScreenshotPath")]
        public string ScreenshotPath { get; set; }


    }

}
