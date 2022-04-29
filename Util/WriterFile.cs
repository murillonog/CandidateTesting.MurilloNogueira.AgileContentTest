using System;
using System.IO;

namespace CandidateTesting.MurilloNogueira.AgileContentTest.Util
{
    internal class WriterFile
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public WriterFile()
        {
            
        }

        public void WriteCdn(string log, string path)
        {
            try
            {
                if (!Directory.Exists($"{path}/output/"))
                    Directory.CreateDirectory($"{path}/output/");

                if (File.Exists($"{path}/output/minhaCdn1.txt"))
                    File.Delete($"{path}/output/minhaCdn1.txt");

                using FileStream fileStream = new FileStream($"{path}/output/minhaCdn1.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                using StreamWriter file = new StreamWriter(fileStream);

                file.WriteLine("#Version: 1.0");
                file.WriteLine($"#Date: {DateTime.Now}");
                file.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
                foreach (var line in log.Split("\r\n"))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var split = line.Split('|');
                        if (line.Contains("INVALIDATE"))
                            file.WriteLine($"\"MINHA CDN\" {split[3].Split(" ")[0].Replace("'\'", "").Replace("\"","")} {split[1]} {split[3].Split(" ")[1]} {split[4].Split(".")[0]} {split[0]} REFRESH_HIT");
                        else
                            file.WriteLine($"\"MINHA CDN\" {split[3].Split(" ")[0].Replace("'\'","").Replace("\"", "")} {split[1]} {split[3].Split(" ")[1]} {split[4].Split(".")[0]} {split[0]} {split[2]}");
                    }
                }
                Success = true;
            }
            catch (Exception exception)
            {
                Success = false;
                Error = exception.Message;
            }
        }
    }
}
