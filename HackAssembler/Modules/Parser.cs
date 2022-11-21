using HackAssembler.Interfaces;

namespace HackAssembler.Modules
{
    public class Parser: IParser
    {
        private StreamReader file;

        public Parser(StreamReader file)
        {
            this.file = file;
        }

        public string CleanCurrentLine(string input)
        {
            if (input.Contains("//"))
                input = input.Remove(input.IndexOf("//"));
            return input.Trim();
        }

        public string InstructionType(string command)
        {
            if (command[0] == '@')
                return "Ainstr";
            else if (command[0] == '(')
                return "Linstr";
            else
                return "Cinstr";
        }

        public string Symbol(string command)
        {
            if (command[0] == '(')
                return command.Substring(1, command.Length - 2);
            else
                return command.Substring(1);
        }

        public string Comp(string command)
        {
            if (command.Contains('='))
                command = command.Substring(command.IndexOf("=") + 1);
            if (command.Contains(';'))
                command = command.Substring(0, command.Length - command.Substring(command.IndexOf(";")).Length);
            return command;
        }

        public string Dest(string command) => command.Substring(0, command.Length - command.Substring(command.IndexOf("=")).Length);

        public string Jump(string command) => command.Substring(command.IndexOf(";") + 1);
    }
}

