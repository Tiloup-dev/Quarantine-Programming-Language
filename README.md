# Quarantine-Programming-Language
Scripting language that uses an interpreter to be executed.

# How to use
Install .NET Core 3.1 Runtime for your Operating System (Link:https://dotnet.microsoft.com/download/)
qlc [FilePath] [-pause to pause the program at the end]

# Print, Println
You can print data to screen using the print command.
_**print:text (print to screen)**_
_**println:text (print to screen + \n)**_
_**print? (enter variable name to print it)**_
_**println? (enter variable name to print it + \n)**_

# Variables
Variables are working like Python, but with 'var' in front of it.
_**var (Variable Name) = (Value)**_**_

# Graphics
You can modify the consoles' color using hexadecimal.
_**changelayout:(0~F)(0~F)**_
You can also modify the title of the console.
_**changetitle:(title)**_
Or with variables.
_**changetitle? (enter variable name to change the title to it)**_
You can clear the screen, wich is very practical.
_**clear**_

# Loop and wait
For now, you can loop the whole script using the loopback command.
_**loopback:(number of times to loop)**_
With Variables:
_**loopback? (enter variable)**_
To wait, there is the wait command.
_**wait:(ammount of time to wait in milliseconds)**_
Same as always, with variables:
_**wait?(enter variable)**_

# Maths (add, substract, multiplicate and divide)
To add two variables and stock the sum into one, use int.add:
_**int.add?1(first variable) ?2(second variable) ?3(third variable)**_
Substraction is int.sub instead of add.
Multiplication is int.mul instead of add.
Division is int.div instead of add.

# Propreties
For now, there is only three propreties available:
_Headers (not used yet)_
_Safety (partially used)_
_Customization (not used yet)_
I recommand putting Headers to false. To modify a proprety, this is the syntax:
\[Proprety:(proprety name)\]=(true of false)

Now you now how to use Quarantine!
