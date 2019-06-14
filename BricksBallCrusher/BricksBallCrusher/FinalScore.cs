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
    public partial class FinalScore : Form
    {
        public FinalScore()
        {
            InitializeComponent();
            lblBestScore.BackColor = Color.Transparent;
            lblScore.BackColor = Color.Transparent;
            lblScore.Text = Form1.SetValueForFinalePoints.ToString();
        }

        private void FinalScore_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
