using HackAssembler.Modules;

public class Program
{
    private static void Main(string[] args)
    {
        string firstPassPath = $@"{Path.GetDirectoryName(args[0])}\FirstPass.asm";
        string hackFilePath = $@"{Path.GetDirectoryName(args[0])}\{Path.GetFileNameWithoutExtension(args[0])}.hack";
        if (File.Exists(args[0]) && Path.GetExtension(args[0]) == ".asm") 
        {
            Dictionary<string, int> symbolTable = new();
            Symbols symbolModule = new(symbolTable);

            StreamReader srFirstPass = new(args[0]);
            StreamWriter swFirstPass = new(firstPassPath);
            Parser parserFirstPass = new(srFirstPass);
            FirstPass(swFirstPass, srFirstPass, symbolModule, parserFirstPass);

            StreamReader srSecondPass = new(firstPassPath);
   
            StreamWriter swSecondPass = new(hackFilePath);
            Parser parserSecondPass = new(srSecondPass);
            Coder coder = new();
            SecondPass(swSecondPass, srSecondPass, symbolModule, parserSecondPass, coder);
            Console.WriteLine("File successfully assembled to binary.");
        }
    }

    private static void FirstPass(StreamWriter sw, StreamReader sr, Symbols symbols, Parser parser)
    {
        int lineCount = 0;
        while (!sr.EndOfStream)
        {
            string currentLine = sr.ReadLine();
            string cleanLine = parser.CleanCurrentLine(currentLine);
            if (cleanLine == "")
                continue;
            else
            {
                if (parser.InstructionType(cleanLine) == "Linstr")
                {
                    symbols.AddEntry(parser.Symbol(cleanLine), lineCount);
                    lineCount--;
                }
                lineCount++;
                sw.WriteLine(cleanLine);
            }
        }
        sw.Close();
    }

    private static void SecondPass(StreamWriter sw, StreamReader sr, Symbols symbols, Parser parser, Coder coder)
    {
        int varCounter = 16;
        while(!sr.EndOfStream)
        {
            string currentLine = sr.ReadLine();
            string binaryLine;
            if (parser.InstructionType(currentLine) == "Linstr")
                continue;
            else if (parser.InstructionType(currentLine) == "Ainstr")
            {
                bool isAddress = int.TryParse(parser.Symbol(currentLine), out int address);
                if (isAddress)
                {
                    binaryLine = Convert.ToString(address, 2);
                    binaryLine = binaryLine.PadLeft(16, '0');
                    sw.WriteLine(binaryLine);
                }
                else if (symbols.Contains(parser.Symbol(currentLine)))
                {
                    address = symbols.GetAddress(parser.Symbol(currentLine));
                    binaryLine = Convert.ToString(address, 2);
                    binaryLine = binaryLine.PadLeft(16, '0');
                    sw.WriteLine(binaryLine);
                }
                else
                {
                    symbols.AddEntry(parser.Symbol(currentLine), varCounter);
                    binaryLine = Convert.ToString(varCounter, 2);
                    binaryLine = binaryLine.PadLeft(16, '0');
                    varCounter++;
                    sw.WriteLine(binaryLine);
                }
            }
            else
            {
                binaryLine = "111";
                binaryLine += coder.Comp(parser.Comp(currentLine));
                if (currentLine.Contains('='))
                    binaryLine += coder.Dest(parser.Dest(currentLine));
                else
                    binaryLine += coder.Dest("_");
                if (currentLine.Contains(';'))
                    binaryLine += coder.Jump(parser.Jump(currentLine));
                else
                    binaryLine += coder.Jump("_");
                sw.WriteLine(binaryLine);
            }
        }
        sw.Close();
    }
}