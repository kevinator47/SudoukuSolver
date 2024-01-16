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

    public bool Solve() // metodo mascara
    {
        return Solve(0);
    }
    private bool Solve(int currentSquare)
    {
        // [caso base] : si ya se llenaron todas las casillas del sudoku
        if(currentSquare >= table.Length)
        {
            return true ;
        }
        
        //[caso recursivo]
        if(table[currentSquare / 9 , currentSquare % 9] != 0) // la casilla ya esta llena
            return Solve(currentSquare + 1) ; 
        
        // si la casilla no esta llena
        foreach (int option in GetOptions(currentSquare))
        {
            Write(option , currentSquare);

            if(Solve(currentSquare + 1)) // si escribiendo esta opcion se llega a una solucion perfecto, sino se probara la siguiente opcion hasta quedarse sin opciones.
                return true ;
        }
        // Al quedarse sin opciones, borra y vuelve a casillas anteriores
        Erase(currentSquare);
        return false ;
    }
    private void Write(int value, int square) => table[square / 9 , square % 9] = value;
    private void Erase(int square) => Write(0,square);

    private IEnumerable<int> GetOptions(int currentSquare)
    {
        Set<int> rowOp = GetRowOptions(currentSquare);
        Set<int> columnOp = GetColumnOptions(currentSquare);
        Set<int> chartOp = GetChartOptions(currentSquare);

        return rowOp.Intersect(columnOp.Intersect(chartOp));
    }

    private Set<int> GetRowOptions(int square)
    {
        List<int> options = new List<int>(){1,2,3,4,5,6,7,8,9};
        int row = square / 9 ;

        for(int j = 0 ; j < table.GetLength(1) ; j++)
        {
            options.Remove(table[row, j]);
        }

        return new Set<int>(options);
    }

    private Set<int> GetColumnOptions(int square)
    {
        List<int> options = new List<int>(){1,2,3,4,5,6,7,8,9};
        int column = square % 9 ;

        for(int i = 0 ; i < table.GetLength(0) ; i++)
        {
            options.Remove(table[i, column]);
        }
        return new Set<int>(options);
    }

    private Set<int> GetChartOptions(int square)
    {
        List<int> options = new List<int>(){1,2,3,4,5,6,7,8,9};
        
        int startingRow = 3 * (square / 27) ;

        int column = square % 9 ;
        int startingColumn = 3 * (column / 3) ;

        for(int i = 0 ; i <= 2 ; i++)
        {
            for(int j = 0 ; j <= 2 ; j++)
            {
                options.Remove(table[startingRow + i , startingColumn + j]);
            }
        } 
        return new Set<int>(options);
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