using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Reflection;
using TES30.API;
using System.Collections;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace TES30
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var splash = new splash();
            splash.Show();
            Game.Initialize();
            if(Environment.GetCommandLineArgs().Length >1)
            {
                Game.Load(Environment.GetCommandLineArgs()[1]);
            }
            if (!Directory.Exists(Application.StartupPath + "\\Plugins")) Directory.CreateDirectory(Application.StartupPath + "\\Plugins");
            var plugins = Directory.EnumerateFiles(Application.StartupPath + "\\Plugins");
            foreach (string plugin in plugins)
            {
                var file = new FileInfo(plugin);
                if (file.Extension != ".cs")
                {
                    MessageBox.Show(file.Name + " is not a plugin.");
                    continue;
                }
                try
                {
                    var stream = file.OpenText();
                    var script = new ScriptFile(stream.ReadToEnd());
                    stream.Dispose();
                    BlockList.Blocks.Add(script.Class);
                    File.Move(file.FullName, file.Directory.FullName + "\\" + script.Class.DisplayName + ".cs");
                }
                catch (Exception e)
                {
                    MessageBox.Show(splash, $"Plugin {file.Name} created an error:\n{e.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var Predefinedblocks = from t in Assembly.GetExecutingAssembly().GetTypes()
                                   where t.IsSubclassOf(typeof(TES30.API.CodePart))
                                   select t;
            foreach (Type cp in Predefinedblocks)
            {
                BlockList.Blocks.Add((CodePart)Activator.CreateInstance(cp));
            }
            splash.Close();
            splash.Dispose();
            Application.Run(new MainForm());
        }
    }
    public static class Game
    {
        public static Color[] Palette
        {
            get
            {
                return palette;
            }
            set
            {
                palette = value;
                if (PaletteChanged != null)
                    PaletteChanged.Invoke(null, value);
            }
        }
        private static Color[] palette;
        public static event EventHandler<Color[]> PaletteChanged;
        public static Sprite[] Sprites;
        public static TreeNode<CodePart> CodeTree;

        public static string Name = "TES30 Game";
        public static string Creator = "DefaultCompany";
        public static bool Initalized { get { return palette != null; } }
        public static void Initialize()
        {
            palette = new Color[16] { Color.Black, Color.Gray, Color.Maroon, Color.Red, Color.Green, Color.Lime, Color.Olive, Color.Yellow, Color.Navy, Color.Blue, Color.Purple, Color.Fuchsia, Color.Teal, Color.Aqua, Color.Silver, Color.White };
            Sprites = Enumerable.Repeat(false, 256).Select(x => new Sprite()).ToArray();

        }
        public static void Save(string Path)
        {
            // Create a hashtable of values that will eventually be serialized.
            Hashtable Data = new Hashtable();
            Data.Add("Palette", Palette);
            Data.Add("Sprites", Sprites);
            Data.Add("Name", Name);
            Data.Add("Creator", Creator);

            // To serialize the hashtable (and its key/value pairs), 
            // you must first open a stream for writing.
            // Use a file stream here.
            FileStream fs = new FileStream(Path, FileMode.Create);

            // Construct a SoapFormatter and use it 
            // to serialize the data to the stream.
            SoapFormatter formatter = new SoapFormatter();
            try
            {
                formatter.Serialize(fs, Data);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to serialize. Reason: " + e.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public static void Load(string Path)
        {
            Hashtable addresses = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(Path, FileMode.Open);
            try
            {
                SoapFormatter formatter = new SoapFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                addresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.Instance.Log("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs to the console.
            foreach (DictionaryEntry de in addresses)
            {
                switch(de.Key)
                {
                    case "Palette":
                    palette = (Color[])de.Value;
                    break;
                    case "Sprites":
                    Sprites = (Sprite[])de.Value;
                    break;
                    case "Name":
                    Name = (string)de.Value;
                    break;
                    case "Creator":
                    Creator = (string)de.Value;
                    break;
                }
            }
        }
    }
}
