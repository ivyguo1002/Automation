﻿using Framework.Helper.DataDriven;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Config
{
    public class ConfigManager
    {
        public static Setting Settings { get; set; }
        public static void LoadConfiguration()
        {
            Settings = JsonDataHelper.ToObject<Setting>("Configuration\\settings.json");
        }
    }
}
