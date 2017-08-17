using System;
using TES30.API;
namespace TES30
{
    public class StartBlock : CodePart
    {
        public override string DisplayName
        {
            get
            {
                return "StartBlock";
            }
        }
        
        public override string Details
        {
            get
            {
                return "The starting block of the flow";

            }
        }


        public override bool IsRoutine
        {
            get
            {
                return false;
            }
        }

        public override bool Execute()
        {
            return true;
        }
    }
    public class IfBlock : CodePart
    {
        public override string DisplayName
        {
            get
            {
                return "If Block";
            }
        }

        public override string Details
        {
            get
            {
                if (Value1==null && Value2==null)
                    return "Executes the routine if the expression is true.";
                else
                    return "Executes the routine if " + Value1 + " is " + Value2;

            }
        }

        public object Value1 { get; set; }
        public object Value2 { get; set; }
        public override bool IsRoutine
        {
            get
            {
                return true;
            }
        }

        public override bool Execute()
        {
            return Value2.Equals(Value1);
        }
    }


}