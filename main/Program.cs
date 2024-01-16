namespace SudokuSolver;
class Program
{
    static void Main()
    {
        Console.Write("Ingrese el sudoku a resolver : ");
        string? input = Console.ReadLine();
        
        var sdk = new Sudoku(Stdrize(input));  
        sdk.Solve();
        
        Console.WriteLine(sdk.PrettyPrint());
    }

    private static List<int> Stdrize(string? input)
    {
        var digits = new List<int>();
        
        foreach (char symbol in input)
        {
            if(char.IsDigit(symbol))
                digits.Add(int.Parse(symbol.ToString()));
        }

        return digits;
    }
}