using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TES30
{
    public partial class MainForm : Form
    {
        FormState state;
        public MainForm()
        {
            InitializeComponent();
            teS_Button1.Click += blockList1.OnCancel;
            console1.CommandSubmitted += Console1_CommandSubmitted;
            spriteSelector1.SelectedIndexChanged += spriteSelector1_SelectedIndexChanged;
            state = new FormState();
            state.Save(this);
        }
        private void Console1_CommandSubmitted(Console sender, string command)
        {
            switch (command.Split(' ')[0].ToUpper())
            {
                //color
                case "COLOR":
                sender.Log("^0black\t\t=0\n" +
                    "^1gray\t\t=1\n" +
                    "^2maroon\t\t=2\n" +
                    "^3red\t\t=3\n" +
                    "^4green\t\t=4\n" +
                    "^5lime\t\t=5\n" +
                    "^6olive\t\t=6\n" +
                    "^7yellow\t\t=7\n" +
                    "^8navy\t\t=8\n" +
                    "^9blue\t\t=9\n" +
                    "^apurple\t\t=A\n" +
                    "^bfuchsia\t=B\n" +
                    "^cteal\t\t=C\n" +
                    "^daqua\t\t=D\n" +
                    "^esilver\t\t=E\n" +
                    "^fwhite\t\t=F\n");
                break;
                //backcolor
                case "BACKCOLOR":
                sender.BackColor = command.Split(' ')[1][0].ToString();
                break;
                //clear
                case "CLS":
                case "CLEAR":
                sender.Clear();
                break;
                //tree
                case "TREE":
                sender.Log(TreeNode<API.CodePart>.CreateMap(CodeTree.Instance.Tree));
                break;
                //fullscreen
                case "FULLSCREEN":
                state.Save(this);
                state.Maximize(this);
                    break;
                case "WINDOWED":
                state.Restore(this);
                break;
                //palette
                case "PALETTE":
                Game.Palette[int.Parse(command.Split(' ')[1], System.Globalization.NumberStyles.HexNumber)] = Color.FromName(command.Split(' ')[2]);
                sender.Log($"Changed address {command.Split(' ')[1]} to color ^{int.Parse(command.Split(' ')[1], System.Globalization.NumberStyles.HexNumber)}{command.Split(' ')[2]}^f.");
                break;
                //exit
                case "CLOSE":
                case "EXIT":
                Close();
                break;
                case "SPRITE":
                int Char = 0;
                string line = "";
                var data = Game.Sprites[int.Parse(command.Split(' ')[1])].data;
                foreach (char c in data)
                {
                    line += '^';
                    line += c;
                    line += '▓';
                    line += '▓';
                    if (Char == 7)
                    {
                        sender.Log(line);
                        line = "";
                        Char = -1;
                    }
                    Char++; 
                }
                break;
                //help
                case "HELP":
                Help(sender, command.Split(' '));
                break;
                default:
                sender.Log("Command^3'" + command.Split(' ')[0] + "'^fnot found.");
                break;
            }
        }

        private static void Help(Console sender, string[] command)
        {
            //command[0] will always return "HELP"
            if (command.Length > 1)
                switch (command[1].ToUpper())
                {
                    case "PALETTE":
                    sender.Log("\t^7Palette^f\n" +
                        "\t\t2 argument(s):\n" +
                        "\t\t\t^4Address^f\tThe address in the palette to change to ^4Color\n" +
                        "\t\t\t^4Color^f\t  A known color like: \"yellow\" or \"LIGHTBLUE\"\n" +
                        "\t^1Info:\n" +
                        "\tUse this command to add colors to your application you really need, but you can maximally use 16 colors in your application.");
                    break;
                    case "COLOR":
                    sender.Log("\t^7Color^f\n" +
                                "\t\t0 argument(s)\n" +
                                "\t^1Info:\n" +
                                "\tUse this command to show a list of colors, this can be handy to use ^7Palette^f or ^7Backcolor.");
                    break;
                    case "BACKCOLOR":
                    sender.Log("\t^7backcolor^f\n" +
                                "\t\t1 argument(s):\n" +
                                "\t\t\t^4ColorAddress^f   The color to use as backcolor.\n" +
                                "\t^1Info:\n" +
                                "\tUse this command to change the background color of the console to ^4ColorAddress^f.");
                    break;
                    case "SPRITE":
                    sender.Log("\t^7sprite^f\n" +
                        "\t\t1 argument(s):\n" +
                        "\t\t\t^4index^f\tthe index of the sprite (between 0 and 255)\n" +
                        "\t^1Info:\n" +
                        "\tuse this command to see the sprite printed out in the console.");
                    break;
                }
            else sender.Log("^fhelp\t\t^1list all possible commands\n" +
                   "^fcolor\t\t^1get a list of all color codes\n" +
                   "^fcls\t\t^1clear the screen\n" +
                   "^fbackcolor\t^1change the background color\n" +
                   "^fpalette\t^1change the address color to a specific color.\n" +
                   "^fsprite\t\t^1display a sprite in console");
        }

        private void spriteSelector1_SelectedIndexChanged(object sender, int e)
        {
            spritePainter1.ChangeIndex(e);
        }

        private void teS_textbox1_ValueChanged(object sender, string e)
        {
            Game.Name = e;
        }

        private void teS_textbox2_ValueChanged(object sender, string e)
        {
            Game.Creator = e;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void teS_Button2_Click(object sender, EventArgs e)
        {
            TES30.Controls.GameView.Instance.Playing = !TES30.Controls.GameView.Instance.Playing;
            teS_Button2.Text = TES30.Controls.GameView.Instance.Playing ? "stop" : "play";
        }

        private void blockList1_Click(object sender, EventArgs e)
        {

        }

        private void teS_Button3_Click(object sender, EventArgs e)
        {
            PropertyWindow.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.Save(Application.StartupPath + $"\\{Game.Name}.TES");
        }
    }
    public static class Helpers
    {
        public static Color TextColor(this Color c)
        {
            var r = (int)Math.Sqrt(c.R * c.R * .241 +
            c.G * c.G * .691 +
            c.B * c.B * .068);
            return (r > 130 ? Color.Black : Color.White);
        }
    }
}
