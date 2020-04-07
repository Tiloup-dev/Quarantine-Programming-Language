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

namespace lsc
{
    public class Parser
    {
        //Program Variables
        public static string currentstringdata = "";
        public static string currentstringdata2 = "";
        public static char currentchardata = ' ';
        public static char currentchardata2 = ' ';
        public static int currentintdata = 0;
        public static int currentintdata2 = 0;
        public static bool currentbooldata = false;
        public static bool currentbooldata2 = false;
        public static double currentdoubledata = 0;
        public static double currentdoubledata2 = 0;
        public static bool isInfinite = false;
        public static int loopbacker = 1;
        public static bool isHeader = true;
        public static bool isCustomizable = true;
        public static string line_then = "";

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
                        //CHARS FROM STRINGS
                        else if (line.Contains("string(char)?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            int value = int.Parse(line.Substring(pointer, line.Length - 13));
                            currentchardata = currentstringdata[value];
                        }
                        else if (line.Contains("string2(char)?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            int value = int.Parse(line.Substring(pointer, line.Length - 14));
                            currentchardata = currentstringdata[value];
                        }
                        else if (line.Contains("string(char2)?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            int value = int.Parse(line.Substring(pointer, line.Length - 14));
                            currentchardata2 = currentstringdata[value];
                        }
                        else if (line.Contains("string2(char2)?"))
                        {
                            int pointer = line.IndexOf('?') + 1;
                            int value = int.Parse(line.Substring(pointer, line.Length - 15));
                            currentchardata2 = currentstringdata[value];
                        }
                        //INTS
                        if (line.Contains("integer:"))
                        {
                            currentintdata = 0;
                            int pointer = line.IndexOf(':') + 1;
                            string data = line.Substring(pointer, line.Length - 8);
                            if (data == "(random)[positive]")
                            {
                                Random randomn = new Random();
                                currentintdata = randomn.Next(0,1);
                            }
                            else if (data == "(random)[negative]?")
                            {
                                Random randomn = new Random();
                                object syncLock = new object();
                                currentintdata = randomn.Next();
                                currentintdata = currentintdata - Math.Abs(currentintdata);
                            }
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
                            string data = line.Substring(pointer, line.Length - 9);
                            if (data == "(random)[positive]")
                            {
                                Random randomn = new Random();
                                currentintdata = randomn.Next(0,1);
                            }
                            else if (data == "(random)[negative]")
                            {
                                Random randomn = new Random();
                                currentintdata = randomn.Next();
                                currentintdata = currentintdata - Math.Abs(currentintdata);
                            }
                        }
                        else if (line.Contains("integer2(readline)"))
                        {
                            currentintdata2 = 0;
                            currentintdata2 = int.Parse(Console.ReadLine());
                        }
                        //SECOND DOUBLES
                        if (line.Contains("double2:"))
                        {
                            currentdoubledata2 = 0;
                            int pointer = line.IndexOf(':') + 1;
                            string data = line.Substring(pointer, line.Length - 8);
                            if (data == "(random)[positive]")
                            {
                                Random random = new Random();
                                currentdoubledata2 = random.NextDouble();
                            }
                            else if (data == "(random)[negative]")
                            {
                                Random random = new Random();
                                currentdoubledata2 = random.NextDouble();
                            }
                            else if (data == "(random)")
                            {
                                Random random = new Random();
                                currentdoubledata2 = random.NextDouble();
                            }
                        }
                        else if (line.Contains("double2(readline)"))
                        {
                            currentdoubledata2 = 0;
                            currentdoubledata2 = int.Parse(Console.ReadLine());
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
                            currentdoubledata = 0;
                            currentdoubledata2 = 0;
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
                        else if (line.Contains("wait(int)"))
                        {
                            Thread.Sleep(currentintdata);
                        }
                        else if (line.Contains("wait(int2)"))
                        {
                            Thread.Sleep(currentintdata2);
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
                        else if (line.Contains("loopback(int)"))
                        {
                            while (loopbacker < currentintdata)
                            {
                                loopbacker++;
                                goto restart;
                            }
                        }
                        else if (line.Contains("loopback(int2)"))
                        {
                            while (loopbacker < currentintdata2)
                            {
                                loopbacker++;
                                goto restart;
                            }
                        }
                        //Round
                        if (line.Contains("round(int,double)"))
                        {
                            currentintdata = (int)Math.Round((decimal)currentdoubledata);
                        }
                        else if (line.Contains("round(int2,double)"))
                        {
                            currentintdata2 = (int)Math.Round((decimal)currentdoubledata);
                        }
                        else if (line.Contains("round(int,double2)"))
                        {
                            currentintdata = (int)Math.Round((decimal)currentdoubledata2);
                        }
                        else if (line.Contains("round(int2,double2"))
                        {
                            currentintdata2 = (int)Math.Round((decimal)currentdoubledata2);
                        }
                        //Convert
                        if (line.Contains("convert(double,int)"))
                        {
                            currentdoubledata = currentintdata;
                        }
                        else if (line.Contains("convert(double2,int)"))
                        {
                            currentdoubledata2 = currentintdata;
                        }
                        else if (line.Contains("convert(double,int2)"))
                        {
                            currentdoubledata = currentintdata2;
                        }
                        else if (line.Contains("convert(double2,int2)"))
                        {
                            currentdoubledata2 = currentintdata2;
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

                    if (line.Contains("if("))
                    {
                        int pointer = line.IndexOf('(') + 1;
                        int end_pointer = line.IndexOf(')');
                        int char_pointer = pointer;
                        string condition = line.Substring(pointer);
                        bool result;
                        string[] splited_strings = condition.Split(' ', StringSplitOptions.None);
                        string firstdata_string = splited_strings[0];
                        object firstdata = 0;
                        if (firstdata_string == "int")
                        {
                            firstdata = currentintdata;
                        }
                        else if (firstdata_string == "int2")
                        {
                            firstdata = currentintdata2;
                        }
                        else if (firstdata_string == "string")
                        {
                            firstdata = currentstringdata;
                        }
                        else if (firstdata_string == "string2")
                        {
                            firstdata = currentstringdata2;
                        }
                        else if (firstdata_string == "char")
                        {
                            firstdata = currentchardata;
                        }
                        else if (firstdata_string == "char2")
                        {
                            firstdata = currentchardata2;
                        }
                        else if (firstdata_string == "bool")
                        {
                            firstdata = currentbooldata;
                        }
                        else if (firstdata_string == "bool2")
                        {
                            firstdata = currentbooldata2;
                        }
                        else { Console.WriteLine("ERR:No _firstdata_ assignement"); Environment.Exit(-1); }

                        object opdata = "==";
                        string operator_string = splited_strings[1];

                        string[] operators = { "==", "<=", ">=", "!=" };

                        if (operator_string == "==")
                        {
                            opdata = operators[0];
                        }
                        else if (operator_string == "<=")
                        {
                            opdata = operators[1];
                        }
                        else if (operator_string == ">=")
                        {
                            opdata = operators[2];
                        }
                        else if (operator_string == "!=")
                        {
                            opdata = operators[3];
                        }
                        else { Console.WriteLine("ERR:No _opdata_ assignement"); Environment.Exit(-1); }

                        object seconddata = 0;
                        string seconddata_string = splited_strings[2];

                        if (seconddata_string == "int")
                        {
                            seconddata = currentintdata;
                        }
                        else if (seconddata_string == "int2")
                        {
                            seconddata = currentintdata2;
                        }
                        else if (seconddata_string == "string")
                        {
                            seconddata = currentstringdata;
                        }
                        else if (seconddata_string == "string2")
                        {
                            seconddata = currentstringdata2;
                        }
                        else if (seconddata_string == "char")
                        {
                            seconddata = currentchardata;
                        }
                        else if (seconddata_string == "char2")
                        {
                            seconddata = currentchardata2;
                        }
                        else if (seconddata_string == "bool")
                        {
                            seconddata = currentbooldata;
                        }
                        else if (seconddata_string == "bool2")
                        {
                            seconddata = currentbooldata2;
                        }
                        else { Console.WriteLine("ERR:No _seconddata_ assignement"); Environment.Exit(-1); }

                        if (char_pointer == end_pointer)
                        {
                            if (firstdata.GetType() == seconddata.GetType())
                            {
                                if (opdata == operators[0])
                                {
                                    if (firstdata == seconddata)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }
                                else if (opdata == operators[1])
                                {
                                    if ((int)firstdata <= (int)seconddata)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }
                                else if (opdata == operators[2])
                                {
                                    if ((int)firstdata >= (int)seconddata)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }
                                else if (opdata == operators[3])
                                {
                                    if (firstdata != seconddata)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }

                                //THEN
                                int pointer_then = line.IndexOf('/') + 1;
                                line_then = line.Substring(pointer_then, line.IndexOf(';'));
                                int char_pointer2 = pointer_then;
                                while (char_pointer2 <= line.IndexOf(';'))
                                {
                                    then = true;
                                    char_pointer2++;
                                }
                            }
                            else { Console.WriteLine("ERR:_firstdata_ and _seconddata_ aren't the same type."); Environment.Exit(-1); }
                        }
                        else char_pointer++;
                    }

                    if (line.Contains("Mouse.getClick"))
                    {
                        if (MouseButtons.Left == 0) { }
                    }

                    linecount++;

                    if (then = true)
                    {
                        ThenParse(line_then);
                    }

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









































        public static void ThenParse(string line)
        {
            restart:
            bool then = false;
            int linecount = 0;
            if (false)
            {

            }
            else
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
                //CHARS FROM STRINGS
                else if (line.Contains("string(char)?"))
                {
                    int pointer = line.IndexOf('?') + 1;
                    int value = int.Parse(line.Substring(pointer, line.Length - 13));
                    currentchardata = currentstringdata[value];
                }
                else if (line.Contains("string2(char)?"))
                {
                    int pointer = line.IndexOf('?') + 1;
                    int value = int.Parse(line.Substring(pointer, line.Length - 14));
                    currentchardata = currentstringdata[value];
                }
                else if (line.Contains("string(char2)?"))
                {
                    int pointer = line.IndexOf('?') + 1;
                    int value = int.Parse(line.Substring(pointer, line.Length - 14));
                    currentchardata2 = currentstringdata[value];
                }
                else if (line.Contains("string2(char2)?"))
                {
                    int pointer = line.IndexOf('?') + 1;
                    int value = int.Parse(line.Substring(pointer, line.Length - 15));
                    currentchardata2 = currentstringdata[value];
                }
                //INTS
                if (line.Contains("integer:"))
                {
                    currentintdata = 0;
                    int pointer = line.IndexOf(':') + 1;
                    string data = line.Substring(pointer, line.Length - 8);
                    if (data == "(random)[positive]")
                    {
                        Random random = new Random();
                        currentintdata = random.Next(0, 9999);
                    }
                    else if (data == "(random)[negative]")
                    {
                        Random random = new Random();
                        currentintdata = random.Next(-9999, 0);
                    }
                    else if (data == "(random)")
                    {
                        Random random = new Random();
                        currentintdata = random.Next(-9999, 9999);
                    }
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
                    string data = line.Substring(pointer, line.Length - 9);
                    if (data == "(random)[positive]")
                    {
                        Random random = new Random();
                        currentintdata2 = random.Next(0, 9999);
                    }
                    else if (data == "(random)[negative]")
                    {
                        Random random = new Random();
                        currentintdata2 = random.Next(-9999, 0);
                    }
                    else if (data == "(random)")
                    {
                        Random random = new Random();
                        currentintdata2 = random.Next(-9999, 0);
                    }
                }
                else if (line.Contains("integer2(readline)"))
                {
                    currentintdata2 = 0;
                    currentintdata2 = int.Parse(Console.ReadLine());
                }
                //SECOND INTS
                if (line.Contains("double2:"))
                {
                    currentdoubledata2 = 0;
                    int pointer = line.IndexOf(':') + 1;
                    string data = line.Substring(pointer, line.Length - 8);
                    if (data == "(random)[positive]")
                    {
                        Random random = new Random();
                        currentdoubledata2 = random.NextDouble();
                    }
                    else if (data == "(random)[negative]")
                    {
                        Random random = new Random();
                        currentdoubledata2 = random.NextDouble();
                    }
                    else if (data == "(random)")
                    {
                        Random random = new Random();
                        currentdoubledata2 = random.NextDouble();
                    }
                }
                else if (line.Contains("double2(readline)"))
                {
                    currentdoubledata2 = 0;
                    currentdoubledata2 = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("ERR:Cannot find file \"" + scriptpath + "\".");
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
                    currentdoubledata = 0;
                    currentdoubledata2 = 0;
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
                else if (line.Contains("wait(int)"))
                {
                    Thread.Sleep(currentintdata);
                }
                else if (line.Contains("wait(int2)"))
                {
                    Thread.Sleep(currentintdata2);
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
                else if (line.Contains("loopback(int)"))
                {
                    while (loopbacker < currentintdata)
                    {
                        loopbacker++;
                        goto restart;
                    }
                }
                else if (line.Contains("loopback(int2)"))
                {
                    while (loopbacker < currentintdata2)
                    {
                        loopbacker++;
                        goto restart;
                    }
                }
                //Round
                if (line.Contains("round(int,double)"))
                {
                    currentintdata = (int)Math.Round((decimal)currentdoubledata);
                }
                else if (line.Contains("round(int2,double)"))
                {
                    currentintdata2 = (int)Math.Round((decimal)currentdoubledata);
                }
                else if (line.Contains("round(int,double2)"))
                {
                    currentintdata = (int)Math.Round((decimal)currentdoubledata2);
                }
                else if (line.Contains("round(int2,double2"))
                {
                    currentintdata2 = (int)Math.Round((decimal)currentdoubledata2);
                }
                //Convert
                if (line.Contains("convert(double,int)"))
                {
                    currentdoubledata = currentintdata;
                }
                else if (line.Contains("convert(double2,int)"))
                {
                    currentdoubledata2 = currentintdata;
                }
                else if (line.Contains("convert(double,int2)"))
                {
                    currentdoubledata = currentintdata2;
                }
                else if (line.Contains("convert(double2,int2)"))
                {
                    currentdoubledata2 = currentintdata2;
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

            if (line.Contains("if("))
            {
                int pointer = line.IndexOf('(') + 1;
                int end_pointer = line.IndexOf(')');
                int char_pointer = pointer;
                string condition = line.Substring(pointer);
                bool result;
                string[] splited_strings = condition.Split(' ', StringSplitOptions.None);
                string firstdata_string = splited_strings[0];
                object firstdata = 0;
                if (firstdata_string == "int")
                {
                    firstdata = currentintdata;
                }
                else if (firstdata_string == "int2")
                {
                    firstdata = currentintdata2;
                }
                else if (firstdata_string == "string")
                {
                    firstdata = currentstringdata;
                }
                else if (firstdata_string == "string2")
                {
                    firstdata = currentstringdata2;
                }
                else if (firstdata_string == "char")
                {
                    firstdata = currentchardata;
                }
                else if (firstdata_string == "char2")
                {
                    firstdata = currentchardata2;
                }
                else if (firstdata_string == "bool")
                {
                    firstdata = currentbooldata;
                }
                else if (firstdata_string == "bool2")
                {
                    firstdata = currentbooldata2;
                }
                else { Console.WriteLine("ERR:No _firstdata_ assignement"); Environment.Exit(-1); }

                object opdata = "==";
                string operator_string = splited_strings[1];

                string[] operators = { "==", "<=", ">=", "!=" };

                if (operator_string == "==")
                {
                    opdata = operators[0];
                }
                else if (operator_string == "<=")
                {
                    opdata = operators[1];
                }
                else if (operator_string == ">=")
                {
                    opdata = operators[2];
                }
                else if (operator_string == "!=")
                {
                    opdata = operators[3];
                }
                else { Console.WriteLine("ERR:No _opdata_ assignement"); Environment.Exit(-1); }

                object seconddata = 0;
                string seconddata_string = splited_strings[2];

                if (seconddata_string == "int")
                {
                    seconddata = currentintdata;
                }
                else if (seconddata_string == "int2")
                {
                    seconddata = currentintdata2;
                }
                else if (seconddata_string == "string")
                {
                    seconddata = currentstringdata;
                }
                else if (seconddata_string == "string2")
                {
                    seconddata = currentstringdata2;
                }
                else if (seconddata_string == "char")
                {
                    seconddata = currentchardata;
                }
                else if (seconddata_string == "char2")
                {
                    seconddata = currentchardata2;
                }
                else if (seconddata_string == "bool")
                {
                    seconddata = currentbooldata;
                }
                else if (seconddata_string == "bool2")
                {
                    seconddata = currentbooldata2;
                }
                else { Console.WriteLine("ERR:No _seconddata_ assignement"); Environment.Exit(-1); }

                if (char_pointer == end_pointer)
                {
                    if (firstdata.GetType() == seconddata.GetType())
                    {
                        if (opdata == operators[0])
                        {
                            if (firstdata == seconddata)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else if (opdata == operators[1])
                        {
                            if ((int)firstdata <= (int)seconddata)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else if (opdata == operators[2])
                        {
                            if ((int)firstdata >= (int)seconddata)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else if (opdata == operators[3])
                        {
                            if (firstdata != seconddata)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }

                        //THEN
                        int pointer_then = line.IndexOf('/') + 1;
                        line_then = line.Substring(pointer_then, line.IndexOf(';'));
                        int char_pointer2 = pointer_then;
                        while (char_pointer2 <= line.IndexOf(';'))
                        {
                            then = true;
                            char_pointer2++;
                        }
                    }
                    else { Console.WriteLine("ERR:_firstdata_ and _seconddata_ aren't the same type."); Environment.Exit(-1); }
                }
                else char_pointer++;
            }

            if (line.Contains("Mouse.getClick"))
            {
                if (MouseButtons.Left == 0) { }
            }

            linecount++;

            if (!(line.Contains("")))
            {
                Console.WriteLine("ERR:Fail at line " + linecount + "!");
            }
        }
    }
}
