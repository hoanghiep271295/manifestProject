using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BuildManifest
{
    internal class Program
    {
        public class CreateFileOrFolder
        {
            public static void Main(string[] args)
            {
             
                string path = @"E:\Manifest\Assets\game";
                string config = @"E:\Manifest\Assets\config.txt";
                string projectmanifest = @"E:\Manifest\Out\project.manifest";
                string versionmanifest = @"E:\Manifest\Out\version.manifest";
               
                string version = "";
                string currentpath = Directory.GetCurrentDirectory();
                Console.WriteLine("currentpath {0}", currentpath);
                Console.WriteLine("Nhập vào version : \n");
                version = Console.ReadLine();
                Console.Write("Ban vua nhap chuoi: {0}\n", version);

                if (new makeFile().makeFilebyConfig(projectmanifest, versionmanifest, config))
                {
                    Console.WriteLine("Make file Success");
                }
                else
                {
                    Console.WriteLine("Make file UnSuccess");
                    return;
                }

                string assets = "";
                int fCount = Directory.GetFiles(path, ".", SearchOption.AllDirectories).Length;
                int count = 0;
                foreach (string dir in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                {
                    //Console.WriteLine(" dir {0}", dir);
                    count++;
                    if (dir.Remove(0, path.Length + 1) == "config.txt")
                    {
                        Console.WriteLine("Khong chua file config");
                    }
                    else
                    {
                        if (count == fCount)
                        {
                            assets += new JSONObject().ConvertToObj(dir, path);
                        }
                        else
                        {
                            assets += new JSONObject().ConvertToObj(dir, path) + ",";
                        }
                    }
                }
            
                string text = File.ReadAllText(projectmanifest);
                text = text.Replace("@_version_@", version);
                text = text.Replace("@_assets_@", assets);
                File.WriteAllText(projectmanifest, text);

                string text1 = File.ReadAllText(versionmanifest);
                text1 = text1.Replace("@_version_@", version);
                text1 = text1.Replace("@_assets_@", "");
                File.WriteAllText(versionmanifest, text);
                
                Console.ReadKey();
            }
        }
    }

    public class makeFile
    {
        public bool makeFilebyConfig(string projectmanifest, string versionmanifest, string config)
        {
            int ret = -1;
            if (File.Exists(config))
            {
                ret = 1;
            }
            if (File.Exists(projectmanifest))
            {
                File.Delete(projectmanifest);
            }
            if (File.Exists(versionmanifest))
            {
                File.Delete(versionmanifest);
            }

            if (!File.Exists(projectmanifest))
            {
                using (FileStream fs = File.Create(projectmanifest))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            if (!File.Exists(versionmanifest))
            {
                using (FileStream fs = File.Create(versionmanifest))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            if (ret == 1)
            {
                string content = File.ReadAllText(config);
                File.AppendAllText(projectmanifest, content);
                File.AppendAllText(versionmanifest, content);
            }

            return true;
        }
    }
}