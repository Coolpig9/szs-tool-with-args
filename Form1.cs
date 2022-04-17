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
            foreach (string a in Args)
            {
                 
                if (a == Args.Last())
                {
                    Environment.Exit(0);
                }

                var arg1 = a;
                var mid = Args.IndexOf(a) + 1;
                var arg2 = Args[mid];
                if (Args.IndexOf(a) % 2 == 0)
                    {
                        Console.WriteLine("even contiueing");
                        Console.WriteLine(Args.IndexOf(a));
                        continue;
                    }
                Console.WriteLine(Args.IndexOf(a));
                Console.WriteLine(a);
                var zip = Args[1];
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
                File.WriteAllBytes(Args[2], y.Compress(SzsArch.Write()));
                Console.WriteLine("Done");
                //Environment.Exit(0);
            }
        }    
        private bool IsYaz0(string f) {
            byte[] b = File.ReadAllBytes(f);
            return (b[0] == 89 && b[1] == 97 && b[2] == 122 && b[3] == 48);
        }
       
        
    }

}
