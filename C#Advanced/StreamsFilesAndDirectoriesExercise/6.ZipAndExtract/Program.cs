using System;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\pictures", @"D:\pic\archive.zip");
            ZipFile.ExtractToDirectory(@"D:\pic\archive.zip", @"D:\pictures\New folder");
        }
    }
}
