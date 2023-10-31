using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Console;
namespace Tier_tac_toe;

class Program
{
    static void Main(string[] args)
    {
        char?[,] spaces = new char?[9, 2];
        string[,] AIMenu =
        {
            {
                "Select AI mode:", "0 - Off", "1 - Easy", "2 - Medium", "3 - Hard"
            },
            {
                "0","0","1", "2","3"
            }
        };
        char AIMode = '0';
        string[,] ruleMenu =
        {
            {
                "Rules, select to change:", "1 - Allows you to places numbers on your own smaller numbers: ", "r - Resets all rules"
            },
            {
                "","1","r"
            }
        };
        bool[] rules =
        {
            false, false
        };
        int[] maxTurn =
        {
            9, 12
        };
        string interLine = " | ";
        string emptyLine = "---+---+---";
        int win;
        int currentPlayer = 0;
        int maxRounds;
        bool toMainMenu = false;

        void ResetBoard(char gameMode1)
        {
            if (gameMode1 == '1' || gameMode1 == '2')
            {
                spaces = new char?[9, 2];
                for (int boardNum = 0; boardNum < 9; boardNum++)
                {
                    spaces[boardNum, 0] = ' ';
                    spaces[boardNum, 1] = '0';
                }
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

        int CheckMove(int selectedSpace1, char selectedNumber1, int currentPlayer11, out int otherCodes)
        {
            otherCodes = 1;
            return 0;
        }

        int selectedSpace;
        char selectedNumber;
        int correctInput = 1;
        void MakeMove(int currentPlayer1, ref bool toMainMenu1)
        {
            toMainMenu1 = false;
            while (correctInput != 0)
            {
                correctInput = 0;
                Write("Select space: ");
                selectedSpace = Convert.ToInt32(ReadKey().KeyChar);
                WriteLine("");
                Write("Select number: ");
                selectedNumber = ReadKey().KeyChar;
                WriteLine("");
                correctInput = CheckMove(selectedSpace, selectedNumber, currentPlayer1, out int otherCodes);
                    if (correctInput != 0)
                {
                    Clear();
                    PrintBoard();
                    WriteLine($"Invalid input: error {correctInput}");
                }
            }
        }


        void CheckWinCons(ref int win1)
        {

            return;
        }

        void WinChanges(int win1)
        {

        }

        void MenuSelect(ref string[,] theMenu)
        {

            while (true)
            {
                Clear();
                for (int number03 = 0; number03 < theMenu.GetLength(1); number03++)
                {
                    WriteLine(theMenu[0, number03]);
                }
                WriteLine("b - back");
                char menuInput = ReadKey().KeyChar;
                if (menuInput == 'b')
                {
                    theMenu[1, 0] = "b";
                    return;
                }
                for (int number13 = 1; number13 < theMenu.GetLength(1); number13++)
                {
                    if (menuInput == Convert.ToChar(theMenu[1, number13]))
                    {
                        theMenu[1, 0] = (theMenu[1, number13]);
                        return;
                    }
                }
                WriteLine("Not a valid input");
            }

        }
        void ResetRules()
        {
            rules = new bool[]{false, false};
        }
        char MainMenuSelect()
        {
            while (true)
            {
                Clear();
                WriteLine("Mode select:\n1 - tic tac toe\n2 - tier tac toe\nr - rules\na - AI menu\ne - exit game");
                switch (ReadKey().KeyChar)
                {
                    case '1':
                        return '1';
                    case '2':
                        return '2';
                    case 'r':
                        MenuSelect(ref ruleMenu);
                        if (ruleMenu[1, 0] == "b")
                            continue;
                        if (ruleMenu[1, 0] == "r")
                        {
                            ResetRules();
                            continue;
                        }
                        rules[Convert.ToInt32(ruleMenu[1, 0])] = (rules[Convert.ToInt32(ruleMenu[1, 0])] ? false : true);
                        continue;
                    case 'a':
                        MenuSelect(ref AIMenu);
                        if (AIMenu[1, 0] == "b")
                            continue;
                        AIMode = Convert.ToChar(AIMenu[1, 0]);
                        continue;
                    case 'e':
                        return 'e';
                }
            }
        }


        void Game(char gameMode1)
        {
            ResetBoard(gameMode1);
            win = 0;
            currentPlayer = 0;
            maxRounds = maxTurn[Convert.ToInt32(Convert.ToString(gameMode1)) - 1];
            for (int round = 1; round <= maxRounds && (win == 0); round++)
            {
                PrintBoard();
                MakeMove(currentPlayer, ref toMainMenu);
                if (toMainMenu)
                    break;
                WriteLine($"round: {round}    maxround: {maxRounds}");
                Thread.Sleep(1000);
                if (round == maxRounds)
                {
                    Write("everyone has no more pieces");
                    win = 3;
                }
            }
            if (!toMainMenu)
            {
                Thread.Sleep(4000);
            }
        }


        char gameMode = MainMenuSelect();
        while (gameMode != 'e')
        {
            Game(gameMode);
            gameMode = MainMenuSelect();
        }
        

    }
}