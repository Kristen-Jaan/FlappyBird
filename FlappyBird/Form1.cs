using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int gravity = 10;
        int PipeSpeed = 6;
        int Score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            PipeTop.Left -= PipeSpeed;
            PipeBottom.Left -= PipeSpeed;
            ScoreLabel.Text = $"Score: {Score}";

            if(PipeTop.Left < -130)
            {
                PipeTop.Left = 574;
                Score++;
            }

            if(PipeBottom.Left < -130)
            {
                PipeBottom.Left = 674;
                Score++;
            }

            if(Bird.Top < -25)
            {
                GameOver();
            }

            if(Bird.Bounds.IntersectsWith(PipeTop.Bounds) || Bird.Bounds.IntersectsWith(PipeBottom.Bounds) || Bird.Bounds.IntersectsWith(Grounds.Bounds))
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void GameOver()
        {
            timer1.Stop();
            ScoreLabel.Text = $"Game Over";
            PlayAgain.Visible = true;
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
