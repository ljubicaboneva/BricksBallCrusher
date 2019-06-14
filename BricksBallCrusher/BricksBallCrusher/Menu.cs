using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BricksBallCrusher
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            FinalScore final = new FinalScore();
            this.Hide();
            final.ShowDialog();
            this.Close();
        }
        
    }
}
