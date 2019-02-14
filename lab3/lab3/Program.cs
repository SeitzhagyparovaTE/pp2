using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab3_FarManager 
{

    class FarManager
    {
        public int cursor;
        public bool ok;
        public string path;
        public int sz;

        public FarManager()
        {
            cursor = 1;
            ok = true;
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
            {
                cursor = sz - 1;
            }

        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
            {
                cursor = 0;
            }
        }
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {

                Console.BackgroundColor = ConsoleColor.Black;

                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        public void Show(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            List<FileSystemInfo> li = new List<FileSystemInfo>();
            li.AddRange(d.GetDirectories());
            li.AddRange(d.GetFiles());
            FileSystemInfo[] fsi = li.ToArray();
            sz = fsi.Length;
            int index = 0;
            foreach (FileSystemInfo fs in fsi)
            {

                if (ok && fs.Name.StartsWith("."))
                {
                    sz--;
                    continue;
                }
                int i = index + 1;
                Color(fs, index);
                Console.WriteLine(i + "." + fs.Name);

                index++;

            }
        }
        public void Start(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            ConsoleKeyInfo cki = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    d = d.Parent;
                    path = d.FullName;
                }
                if (cki.Key == ConsoleKey.UpArrow)
                {
                    Up();
                }
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    Down();
                }
                if (cki.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                }
                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    ok = true;
                }
                if (cki.Key == ConsoleKey.D)
                {
                    int k = 0;
                    DirectoryInfo d1 = new DirectoryInfo(path);
                    List<FileSystemInfo> li = new List<FileSystemInfo>();
                    li.AddRange(d1.GetDirectories());
                    li.AddRange(d1.GetFiles());
                    FileSystemInfo[] fsi1 = li.ToArray();
                    for (int i = 0; i < fsi1.Length; i++)
                    {
                        if (ok && fsi1[i].Name.StartsWith("."))
                        {
                            continue;
                        }
                        if (cursor == k)
                        {
                            fs = fsi1[i];
                            break;
                        }
                        k++;
                    }
                    Delete(fs, fs.FullName);
                }
                if (cki.Key == ConsoleKey.R)
                {
                    int k = 0;
                    DirectoryInfo d1 = new DirectoryInfo(path);
                    List<FileSystemInfo> li = new List<FileSystemInfo>();
                    li.AddRange(d1.GetDirectories());
                    li.AddRange(d1.GetFiles());
                    FileSystemInfo[] fsi1 = li.ToArray();
                    for (int i = 0; i < fsi1.Length; i++)
                    {
                        if (ok && fsi1[i].Name.StartsWith("."))
                        {
                            continue;
                        }
                        if (cursor == k)
                        {
                            fs = fsi1[i];
                            break;
                        }
                        k++;
                    }
                    string pr = new DirectoryInfo(fs.FullName).Parent.FullName;
                    Console.SetCursorPosition(5, 30);
                    Console.Write("Enter file name: ");
                    string newname = Console.ReadLine();
                    if (fs.GetType() == typeof(FileSystemInfo))
                    {
                        File.Move(fs.FullName, pr + "//" + newname);
                    }
                    else
                    {
                        Directory.Move(fs.FullName, pr + "//" + newname);
                    }


                }

                if (cki.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    List<FileSystemInfo> li = new List<FileSystemInfo>();
                    li.AddRange(d.GetDirectories());
                    li.AddRange(d.GetFiles());
                    FileSystemInfo[] fsi1 = li.ToArray();
                    for (int i = 0; i < fsi1.Length; i++)
                    {
                        if (ok && fsi1[i].Name.StartsWith("."))
                        {
                            continue;
                        }
                        if (cursor == k)
                        {
                            fs = fsi1[i];
                            break;

                        }


                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        d = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                    else
                    {
                        OpenFile(fs.FullName);
                    }
                }
            }

        }

        private void Delete(FileSystemInfo fs, string path)
        {

            if (fs.GetType() == typeof(DirectoryInfo))
            {
                Directory.Delete(path, true);
            }
            else
            {
                File.Delete(path);
            }
            Console.Clear();

        }
        public void OpenFile(string path)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            DirectoryInfo d = new DirectoryInfo(path);
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = null;
            int cnt = 0;
            do
            {
                line = sr.ReadLine();
                Console.SetCursorPosition(10, cnt++);
                Console.WriteLine(line);
            }
            while (line != null);
            Console.ReadKey();
            Console.Clear();
            sr.Close();
            fs.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarManager farManager = new FarManager();
            farManager.Start(@"C:\Users\Тогжан\Desktop\PP2");
        }
    }
}