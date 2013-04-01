TicTacToe : TicTacToe.cs
	mcs TicTacToe.cs -out:tictactoe.exe
	
User : TicTacToe
	./tictactoe.exe 1
	
Computer : TicTacToe
	./tictactoe.exe 2
	
clean :
	rm tictactoe.exe
