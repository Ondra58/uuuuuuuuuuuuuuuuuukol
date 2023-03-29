using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader ctenar = new StreamReader("sport.txt");
            FileStream datovytok = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter zapisovac = new BinaryWriter(datovytok, Encoding.GetEncoding("windows-1250"));
            char[] oddelovace = { ';' };
            while(!ctenar.EndOfStream)
            {
                string zaznam = ctenar.ReadLine();
                string[] pole = zaznam.Split(oddelovace);
                int osc = Convert.ToInt32(pole[0]);
                zapisovac.Write(osc);
                string jmeno = pole[1];
                zapisovac.Write(jmeno);
                string prijmeni = pole[2];
                zapisovac.Write(prijmeni);
                char pohlavi = Convert.ToChar(pole[3]);
                zapisovac.Write(pohlavi);
                int vyska = Convert.ToInt32(pole[4]);
                zapisovac.Write(vyska);
                int hmotnost = Convert.ToInt32(pole[5]);
                zapisovac.Write(hmotnost);
            }
            ctenar.Close();
            BinaryReader ctenar2 = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            ctenar2.BaseStream.Position = 0;
            while(ctenar2.BaseStream.Position < ctenar2.BaseStream.Length)
            {
                string zaznam = "";
                int osc = ctenar2.ReadInt32();
                string jmeno = ctenar2.ReadString();
                string prijmeni = ctenar2.ReadString();
                char pohlavi = ctenar2.ReadChar();
                int vyska = ctenar2.ReadInt32();
                int hmotnost = ctenar2.ReadInt32();
                zaznam = osc + ";" + jmeno + ";" + prijmeni + ";" + pohlavi + ";" + vyska + ";" + hmotnost + ";";
                textBox1.Text += zaznam + Environment.NewLine;
            }
            ctenar2.Close();
        }
    }
}
