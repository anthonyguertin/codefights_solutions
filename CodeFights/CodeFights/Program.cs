
using CodeFights;
using CodeFights.CodeFightTests;
using CodeFights.Solutions;

public partial class Program
{
    private static readonly string _space = " ";
    private static readonly string _solutionsNamespaceString = "CodeFights";
    private static readonly string _noArgsMessage = "must select option from menu;\n program exiting";
    private static readonly string _notOptionMessage = "not a viable option, would you check option(s) selected?\n";
    private static readonly string _customOrStandardTestMessage = "would you like to use custom tests? \n (y)es\n (n)o\n";

    private static List<string> solutionList = new List<string>();
    private static List<string> nameSpaceList = new List<string>();
    private static void ReadAssemblyInfo(string _namespace)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        
        foreach (var type in assembly.GetTypes())
        {
            if (type.Namespace != null && type.Namespace.Contains(_namespace))
            {
                nameSpaceList.Add($"{type.Namespace}.{type.Name}");
                solutionList.Add(type.Name);
            }
        }
    }
    public static void Main(string[] args)
    {
        ReadAssemblyInfo(_solutionsNamespaceString);

        // Check for Arguments
        var console_linefeed = Console.ReadLine();
        if (console_linefeed == null)
        {
            Console.WriteLine(_noArgsMessage);
            return;
        }
        var console_args = console_linefeed.Split(_space);
        var arg1 = console_args[0];

        /*        // Check if Viable Option 
                if (console_args.Length <= 0 || !solutionList.Contains(console_args[0]))
                    Console.WriteLine(_notOptionMessage);
        */
        // Display Custom Test Dialogue
        Console.WriteLine(_customOrStandardTestMessage);

        var custom_test_dialogue = Console.ReadLine();

        if (custom_test_dialogue[0] == 'y')
        {
            // Place custom tests here; point to a file;
        }

        // Get the nameSpaceList from the option menu index

        var solutionToRun = string.Empty;
        int result;
        if (!int.TryParse(arg1, out result))
        {
            Console.WriteLine(_notOptionMessage);
            return;
        }

        if (nameSpaceList.Count < result || result < 0)
        {
            Console.WriteLine(_notOptionMessage);

        }
        else
        {
            solutionToRun = nameSpaceList[result];
        }

        /*        foreach (var n in nameSpaceList)
                {
                    var i = n.LastIndexOf(".");
                    if (i + 1 > n.Length) continue;

                    i += 1;
                    var s = n[i..];


                    if (s != arg1)
                    {
                        Console.WriteLine("Error, solution not in program namespace");
                        continue;
                    }


                    solutionToRun = n;
                    break;
                }*/

        var type = Type.GetType(solutionToRun);// ");//solutionClassName);
        var method = type.GetMethod("solution");


        var add = new Add();
        var addTests = new AddTests();

        method.Invoke(add,  new object[] { addTests.Param1, addTests.Param2 });
        //Console.WriteLine( $"result: {add.solution(addTests.Param1, addTests.Param2)}");
    }
}
