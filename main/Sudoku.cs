using System.Threading.Tasks.Dataflow;

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
            return Solve(currentSquare++) ; 
        
        // si la casilla no esta llena
        foreach (int option in GetOptions(currentSquare))
        {
            Write(option , currentSquare);

            if(Solve(currentSquare++)) // si escribiendo esta opcion se llega a una solucion perfecto, sino se probara la siguiente opcion hasta quedarse sin opciones.
                return true ;
        }
        // Al quedarse sin opciones, borra y vuelve a casillas anteriores
        Erase(currentSquare);
        return false ;
    }
    private void Write(int value, int square) => table[square / 9 , square % 9] = value;
    private void Erase(int square) => Write(0,square);

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