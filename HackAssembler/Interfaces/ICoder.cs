namespace HackAssembler.Interfaces
{
    public interface ICoder
    {
        /// <summary>
        /// Returns binary version of the destination part of a command.
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        string Dest(string dest);
        /// <summary>
        /// Returns binary version of the computation part of a command.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        string Comp(string comp);
        /// <summary>
        /// Returns binary version of the jump part of a command.
        /// </summary>
        /// <param name="jump"></param>
        /// <returns></returns>
        string Jump(string jump);
    }
}
