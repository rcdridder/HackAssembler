namespace HackAssembler.Interfaces
{
    public interface ISymbols
    {
        /// <summary>
        /// Adds symbol to the symbol table.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="address"></param>
        void AddEntry(string symbol, int address);
        /// <summary>
        /// Checks if symbol exists in symbol table.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        bool Contains(string symbol);
        /// <summary>
        /// Return address of the given symbol.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public int GetAddress(string symbol);
    }
}
