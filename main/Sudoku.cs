namespace SudokuSolver;

public class Sudoku
{
    private int[,] table;

    public Sudoku(List<int> digits)
    {
        if(digits.Count != 81)
            throw new ArgumentException($"Sudoku must be formed by 81 numbers, but {digits.Count} where given.");

        table = new int[9,9];
        
        for(int i = 0; i < digits.Count ; i++)
        {
            table[ i / 9 , i % 9] = digits[i];
        }
    }

    public string PrettyPrint()
    {
        string output = "" ;

        for(int i = 0 ; i < table.GetLength(0); i++)
        {
            for(int j = 0 ; j < table.GetLength(1); j++)
            {
                output += table[i,j];

                if(j % 3 == 2 && j != 8)
                    output += "-" ;
            }
            output += "\n";
            if(i % 3 == 2 && i != 8)
                output += "\n";
        }
        return output ;
    }
}