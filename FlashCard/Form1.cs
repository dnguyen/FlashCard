using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FlashCard
{
    public partial class Form1 : Form
    {
        List<string[]> questionsAnswers = new List<string[]>();
        int currentQuestion = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("questions.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] questionAnswer = line.Split('-');
                    questionsAnswers.Add(questionAnswer);
                }
            }

            txtQuestion.Text += questionsAnswers[0][0] + "\r\n";
            txtAnswer.Text += questionsAnswers[0][1] + "\r\n";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Visible)
                txtAnswer.Visible = false;
            else
                txtAnswer.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtAnswer.Visible = false;

            if (currentQuestion >= questionsAnswers.Count - 1)
            {
                currentQuestion = 0;
            }
            else
            {
                currentQuestion++;
            }

            txtQuestion.Text = questionsAnswers[currentQuestion][0] + "\r\n";
            txtAnswer.Text = questionsAnswers[currentQuestion][1] + "\r\n";

        }
    }
}
