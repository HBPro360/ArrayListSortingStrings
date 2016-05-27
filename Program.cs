using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArrayListSortingStrings
{
    class Program
    {
        static bool sorted = false;
        static void Main(string[] args)
        {
            
            List<string> al = new List<string>();
            string Answer = string.Empty;
            do
            {
                Console.Write("Enter File Name to Sort: ");
                string filename = Console.ReadLine();

                DirectoryInfo di = new DirectoryInfo(".");
                if (File.Exists(di.FullName + "\\" /*or ' @"\" ' */ + filename))
                {
                    ReadTheFile(al, filename);
                    Label();
                    Print(al);
                    Console.WriteLine();
                    Sort(al);
                    Label();
                    Print(al);
                    Pause();
                }
                else
                {
                    Console.WriteLine(filename + " does not exist!");
                    
                }
                Console.Write("Search Again? Y/N: ");
                Answer = Console.ReadLine();
            } while (Answer.ToLower() == "Y".ToLower());

        }
        static void ReadTheFile(List<string> a, string filename)
        {
            StreamReader sr = new StreamReader(filename);
            sorted = false;
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                a.Add(line);
            }
        }
        static void Sort (List<string> a)
        {
            bool swapped = false;

            do
            {
                swapped = false;
                for (int i = 0; i<a.Count - 1; i++)
                {
                    int j = string.Compare(a[i].ToString(), a[i + 1].ToString());
                    if (j > 0)
                    {
                        string temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                        sorted = true;
                    }
                }
            } while (swapped == true);
        }

        static void Print(List<string> a)
        {
            for(int i=0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        static void Label()
        {
            //Labels the list section according to whether or not the list has been sorted
            if (sorted == false)
            {
                Console.WriteLine("\nNot Sorted:\n");
            }
            else
            {
                Console.WriteLine("\nSorted:\n");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue.....");
            Console.ReadLine();
        }
    }
}
