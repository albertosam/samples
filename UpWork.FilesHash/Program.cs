using System;
using System.Diagnostics;

namespace UpWork.FilesHash
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHash fh = new FileHash();

            var _file1_256 = fh.GenerateHash(@"D:\Downloads\Flutter-Dribbble-Challenge-master.zip", true);
            var _file1_512 = fh.GenerateHash(@"D:\Downloads\Flutter-Dribbble-Challenge-master.zip", false);

            Console.WriteLine("Small File");
            Console.WriteLine("256----------------------------");
            Console.WriteLine(_file1_256.ToString());
            Console.WriteLine("512----------------------------");
            Console.WriteLine(_file1_512.ToString());

            var _file2_256 = fh.GenerateHash(@"D:\Downloads\android-studio-ide-182.4954005-windows.zip", true);
            var _file2_512 = fh.GenerateHash(@"D:\Downloads\android-studio-ide-182.4954005-windows.zip", false);

            Console.WriteLine("\n\nMedium File");
            Console.WriteLine("256----------------------------");
            Console.WriteLine(_file2_256.ToString());
            Console.WriteLine("512----------------------------");
            Console.WriteLine(_file2_512.ToString());

            var _file3_256 = fh.GenerateHash(@"D:\Midias\Midia video.mkv", true);
            var _file3_512 = fh.GenerateHash(@"D:\Midias\Midia video.mkv", true);

            Console.WriteLine("\n\nBig File");
            Console.WriteLine("256----------------------------");
            Console.WriteLine(_file3_256.ToString());
            Console.WriteLine("512----------------------------");
            Console.WriteLine(_file3_512.ToString());
        }
    }
}
