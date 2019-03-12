using System;
using System.IO;
using System.Text;

namespace BuildManifest
{
    internal class Program
    {
        public class CreateFileOrFolder
        {
            public static void Main(string[] args)
            {
                string path = @"D:\mani\Assets";
                string config = @"D:\mani\Assets\config.txt";
                string projectmanifest = @"D:\mani\Out\project.manifest";
                string versionmanifest = @"D:\mani\Out\version.manifest";

                if (new makeFile().makeFilebyConfig(projectmanifest, versionmanifest, config))
                {
                    Console.WriteLine("Make file Success");
                }
                else
                {
                    Console.WriteLine("Make file UnSuccess");
                    return;
                }

                //if (!File.Exists(projectmanifest))
                //{
                //    // Create a file to write to.
                //    using (StreamWriter sw = File.CreateText(projectmanifest))
                //    {
                //        sw.WriteLine("{");
                //        sw.WriteLine($" \"packageUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest\",");
                //        sw.WriteLine($" \"remoteManifestUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest \",");
                //        sw.WriteLine($" \"remoteVersionUrl\" : \"http://192.168.1.132:80/assets/taixiu/version.manifest\",");
                //        sw.WriteLine($" \"version\" : \"1.0.1\",");
                //        sw.WriteLine($"	\"engineVersion\" : \"cocos2djs3.13\",");
                //        sw.WriteLine($"	\"assets\" : ");
                //    }
                //}

                foreach (string dir in Directory.EnumerateFiles(path, "*"))
                {
                    using (StreamWriter sw = File.AppendText(projectmanifest))
                    {
                        //{ "js/animations.js":{ "md5":"bfb6068ed1278267dcb486caff4ca07f"},{
                        Console.WriteLine(new JSONObject().ConvertToObj(dir));
                        sw.WriteLine(new JSONObject().ConvertToObj(dir));
                    }
                }

                //Console.WriteLine("}");

                //using (StreamReader sr = File.OpenText(projectmanifest))
                //{
                //    string s;
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
                //}

                //try
                //{
                //    string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                //    Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
                //    foreach (string dir in dirs)
                //    {
                //        Console.WriteLine(dir.ToString().Remove(0,11));
                //        if (!System.IO.Directory.Exists(targetPath))
                //        {
                //            System.IO.Directory.CreateDirectory(targetPath);
                //        }
                //    }
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("The process failed: {0}", e.ToString());
                //}

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
                //File.Copy(config, projectmanifest);
                //File.Copy(config, versionmanifest);
                string content = File.ReadAllText(config);
                File.AppendAllText(projectmanifest, content);
                File.AppendAllText(versionmanifest, content);
            }

            return true;
        }
    }
}