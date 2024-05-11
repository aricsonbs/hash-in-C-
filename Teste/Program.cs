using System;

class Program
{
    static char[,] board = new char[3, 3]; // Tabuleiro 3x3
    static char currentPlayer = 'X'; // Jogador atual (começa com 'X')
    static bool gameOver = false; // Verifica se o jogo acabou

    static void Main()
    {
        InitializeBoard();

        do
        {
            Console.Clear();
            DisplayBoard();
            GetPlayerInput();

            if (CheckForWin())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"Jogador {currentPlayer} venceu!");
                gameOver = true;
            }
            else if (IsBoardFull())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("Empate!");
                gameOver = true; 
            }
            else
            {
                // Alterna para o próximo jogador
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

        } while (!gameOver);

        Console.WriteLine("Fim do Jogo!");
        Console.ReadLine();
    }

    static void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row);
            for (int col = 0; col < 3; col++)
            {
                Console.Write($" {board[row, col]}");
            }
            Console.WriteLine();
        }
    }

    static void GetPlayerInput()
    {
        int row, col;

        do
        {
            Console.Write($"Jogador {currentPlayer}, insira a linha (0, 1, 2): ");
        } while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2);

        do
        {
            Console.Write($"Jogador {currentPlayer}, insira a coluna (0, 1, 2): ");
        } while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2);

        if (board[row, col] != ' ')
        {
            Console.WriteLine("Essa posição já está ocupada. Tente novamente.");
            GetPlayerInput();
        }
        else
        {
            board[row, col] = currentPlayer;
        }
    }

    static bool CheckForWin()
    {
        // Verifica linhas, colunas e diagonais
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }

    static bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                    return false;
            }
        }
        return true;
    }
}
