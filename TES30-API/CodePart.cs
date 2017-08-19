using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TES30.API
{
	//<summary>
	//the base class of a extra code block
	//</summary>
	[Serializable]
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
		private Guid GUID;
		public CodePart()
		{
			GUID = Guid.NewGuid();
		}
		public CodePart CreateEmpty()
		{
			return (CodePart)Activator.CreateInstance(this.GetType());
		}
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
