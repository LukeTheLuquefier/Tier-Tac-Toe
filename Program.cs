using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using static System.Console;
namespace Tier_tac_toe;

class Program
{
    static void Main(string[] args)
    {
        char?[,] spaces = new char?[9,2];
        
        void ResetBoard()
        {
            for (int boardNum = 0; boardNum < 9; boardNum++)
            {
                spaces[boardNum,0] = ' ';
                spaces[boardNum,1] = '0';
            }
        }

        void WriteSpace(int space1)
        {
            switch (spaces[space1, 1])
            {
                case '1':
                    ForegroundColor = ConsoleColor.Red;
                    break;
                case '2':
                    ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            Write(Convert.ToString(spaces[space1, 0]));
            ForegroundColor = ConsoleColor.White;
        }


        string interLine = " | ";
        string emptyLine = "---+---+---";
        void PrintBoard()
        {
            Clear();
            WriteLine(
@$"Commands:
s : To skip game
a : To enable AI
--------------
 1 | 2 | 3 
{emptyLine}
 4 | 5 | 6 
{emptyLine}
 7 | 8 | 9 
--------------");
            for (int count1 = 1; count1 <= 3; count1++)
            {
                Write(" ");
                for (int count2 = 1; count2 <= 3; count2++)
                {
                    WriteSpace((count1 - 1) * 3 + count2 - 1);
                    if (count2 != 3)
                    {
                            Write(interLine);
                    }
                }
                WriteLine(" ");
                if (count1 != 3)
                {
                    WriteLine(emptyLine);
                }
            }
        }

        int CheckMove(char inputspace, char inputnumber)
        {
            return 0;
        }

        char selectedSpace;
        char selectedNumber;
        int correctInput = 1;
        void MakeMove()
        {
            while (correctInput != 0)
            {
                correctInput = 0;
                Write("Select space: ");
                selectedSpace = ReadKey().KeyChar;
                WriteLine("");
                Write("Select number: ");
                selectedNumber = ReadKey().KeyChar;
                correctInput = CheckMove(selectedSpace, selectedNumber);
                    if (correctInput != 0)
                {
                    Clear();
                    PrintBoard();
                    WriteLine($"Invalid input: error {correctInput}");
                }
            }
        }


        bool CheckWinCons()
        {
            return true;
        }
        void WinChanges()
        {

        }
        char GameModeSelect()
        {
            while (true)
            {
                Clear();
                WriteLine("Mode select:\n1 - tic tac toe\n2 - tier tac toe\ne - exit game");
                switch (ReadKey().KeyChar)
                {
                    case '1':
                        return '1';
                    case '2':
                        return '2';
                    case 'e':
                        return 'e';
                }
                Clear();
            }
        }


        char gameMode = GameModeSelect();
        bool win = false;
        int condition = 0;
        while (gameMode != 'e')
        {
            ResetBoard();
            for (int round = 1; round <= ((gameMode == 2) ? 12 : 9); round++)
            {
                PrintBoard();
                MakeMove();

                if (round == ((gameMode == 2) ? 12 : 9))
                {
                    Write("everyone has no more pieces");
                }
            }
            Thread.Sleep(4000);
            gameMode = GameModeSelect();
        }
        

    }
}