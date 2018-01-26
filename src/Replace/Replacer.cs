using System;
using System.IO;
using System.Linq;

namespace Replace
{
    public static class Replacer
    {
        public static void ReplaceFolder(string searchFolder, string searchString, string newString, bool replaceFolders = true, bool replaceFiles = true)
        {
            ReplaceDirectory(new DirectoryInfo(searchFolder), searchString, newString, replaceFolders, replaceFiles);

        }

        public static void ReplaceDirectory(DirectoryInfo searchDirectoryInfo, string searchString, string newString, bool replaceFolders = true, bool replaceFiles = true)
        {
            var directoryInfo = searchDirectoryInfo;

            if (directoryInfo.Name.Contains(searchString))
            {
                var DirectoryFullName = directoryInfo.FullName;
                DirectoryFullName = Path.Combine(directoryInfo.FullName.Substring(0, directoryInfo.FullName.Length - directoryInfo.Name.Length), directoryInfo.FullName.Substring(directoryInfo.FullName.Length - directoryInfo.Name.Length).Replace(searchString, newString));
                directoryInfo.MoveTo(DirectoryFullName);
                directoryInfo = new DirectoryInfo(DirectoryFullName);
            }

            foreach(var fileInfo in directoryInfo.EnumerateFiles().ToList())
            {
                if (fileInfo.Name.Contains(searchString))
                {
                    fileInfo.MoveTo(Path.Combine(directoryInfo.FullName,fileInfo.Name.Replace(searchString, newString)));
                }
            }

            foreach(var subDirectoryInfo in directoryInfo.EnumerateDirectories().ToList())
            {
                ReplaceDirectory(subDirectoryInfo, searchString, newString, replaceFolders, replaceFiles);
            }

        }
    }
}