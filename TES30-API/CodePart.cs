using System;
using System.ComponentModel;
namespace TES30.API
{
    //<summary>
    //the base class of a extra code block
    //</summary>
    public abstract class CodePart
    {

        /// <summary>
        /// The title of the codeblock
        /// </summary>
        [DisplayName("Title")]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// an extra line of information about the function of the block.
        /// </summary>
        public virtual string Details { get; set; }
        /// <summary>
        /// Tells TES-30 that this code block can contain children to execute.
        /// </summary>

        public virtual bool IsRoutine { get; set; }
        /// <summary>
        /// This is the method that executes all the logic.
        /// </summary>
        /// <returns>a boolean, that tells TES-30 that the children should execute.</returns>
        public abstract bool Execute();
    }
}
