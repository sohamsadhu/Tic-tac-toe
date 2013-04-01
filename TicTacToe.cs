/**
 * Class TicTacToe is the main and the only class in this file, that implements the 
 * game of Tic-tac-toe. When executing the program, you have to give the program
 * a command line argument of either 1 or 2 to give your preference of start. 1 is you 
 * start the game, 2 is computer starts with game and you get the second turn.
 */
public class TicTacToe
{
    /* 
     * The abstraction of Tic-tac-toe board is a single dimension array. With a single
     * dimension array a two dimension array is simulated to get the Tic-tac-toe board.
     * The array is divided into 3 blocks of 3 cells each. Each of those form a row.
     */
    private char [] board;

    /**
     * Constructor, limiting the board size. You do not need more than 9
     * cells to play Tic-tac-toe. Also initialise all the cells to empty space. 
     */
    public TicTacToe()
    {
        board = new char[9];
        for( int i = 0; i < 9; i++ ) {
            board[i] = ' ';
        }
    }

    public void usage()
    {
        System.Console.WriteLine("Usage: ./TicTacToe.exe <turn - which is 1 or 2>");
        System.Console.WriteLine("Turn 1 signifies user turn first. "+
                "Turn 2 means first move is by computer and second move is by user.");
        System.Environment.Exit(0);
    }

    /*
     * Examine the move and then insert the respective character in the position provided.
     * If the said position is already filled, then the function cannot insert and it returns
     * false. If the insertion succeeds then it returns true.
     */
    public bool insertMove( int turn, int pos )
    {
        if( board[ pos ] == ' ')  // The position provided is not occupied.
        {
            if( 1 == turn ) {       // Whoever has the first turn gets to play with x.
                board[ pos ] = 'x'; // Based on that, place that character.
            } else {
                board[ pos ] = 'o';
            }
            return true;
        }
        else {   // The position provided is occupied. Insertion not possible.
            return false;
        }
    }

    // The user gives a row and column, instead of plain position.
    // So a special function for insertion, that converts row and column to position.
    public void insertForUser( int turn )
    {
        bool insert = false;
        while( !insert )
        {
            int[] pos = askUser();
            // Convert the row and column to single dimension array value as per
            // position = 3 * ( row - 1 ) + ( column - 1 )
            // since arrays start at 0 and you are taking values starting at 1 from user.
            insert = insertMove( turn, 3 * ( pos[0] - 1 ) + ( pos[1] - 1 ) );
            if( !insert ) {
                System.Console.WriteLine("The position for your move has already been taken.");
            }
        }
    }

    public void displayWin( string player )
    {
        if( "User" == player ) {
            System.Console.WriteLine("You win!");
        } else {
            System.Console.WriteLine("Computer wins!");
        }
        display();
        System.Environment.Exit(0);
    }

    /*
     * Based on the player provided and the turn, judge if that turn has won, and
     * if it has, then display the winner by sending the player detail to display win.
     */
    public void doJudgement( string player, int turn )
    {
        if( 1 == turn )  // Whoever had the first turn should be using X.
        {
            if( judge('x') ) {
                displayWin( player );
            }
        }
        else
        {
            if( judge('o') ) {
                displayWin( player );
            }
        }
    }

