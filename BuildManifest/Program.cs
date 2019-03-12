using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BuildManifest
{
    class Program
    {
        public class CreateFileOrFolder
        {
            public static void Main(string[] args)
            {

                string path = @"E:\Manifest\Assets";
                var target = @"E:\Manifest\Out";
                string[] dirs = Directory.GetFiles(path);
                string projectmanifest = @"E:\Manifest\Out\project.manifest";
                string versionmanifest = @"E:\Manifest\Out\version.manifest";

                if (!File.Exists(projectmanifest))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(projectmanifest))
                    {
                        sw.WriteLine("{");
                        sw.WriteLine($" \"packageUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest\",");
                        sw.WriteLine($" \"remoteManifestUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest \",");
                        sw.WriteLine($" \"remoteVersionUrl\" : \"http://192.168.1.132:80/assets/taixiu/version.manifest\",");
                        sw.WriteLine($" \"version\" : \"1.0.1\",");
                        sw.WriteLine($"	\"engineVersion\" : \"cocos2djs3.13\",");
                        sw.WriteLine($"	\"assets\" : ");

                    }

                }
                if (!File.Exists(versionmanifest))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(projectmanifest))
                    {
                        sw.WriteLine("{");
                        sw.WriteLine($" \"packageUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest\",");
                        sw.WriteLine($" \"remoteManifestUrl\" : \"http://192.168.1.132:80/assets/taixiu/project.manifest \",");
                        sw.WriteLine($" \"remoteVersionUrl\" : \"http://192.168.1.132:80/assets/taixiu/version.manifest\",");
                        sw.WriteLine($" \"version\" : \"1.0.1\",");
                        sw.WriteLine($"	\"engineVersion\" : \"cocos2djs3.13\",");
                        sw.WriteLine($"	\"assets \" : \",");


                    }

                }

                foreach (string dir in Directory.EnumerateFiles(path, "*"))
                {
                    Console.WriteLine($" \"");
                    Console.WriteLine(dir);
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(dir))
                        {
                            using (StreamWriter sw = File.AppendText(projectmanifest))
                            {
                                //{ "js/animations.js":{ "md5":"bfb6068ed1278267dcb486caff4ca07f"},{
                                sw.WriteLine(dir);
                                sw.WriteLine("\": \"");


                                sw.WriteLine(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty));

                            }


                         
                        }
                    }

                    Console.WriteLine("}");
             

                    //using (StreamReader sr = File.OpenText(projectmanifest))
                    //{
                    //    string s;
                    //    while ((s = sr.ReadLine()) != null)
                    //    {
                    //        Console.WriteLine(s);
                    //    }
                    //}

                }



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
}
