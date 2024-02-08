namespace SudokuSolver;
class Program
{
    static void Main()
    {
        string? input ;
        do
        {
            Console.Write("Ingrese el sudoku a resolver : ");
            input = Console.ReadLine();
        
            var sdk = new Sudoku(Stdrize(input));  
            sdk.Solve();
        
            Console.WriteLine(sdk.PrettyPrint());    
        } while (input != "");
        
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