    /**
     * The crux of this game. Based on the turn given, it decides if the computer or
     * the user gets the first move. Then it does at most 9 turns, for the game. Each of the
     * times, it alternatively allows user and computer to make their move. As the number of
     * moves go above 5, it then starts checking for a winner. And in case all the 9 moves 
     * are done with no winner, then prints the stalemate.
     */
    public void turn( string t )
    {
        int count = 0;
        bool insert = false;
        if( "1" == t ) // The user makes first move.
        {
            while( count < 9 ) // A game cannot go for more than 9 turns.
            {
                insertForUser( 1 ); // 1 for the character x to be used since it begins the move.
                count++;
                if( count >= 4 ) {  // You cannot have a winner, at least till 5 moves.
                    doJudgement( "User", 1 );   
                }
                if( count > 8 ) {   // The while loop, will check the counter, only after the
                    break;          // end of the loop. So, this intermediate condition, needs to
                }                   // be checked explicitly.
                insert = false;
                while( !insert ) {
                    insert = insertMove( 2, askMachine() ); // Insert the move for the computer.
                }
                count++;
                if( count >= 4 ) {
                    doJudgement( "Computer", 2 );   
                }
                display();
            }
            if( count > 8 ) {
                System.Console.WriteLine("It is a tie!");
            }
        }
        else // The computer makes first move.
        {
            while( count < 9 )
            {
                insert = false;
                while( !insert ) {
                    insert = insertMove( 1, askMachine() );
                }
                count++;
                if( count >= 4 ) {
                    doJudgement( "Computer", 1 );   
                }
                display(); // The user needs to see the move from the machine first.
                if( count > 8 ) {
                    break;
                }
                insertForUser( 2 ); 
                count++;
                if( count >= 4 ) { 
                    doJudgement( "User", 2 );   
                }
            }
            if( count > 8 ) 
            {
                display();
                System.Console.WriteLine("It is a tie!");
            }
        }
    }

    // Computer just randomly selects a move.
    public int askMachine()
    {
        return new System.Random().Next( 9 );
    }

    /**
     * Keep asking the user till you get a valid row and column number for users' move to 
     * be placed. A valid number is a whole number between 1 and 3 for both row and column.
     * 1 being the first row, and first column and so forth.
     * Return an array of 2 elements, with the first element being the row, and the second
     * being the column in the Tic-tac-toe board where the user wants move placed.
     */
    public int [] askUser()
    {
        // Ask for the row entry.
        System.Console.WriteLine("Please enter the row value (1 to 3) where you want "+ 
                "your symbol to be placed.");
        int row;
        while( !int.TryParse(System.Console.ReadLine(), out row) | row < 1 | row > 3 )
        {
            System.Console.WriteLine("Please enter a whole number, between 1 and 3, both inclusive.");
        }
        // Ask for the column entry.
        System.Console.WriteLine("Please enter the column value (1 to 3) where you want "+ 
                "your symbol to be placed.");
        int column;
        while( !int.TryParse(System.Console.ReadLine(), out column) | column < 1 | column > 3 )
        {
            System.Console.WriteLine("Please enter a whole number, between 1 and 3, both inclusive.");
        }
        return new int[2]{ row, column };
    }

    /**
     * Check the board with the character provided to see, if it has
     * a winning combination. Send 'true' if you find it has winning
     * combination, else return 'false'.
     */
    public bool judge( char move )
    {
        // Check all the rows.
        for( int i = 0; i < 9; i += 3 )
        {
            if( board[i] == move &                     // Check that cell is matches the character provided.
                    board[i] == board[i + 1] &         // Now match that character with entire row.
                    board[i + 1] == board[i + 2] ) {
                return true;
            }
        }
        // Check for columns. 
        for( int i = 0; i < 3; i++ )
        {
            if( board[i] == move & 
                    board[i] == board[i + 3] & 
                    board[i + 3] == board[i + 6] ) {
                return true;
            }
        }
        // Check the primary diagonal.
        if( board[0] == move & 
                board[0] == board[4] &
                board[4] == board[8] ) {
            return true;
        }
        // Check the secondary diagonal.
        if( board[2] == move & 
                board[2] == board[4] &
                board[4] == board[6] ) {
            return true;
        }
        return false; // Default, whoever had turn did not win.
    }

    // Just display the board. Meh...
    public void display() 
    {
        for( int i = 0; i < 9; i++ )
        {
            if( i % 3 == 0 ) {
                System.Console.WriteLine(""); // Just a new line.
            }
            if( ' ' == this.board[i] ) {
                System.Console.Write('_');
            } else {
                System.Console.Write( this.board[i] );
            }
            if( 0 != (i + 1) % 3 ) {
                System.Console.Write('|');
            }
        }
        System.Console.WriteLine(""); // Another new line.
    }

    public static void Main( string [] args )
    {
        TicTacToe T = new TicTacToe();
        if( args.Length != 1 ) {
            T.usage();
        }
        if ((args[0] != "1") & (args[0] != "2")) {
            T.usage();
        }
        T.turn( args[0] );
    }
}
