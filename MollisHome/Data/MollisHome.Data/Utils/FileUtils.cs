namespace MollisHome.Data.Utils
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class FileUtils
    {
        public static string GetAssemblyFileName() => GetAssemblyPath().Split(@"\").Last();
        public static string GetAssemblyDir() => Path.GetDirectoryName(GetAssemblyPath());
        public static string GetAssemblyPath() => Assembly.GetExecutingAssembly().Location;
        public static string GetSolutionFileName() => GetSolutionPath().Split(@"\").Last();
        public static string GetSolutionDir() => Directory.GetParent(GetSolutionPath()).FullName;
        public static string GetSolutionPath()
        {
            string currentDirPath = GetAssemblyDir();
            while (currentDirPath != null)
            {
                string[] fileInCurrentDir = Directory.GetFiles(currentDirPath).Select(f => f.Split(@"\").Last()).ToArray();
                string solutionFileName = fileInCurrentDir.SingleOrDefault(f => f.EndsWith(".sln", StringComparison.InvariantCultureIgnoreCase));
                if (solutionFileName != null)
                {
                    return Path.Combine(currentDirPath, solutionFileName);
                }
                currentDirPath = Directory.GetParent(currentDirPath)?.FullName;
            }

            throw new FileNotFoundException("Cannot find solution file path");
        }
    }
}
