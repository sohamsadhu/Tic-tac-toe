This folder contains 4 things. The source code file for the problem asked
which is written in C#. The Makefile in case you are running this on Unix
on the bash shell with Mono C# compiler. A executable named tictactoe.exe,
derived form Mono compiler but should work on a Windows platform also. And
lastly this read me file.

On unix, if the Mono compiler is available, then just type 'make' after 
entering this directory on bash shell, and your executables will be generated.
If you type 'make clean' the executable will be removed. You will have to
type make again to get the executable. The executable produced should work
on a Windows machine given it is a exe file. If you want to run the program
with the scenarios, then type 'make Computer' to test the scenario where 
computer makes the first move and user makes second move.
If you want to run the scenario where user makes the first move and computer
second then type 'make User' to test the scenario.

Below at the end, is a sample run, on the bash shell where computer makes the move.

RUNNING THE PROGRAM ON WINDOWS:
The executable provided should work on windows. On Windows PowerShell to 
execute the program you should use

C:\path_to_this_directory> ./tictactoe.exe < turn preference >

example on PowerShell: 

C:\path_to_this_directory> ./tictactoe.exe 1

Sample run on bash:-

make Computer
mcs TicTacToe.cs -out:tictactoe.exe
./tictactoe.exe 2

x|_|_
_|_|_
_|_|_
Please enter the row value (1 to 3) where you want your symbol to be placed.
3
Please enter the column value (1 to 3) where you want your symbol to be placed.
1

x|x|_
_|_|_
o|_|_
Please enter the row value (1 to 3) where you want your symbol to be placed.
1
Please enter the column value (1 to 3) where you want your symbol to be placed.
3

x|x|o
_|_|_
o|x|_
Please enter the row value (1 to 3) where you want your symbol to be placed.
2
Please enter the column value (1 to 3) where you want your symbol to be placed.
2
You win!

x|x|o
_|o|_
o|x|_
