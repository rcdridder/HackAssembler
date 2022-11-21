using HackAssembler.Interfaces;

namespace HackAssembler.Modules
{
    public class Symbols : ISymbols
    {
        private Dictionary<string, int> symbols;
        private Dictionary<string, int> preDefinedSymbols = new()
        {
            { "R0", 0 },
            { "R1", 1 },
            { "R2", 2 },
            { "R3", 3 },
            { "R4", 4 },
            { "R5", 5 },
            { "R6", 6 },
            { "R7", 7 },
            { "R8", 8 },
            { "R9", 9 },
            { "R10", 10 },
            { "R11", 11 },
            { "R12", 12 },
            { "R13", 13 },
            { "R14", 14 },
            { "R15", 15 },
            { "SCREEN", 16384 },
            { "KBD", 24576 },
            { "SP", 0 },
            { "LCL", 1 },
            { "ARG", 2 },
            { "THIS", 3 },
            { "THAT", 4 },
        };
        public Symbols(Dictionary<string, int> symbols)
        {
            this.symbols = symbols;
            foreach (var symbol in preDefinedSymbols)
            {
                symbols.Add(symbol.Key, symbol.Value);
            }
        }

        public void AddEntry(string symbol, int address) => symbols.Add(symbol, address);

        public bool Contains(string symbol) => symbols.ContainsKey(symbol);

        public int GetAddress(string symbol) => symbols[symbol];
    }
}
