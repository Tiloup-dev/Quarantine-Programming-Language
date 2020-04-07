using System;
using System.Collections.Generic;
using System.Text;
using lsc;
using System.IO;
using System.Diagnostics;

namespace lsc
{
    public class Parser
    {
        public static void Parse(string path)
        {
            string currentstringdata = "";
            string currentstringdata2 = "";
            char currentchardata = ' ';
            char currentchardata2 = ' ';
            int currentintdata = 0;
            int currentintdata2 = 0;
            bool currentbooldata = false;
            bool currentbooldata2 = false;

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                //NORMAL PRINTS
                if (line.Contains("print:"))
                {
                    int pointer = line.IndexOf(':') + 1;
                    string writethat = line.Substring(pointer, line.Length - 6);
                    Console.Write(writethat);
                }
                else if (line.Contains("println:"))
                {
                    int pointer = line.IndexOf(':') + 1;
                    string writethat = line.Substring(pointer, line.Length - 8);
                    Console.Write(writethat + "\n");
                }
                //STRING PRINTS
                else if (line.Contains("print(string)"))
                {
                    Console.Write(currentstringdata);
                }
                else if (line.Contains("println(string)"))
                {
                    Console.Write(currentstringdata + "\n");
                }
                //SECOND STRING PRINTS
                else if (line.Contains("print(string2)"))
                {
                    Console.Write(currentstringdata2);
                }
                else if (line.Contains("println(string2)"))
                {
                    Console.Write(currentstringdata2 + "\n");
                }
                //CHAR PRINTS
                else if (line.Contains("print(char)"))
                {
                    Console.Write(currentchardata);
                }
                else if (line.Contains("println(char)"))
                {
                    Console.Write(currentchardata + "\n");
                }
                //SECOND CHAR PRINTS
                else if (line.Contains("print(char2)"))
                {
                    Console.Write(currentchardata2);
                }
                else if (line.Contains("println(char2)"))
                {
                    Console.Write(currentchardata2 + "\n");
                }
                //INTEGER PRINTS
                else if (line.Contains("print(int)"))
                {
                    Console.Write(currentintdata);
                }
                else if (line.Contains("println(int)"))
                {
                    Console.Write(currentintdata + "\n");
                }
                //SECOND INTEGER PRINTS
                else if (line.Contains("print(int2)"))
                {
                    Console.Write(currentintdata2);
                }
                else if (line.Contains("println(int2)"))
                {
                    Console.Write(currentintdata2 + "\n");
                }

                //BOOLEAN PRINTS
                else if (line.Contains("print(bool)"))
                {
                    Console.Write(currentbooldata);
                }
                else if (line.Contains("print(bool2)"))
                {
                    Console.Write(currentbooldata2);
                }
                else if (line.Contains("println(bool)"))
                {
                    Console.Write(currentbooldata + "\n");
                }
                else if (line.Contains("println(bool2)"))
                {
                    Console.Write(currentbooldata2 + "\n");
                }

                //ADDITIONS
                if (line.Contains("add(int)"))
                {
                    currentintdata = currentintdata + currentintdata2;
                }
                else if (line.Contains("add(int2)"))
                {
                    currentintdata2 = currentintdata + currentintdata2;
                }

                //SUBSTRACTIONS
                if (line.Contains("sub(int)[int]"))
                {
                    currentintdata = currentintdata - currentintdata2;
                }
                else if (line.Contains("sub(int2)[int]"))
                {
                    currentintdata2 = currentintdata - currentintdata2;
                }
                else if (line.Contains("sub(int)[int2]"))
                {
                    currentintdata = currentintdata2 - currentintdata;
                }
                else if (line.Contains("sub(int2)[int2]"))
                {
                    currentintdata2 = currentintdata2 - currentintdata;
                }

                //MULTIPLICATIONS
                if (line.Contains("mul(int)"))
                {
                    currentintdata = currentintdata * currentintdata2;
                }
                else if (line.Contains("mul(int2)"))
                {
                    currentintdata2 = currentintdata * currentintdata2;
                }

                //DIVIDE
                if (line.Contains("div(int)[int]"))
                {
                    currentintdata = currentintdata / currentintdata2;
                }
                else if (line.Contains("div(int2)[int]"))
                {
                    currentintdata2 = currentintdata / currentintdata2;
                }
                else if (line.Contains("div(int)[int2]"))
                {
                    currentintdata = currentintdata2 / currentintdata;
                }
                else if (line.Contains("div(int2)[int2]"))
                {
                    currentintdata2 = currentintdata2 / currentintdata;
                }

                //STRINGS
                if (line.Contains("string:"))
                {
                    currentstringdata = "";
                    int pointer = line.IndexOf(':') + 1;
                    currentstringdata = line.Substring(pointer, line.Length - 7);
                }
                else if (line.Contains("string(readline)"))
                {
                    currentstringdata = "";
                    currentstringdata = Console.ReadLine();
                }
                //SECOND STRINGS
                else if (line.Contains("string2:"))
                {
                    currentstringdata2 = "";
                    int pointer = line.IndexOf(':') + 1;
                    currentstringdata2 = line.Substring(pointer, line.Length - 8);
                }
                else if (line.Contains("string2(readline)"))
                {
                    currentstringdata2 = "";
                    currentstringdata2 = Console.ReadLine();
                }
                //TRANSFORM METHODS
                else if (line.Contains("string(transform)[string][1,2]"))
                {
                    currentstringdata = currentstringdata + currentstringdata2;
                }
                else if (line.Contains("string(transform)[string2][1,2]"))
                {
                    currentstringdata2 = currentstringdata + currentstringdata2;
                }
                else if (line.Contains("string(transform)[string][2,1]"))
                {
                    currentstringdata = currentstringdata2 + currentstringdata;
                }
                else if (line.Contains("string(transform)[string2][2,1]"))
                {
                    currentstringdata2 = currentstringdata2 + currentstringdata;
                }
                //INTS
                if (line.Contains("integer:"))
                {
                    currentintdata = 0;
                    int pointer = line.IndexOf(':') + 1;
                    currentintdata = int.Parse(line.Substring(pointer, line.Length - 8));
                }
                else if (line.Contains("integer(readline)"))
                {
                    currentintdata = 0;
                    currentintdata = int.Parse(Console.ReadLine());
                }
                //SECOND INTS
                if (line.Contains("integer2:"))
                {
                    currentintdata2 = 0;
                    int pointer = line.IndexOf(':') + 1;
                    currentintdata2 = int.Parse(line.Substring(pointer, line.Length - 9));
                }
                else if (line.Contains("integer2(readline)"))
                {
                    currentintdata2 = 0;
                    currentintdata2 = int.Parse(Console.ReadLine());
                }

                //CHARACTERS
                if (line.Contains("char:"))
                {
                    currentchardata = ' ';
                    currentchardata = line[5];
                }
                else if (line.Contains("char(read)"))
                {
                    currentchardata = ' ';
                    currentchardata = Console.ReadKey().KeyChar;
                }
                //SECOND CHARACTERS
                else if (line.Contains("char2:"))
                {
                    currentchardata2 = ' ';
                    currentchardata2 = line[6];
                }
                else if (line.Contains("char2(read)"))
                {
                    currentchardata2 = ' ';
                    currentchardata2 = Console.ReadKey().KeyChar;
                }
                else if (line.Contains("char(transform)[string][1,2]"))
                {
                    char[] chars = { currentchardata, currentchardata2 };
                    currentstringdata = new string(chars);
                }
                else if (line.Contains("char(transform)[string2][1,2]"))
                {
                    char[] chars = { currentchardata, currentchardata2 };
                    currentstringdata2 = new string(chars);
                }
                else if (line.Contains("char(transform)[string][2,1]"))
                {
                    char[] chars = { currentchardata2, currentchardata };
                    currentstringdata = new string(chars);
                }
                else if (line.Contains("char(transform)[string2][2,1]"))
                {
                    char[] chars = { currentchardata2, currentchardata };
                    currentstringdata2 = new string(chars);
                }
                //BOOLEANS
                if (line.Contains("bool:"))
                {
                    char value = line[5];
                    int ivalue = int.Parse(value.ToString());
                    if (!(ivalue == 0))
                    {
                        currentbooldata = true;
                    }
                    else
                    {
                        currentbooldata = false;
                    }
                }
                else if (line.Contains("bool2:"))
                {
                    char value = line[6];
                    int ivalue = int.Parse(value.ToString());
                    if (!(ivalue == 0))
                    {
                        currentbooldata2 = true;
                    }
                    else
                    {
                        currentbooldata2 = false;
                    }
                }
                else if (line.Contains("bool(bool2)"))
                {
                    currentbooldata = currentbooldata2;
                }
                else if (line.Contains("bool2(bool)"))
                {
                    currentbooldata2 = currentbooldata;
                }

                if (line.Contains("script:"))
                {
                    string scriptpath = line.Substring(7);
                    if (File.Exists("./" + scriptpath))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo("qlc.exe");
                        startInfo.Arguments = scriptpath;
                        Process.Start(startInfo);
                    }
                    else
                    {
                        Console.WriteLine("Cannot find file \"" + scriptpath + "\".");
                    }
                }

                if (line.Contains("clearvariables"))
                {
                    currentbooldata = false;
                    currentbooldata2 = false;
                    currentchardata = ' ';
                    currentchardata2 = ' ';
                    currentintdata = 0;
                    currentintdata2 = 0;
                    currentstringdata = "";
                    currentstringdata2 = "";
                }

                if (line.Contains("clear"))
                {
                    Console.Clear();
                }
            }
            Console.ReadLine();
        }
    }
}
