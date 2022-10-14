using CommonCompressors;
using Ionic.Zip;
using LibEveryFileExplorer.Files.SimpleFileSystem;
using NDS.NitroSystem.FND;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SZS_Tool {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            List<string> Args = new List<string>();
           
            foreach (string arg in Environment.GetCommandLineArgs())  
            {  
                Args.Add(arg);  
            }
            
            var t = "";
            
            foreach (string a in Args)
            {
                if (a == "compress" || a == "-c"){
                    t = "c";
                    Console.WriteLine(t);
                    continue;
                }
                else if (a == "decompress" || a == "-d"){
                    t = "d";
                    Console.WriteLine(t);
                    continue;
                }

                if (a == Args.Last())
                {
                    Environment.Exit(0);
                }


                var arg1 = a; // arg1 one is input
                var arg2 = Args[Args.IndexOf(a) + 1]; // arg2 is output
                if (Args.IndexOf(a) % 2 != 0 || a == Args[0]) //skips all odd items in list
                    {
                        Console.WriteLine("continue");
                        continue;
                    }
                
                Console.WriteLine(Args.IndexOf(a));
                Console.WriteLine(a);
                Console.WriteLine();

                if (t == "c")
                {
                    var zip = arg1;
                    YAZ0 y = new YAZ0();
                    NARC SzsArch = new NARC();
                    SFSDirectory dir = new SFSDirectory("", true);
                    using(ZipFile z = ZipFile.Read(zip)) {
                        for(int i = 0; i < z.Entries.Count; i++) {
                            ZipEntry ze = z.Entries.ToArray()[i];
                            SFSFile file = new SFSFile(i, ze.FileName, dir);
                            MemoryStream data = new MemoryStream();
                            ze.Extract(data);
                            file.Data = data.ToArray();
                            data.Dispose();
                            dir.Files.Add(file);
                        }
                        foreach(ZipEntry ze in z) {
                            Console.WriteLine(ze);
                        }
                    }
                    SzsArch.FromFileSystem(dir);
                    File.WriteAllBytes(arg2, y.Compress(SzsArch.Write()));
                    Console.WriteLine("Done");
                } else if (t == "d") {
                    string of = arg1;
                    if(IsYaz0(of)) {
                        string ep = arg2;
                        Directory.CreateDirectory(ep);
                        YAZ0 y = new YAZ0();
                        NARC f = new NARC(y.Decompress(File.ReadAllBytes(of)));
                        foreach(SFSFile file in f.ToFileSystem().Files) {
                            Console.WriteLine(file.FileName);
                            File.WriteAllBytes(ep + "\\" + file.FileName, file.Data);
                            Console.WriteLine("Done!");
                        }
                    } else {
                        Console.WriteLine("The SZS file is not compressed with Yaz0.");
                    }
                }
            }
            Environment.Exit(0);
        }    
        private bool IsYaz0(string f) {
            byte[] b = File.ReadAllBytes(f);
            return (b[0] == 89 && b[1] == 97 && b[2] == 122 && b[3] == 48);
        }
       
        
    }

}
