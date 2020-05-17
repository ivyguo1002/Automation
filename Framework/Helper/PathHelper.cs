using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Framework.Helper
{
    public class PathHelper
    {
        public static string BaseDir()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return currentDirectory.Split(new string[] { "bin"}, StringSplitOptions.None)[0];
        }
        public static string GetAbsolutePath(string filePath)
        {
            var path = PathHelper.BaseDir() + filePath;
            return path;
        }

    }
}
