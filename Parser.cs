using System;
using System.Collections.Generic;
using System.Text;
using lsc;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Input;
using System.Linq;

namespace lsc
{
    public class Parser
    {
        //Program Variables
        public static bool isInfinite = false;
        public static int loopbacker = 1;
        public static bool isHeader = true;
        public static bool isCustomizable = true;
        public static string line_then = "";
        public static int runInstances = 0;
        public static bool safety = true;


        //New program variables (implemented in 0.01pre_03)
        public static List<string> vars = new List<string>();
        public static List<string> values = new List<string>();

        public static void Parse(string path, bool isPause, string headerpath)
        {

            string[] lines = File.ReadAllLines(path);
        restart:
            foreach (string line in lines)
            {
                bool then = false;
                int linecount = 0;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line[0] == '#')
                    {

                    }
                    else
                    {
                        //NORMAL PRINTS
                        if (line.Contains("print:"))
                        {
                            int pointer = line.IndexOf(':') + 1;
                            string writethat = line.Substring(pointer);
                            Console.Write(writethat);
                        }
                        else if (line.Contains("println:"))
                        {
                            int pointer = line.IndexOf(':') + 1;
                            string writethat = line.Substring(pointer);
                            Console.Write(writethat + "\n");
                        }
                        else if (line.Contains("print?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            string var = line.Substring(pointer);
                            try
                            {
                                Console.Write(values[vars.IndexOf(var)]);
                            }
                            catch
                            {
                                Console.WriteLine("Invalid variable name!");
                            }
                        }
                        else if (line.Contains("println?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            string var = line.Substring(pointer);
                            try
                            {
                                Console.WriteLine(values[vars.IndexOf(var)]);
                            }
                            catch
                            {
                                Console.WriteLine("Invalid variable name!");
                            }
                        }

                        if (line.Contains("var "))
                        {
                            int pointer = line.IndexOf(' ') + 1;
                            int end = line.IndexOf('=') - 5;
                            string name = line.Substring(pointer, end);
                            if (!vars.Contains(name))
                            {
                                vars.Add(name);
                                string value = line.Substring(line.IndexOf('=') + 2);
                                values.Add(value);

                            }
                        }

                        if (line.Contains("int.add"))
                        {
                            int pointer = line.IndexOf("?1") + 2;
                            int second_pointer = line.IndexOf("?2") + 2;
                            int variable = line.IndexOf("?3") + 2;
                            string first_var = line.Substring(pointer, second_pointer - 12);
                            string second_var = line.Substring(second_pointer, line.Length - variable + 1);
                            string var = line.Substring(variable);
                            try
                            {
                                int first_data = int.Parse(values[vars.IndexOf(first_var)]);
                                int second_data = int.Parse(values[vars.IndexOf(second_var)]);
                                int sum = first_data += second_data;
                                if (vars.Contains(var))
                                {
                                    int index = vars.IndexOf(var);
                                    values[index] = sum.ToString();
                                }
                                else
                                {
                                    Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                }
                            }
                            catch
                            {
                                try
                                {
                                    float first_data = float.Parse(values[vars.IndexOf(first_var)]);
                                    float second_data = float.Parse(values[vars.IndexOf(second_var)]);
                                    float sum = first_data += second_data;
                                    if (vars.Contains(var))
                                    {
                                        int index = vars.IndexOf(var);
                                        values[index] = sum.ToString();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Cannot find types of variables!");
                                }
                            }

                        }
                        else if (line.Contains("int.sub"))
                        {
                            int pointer = line.IndexOf("?1") + 2;
                            int second_pointer = line.IndexOf("?2") + 2;
                            int variable = line.IndexOf("?3") + 2;
                            string first_var = line.Substring(pointer, second_pointer - 12);
                            string second_var = line.Substring(second_pointer, line.Length - variable + 1);
                            string var = line.Substring(variable);
                            try
                            {
                                int first_data = int.Parse(values[vars.IndexOf(first_var)]);
                                int second_data = int.Parse(values[vars.IndexOf(second_var)]);
                                int sum = first_data -= second_data;
                                if (vars.Contains(var))
                                {
                                    int index = vars.IndexOf(var);
                                    values[index] = sum.ToString();
                                }
                                else
                                {
                                    Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                }
                            }
                            catch
                            {
                                try
                                {
                                    float first_data = float.Parse(values[vars.IndexOf(first_var)]);
                                    float second_data = float.Parse(values[vars.IndexOf(second_var)]);
                                    float sum = first_data -= second_data;
                                    if (vars.Contains(var))
                                    {
                                        int index = vars.IndexOf(var);
                                        values[index] = sum.ToString();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Cannot find types of variables!");
                                }
                            }
                        }
                        else if (line.Contains("int.mul"))
                        {
                            int pointer = line.IndexOf("?1") + 2;
                            int second_pointer = line.IndexOf("?2") + 2;
                            int variable = line.IndexOf("?3") + 2;
                            string first_var = line.Substring(pointer, second_pointer - 12);
                            string second_var = line.Substring(second_pointer, line.Length - variable + 1);
                            string var = line.Substring(variable);
                            try
                            {
                                int first_data = int.Parse(values[vars.IndexOf(first_var)]);
                                int second_data = int.Parse(values[vars.IndexOf(second_var)]);
                                int sum = first_data *= second_data;
                                if (vars.Contains(var))
                                {
                                    int index = vars.IndexOf(var);
                                    values[index] = sum.ToString();
                                }
                                else
                                {
                                    Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                }
                            }
                            catch
                            {
                                try
                                {
                                    float first_data = float.Parse(values[vars.IndexOf(first_var)]);
                                    float second_data = float.Parse(values[vars.IndexOf(second_var)]);
                                    float sum = first_data *= second_data;
                                    if (vars.Contains(var))
                                    {
                                        int index = vars.IndexOf(var);
                                        values[index] = sum.ToString();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Cannot find types of variables!");
                                }
                            }
                        }
                        else if (line.Contains("int.div"))
                        {
                            int pointer = line.IndexOf("?1") + 2;
                            int second_pointer = line.IndexOf("?2") + 2;
                            int variable = line.IndexOf("?3") + 2;
                            string first_var = line.Substring(pointer, second_pointer - 12);
                            string second_var = line.Substring(second_pointer, line.Length - variable + 1);
                            string var = line.Substring(variable);
                            try
                            {
                                int first_data = int.Parse(values[vars.IndexOf(first_var)]);
                                int second_data = int.Parse(values[vars.IndexOf(second_var)]);
                                int sum = first_data /= second_data;
                                if (vars.Contains(var))
                                {
                                    int index = vars.IndexOf(var);
                                    values[index] = sum.ToString();
                                }
                                else
                                {
                                    Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                }
                            }
                            catch
                            {
                                try
                                {
                                    float first_data = float.Parse(values[vars.IndexOf(first_var)]);
                                    float second_data = float.Parse(values[vars.IndexOf(second_var)]);
                                    float sum = first_data /= second_data;
                                    if (vars.Contains(var))
                                    {
                                        int index = vars.IndexOf(var);
                                        values[index] = sum.ToString();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERR:Cannot find variable " + var + "!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Cannot find types of variables!");
                                }
                            }
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
                                Console.WriteLine("ERR:Cannot find file \"" + scriptpath + "\".");
                            }
                        }

                        if (line.Contains("[Header]"))
                        {
                            if (isHeader)
                            {
                                if (File.Exists("./" + headerpath))
                                {
                                    ProcessStartInfo startInfo = new ProcessStartInfo("qlc.exe");
                                    startInfo.Arguments = headerpath;
                                    Process.Start(startInfo);
                                }
                                else
                                {
                                    Console.WriteLine("WARN:No headers where executed, wich means variables given by the header are the same has before.");
                                }
                            }
                        }

                        if (line.Contains("[Property:Header]="))
                        {
                            int pointer = line.IndexOf('=');
                            string data = line.Substring(pointer);
                            data.ToLower();
                            if (data == "true")
                            {
                                isHeader = true;
                            }
                            else
                            {
                                isHeader = false;
                            }
                        }

                        if (line.Contains("[Property:Customization]="))
                        {
                            int pointer = line.IndexOf('=');
                            string data = line.Substring(pointer);
                            data.ToLower();
                            if (data == "true")
                            {
                                isCustomizable = true;
                            }
                            else
                            {
                                isCustomizable = false;
                            }
                        }

                        if (line.Contains("[Property:Safety]="))
                        {
                            int pointer = line.IndexOf('=');
                            string data = line.Substring(pointer);
                            data.ToLower();
                            if (data == "true")
                            {
                                safety = true;
                            }
                            else
                            {
                                safety = false;
                                Console.WriteLine("WARN:Script Safety disabled.");
                                Thread.Sleep(10000);
                            }
                        }

                        if (line.Contains("clear"))
                        {
                            Console.Clear();
                        }

                        if (line.Contains("wait:"))
                        {
                            int pointer = line.IndexOf(':') + 1;
                            int value = int.Parse(line.Substring(pointer, line.Length - 5));
                            Thread.Sleep(value);
                        }
                        else if (line.Contains("wait?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            string var = line.Substring(pointer);
                            try
                            {
                                int value = int.Parse(values[vars.IndexOf(var)]);
                                Thread.Sleep(value);
                            }
                            catch
                            {
                                Console.WriteLine("Variable " + var + " is not found or of the same type.");
                            }

                        }

                        if (line.Contains("loopback:"))
                        {
                            int pointer = line.IndexOf(':') + 1;
                            int value = 0;
                            try
                            {
                                string data = line.Substring(pointer, line.Length - 9);
                                value = int.Parse(data);
                            }
                            catch
                            {
                                value = 0;
                                isInfinite = true;
                            }
                            while (loopbacker < value && !(isInfinite))
                            {
                                loopbacker++;
                                goto restart;
                            }
                            {
                                goto restart;
                            }
                        }
                        else if (line.Contains("loopback?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            string var = line.Substring(pointer);
                            try
                            {
                                int value = int.Parse(values[vars.IndexOf(var)]);
                                while (loopbacker < value)
                                {
                                    loopbacker++;
                                    goto restart;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Variable " + var + " is not found or of the same type.");
                            }

                        }

                        if (line.Contains("changetitle:"))
                        {
                            int pointer = line.IndexOf(':') + 1;
                            string title = line.Substring(pointer);
                            Console.Title = title;
                        }

                        if (line.Contains("changelayout:"))
                        {
                            line.ToUpper();
                            int pointer = line.IndexOf(':') + 1;
                            int pointer2 = line.IndexOf(':') + 2;

                            //Data is the foreground
                            char data = line[pointer];
                            //Data2 is the background
                            char data2 = line[pointer2];


                            //Foreground
                            if (data == '0')
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else if (data == '1')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            }
                            else if (data == '2')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            else if (data == '3')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                            }
                            else if (data == '4')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            else if (data == '5')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            }
                            else if (data == '6')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (data == '7')
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (data == '8')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else if (data == '9')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else if (data == 'A')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if (data == 'B')
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            else if (data == 'C')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (data == 'D')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            else if (data == 'E')
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else if (data == 'F')
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                            //Background
                            if (data2 == '0')
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (data2 == '1')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                            }
                            else if (data2 == '2')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                            }
                            else if (data2 == '3')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                            }
                            else if (data2 == '4')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                            }
                            else if (data2 == '5')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            }
                            else if (data2 == '6')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (data2 == '7')
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                            }
                            else if (data2 == '8')
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                            }
                            else if (data2 == '9')
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                            }
                            else if (data2 == 'A')
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            else if (data2 == 'B')
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                            }
                            else if (data2 == 'C')
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            else if (data2 == 'D')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                            }
                            else if (data2 == 'E')
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                            }
                            else if (data2 == 'F')
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                        }
                    }

                    if (line.Contains("Mouse.getClick"))
                    {
                        if (MouseButtons.Left == 0) { }
                    }

                    if (line.Contains("run:"))
                    {
                        int pointer = line.IndexOf(':') + 1;
                        string appname = @line.Substring(pointer);
                        if (File.Exists(appname))
                        {
                            if (!(runInstances == 5) || safety == false)
                            {
                                Process.Start(appname);
                                runInstances++;
                            }
                            else
                            {
                                Console.WriteLine("WARN:Blocked the script \"" + path + "\" because it tried to run to much apps in the same time.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERR:Couldn't start the program " + appname + "!");
                        }
                    }

                    linecount++;
                    if (!(line.Contains("")))
                    {
                        Console.WriteLine("ERR:Fail at line " + linecount + "!");
                    }
                }


            }
            if (isPause)
            {
                Console.ReadKey();
            }
        }
    }
}
