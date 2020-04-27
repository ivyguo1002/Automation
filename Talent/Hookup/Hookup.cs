using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Framework.Config;
using Framework.Helper;

namespace Talent.Hookup
{
    [TestClass]
    public static class Hookup
    {
        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            ConfigManager.LoadConfiguration();
            ReportManager.StartReporter();
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            ReportManager.Flush();
        }
    }
}
