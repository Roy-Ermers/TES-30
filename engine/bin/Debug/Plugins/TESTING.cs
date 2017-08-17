    public class Test : CodePart
    {
		public object Name { get; set; }
        public override string DisplayName
        {
            get {
				return Name.ToString();
			}
        }
        public override string Details
        {
            get
            {
                return "TEST 1 2 3 4";

            }
        }
    public string Hello { get { return "Hallo"; } }
		public Test() {
			Name = "TESTING";
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
            return false;
        }
    }
