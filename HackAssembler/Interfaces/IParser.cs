using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAssembler.Interfaces
{
    public interface IParser
    {
        /// <summary>
        /// Removes comments and whitespace from current command.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string CleanCurrentLine(string input);
        /// <summary>
        /// Parses instruction type (A, C or L) from current command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string InstructionType(string command);
        /// <summary>
        /// Parses symbol from current command (if command = A- or L-instruction).
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string Symbol(string command);
        /// <summary>
        /// Parses computation part from current command (if command = C-instruction).
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string Comp(string command);
        /// <summary>
        /// Parses destination part from current command (if command = C-instruction).
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string Dest(string command);
        /// <summary>
        /// Parses jump part from current command (if command = C-instruction).
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string Jump(string command);
    }
}
