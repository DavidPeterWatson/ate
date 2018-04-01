using System;
using System.IO;
//using System.Reflection;
using System.Text;

namespace ate.Extensions
{
    public static class FileExtensions
    {


        public static string ReadAllText(this FileInfo FileInfo)
        {
            return System.IO.File.ReadAllText(FileInfo.FullName);
        }

        public static string GetFullPath(string maybeRelativePath, string baseDirectory)
        {
            if (baseDirectory == null) baseDirectory = Environment.CurrentDirectory;
            var root = Path.GetPathRoot(maybeRelativePath);
            if (string.IsNullOrEmpty(root))
                return Path.GetFullPath(Path.Combine(baseDirectory, maybeRelativePath));
            if (root == "\\")
                return Path.GetFullPath(Path.Combine(Path.GetPathRoot(baseDirectory), maybeRelativePath.Remove(0, 1)));
            return maybeRelativePath;
        }

    }
}