using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UpWork.FilesHash
{
    public class FileDetail
    {
        public string Hash { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public long Miliseconds { get; set; }

        public string ToString()
        {
            var sizeInfo = GetSize(Size);

            var str = $"Path: {Path} \nSize: {sizeInfo.Item1} {sizeInfo.Item2} \nMiliseconds: {Miliseconds} \nHash: {Hash}";
            return str;
        }

        public (double, string) GetSize(double bytes, int level = 0)
        {
            if (bytes > 1024 && level <= 3)
            {
                level++;
                return GetSize(Math.Round(bytes/1024,2), level);
            }
            else
                return (bytes, GetSuffix(level));
        }

        public string GetSuffix(int level)
        {
            string suffix = string.Empty;
            // "bytes", "KB", "MB", "GB", "TB"
            switch (level)
            {
                case 0: suffix = "bytes";
                    break;
                case 1:
                    suffix = "KB";
                    break;
                case 2:
                    suffix = "MB";
                    break;
                case 3:
                    suffix = "GB";
                    break;
                case 4:
                    suffix = "TB";
                    break;
                default:
                    break;
            }

            return suffix;
        }
    }

    public class FileHash
    {
        private readonly SHA256 _sha256 = SHA256.Create();
        private readonly SHA512 _sha512 = SHA512.Create();

        public FileDetail GenerateHash(string path, bool is256)
        {
            Stopwatch sw = new Stopwatch();
            byte[] bytesHash = null;
            long size;
            sw.Start();
            using (var fileStream = File.OpenRead(path))
            {
                if (is256)
                    bytesHash = _sha256.ComputeHash(fileStream);
                else
                    bytesHash = _sha512.ComputeHash(fileStream);
                size = fileStream.Length;
            }
            sw.Stop();

            return new FileDetail { Hash = ToString(bytesHash), Size = size, Path = path, Miliseconds = sw.ElapsedMilliseconds };
        }

        private string ToString(byte[] bytes)
        {
            string result = string.Empty;
            foreach (var b in bytes)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}