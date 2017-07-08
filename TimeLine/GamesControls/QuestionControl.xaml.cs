﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLine.GamesControls
{
    /// <summary>
    /// Interaction logic for QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        public Question Question {get; set;}

        public QuestionControl(Question question)
        {
            InitializeComponent();

            line.Width = this.Width / 4;
            line.X2 = this.Width / 4;

            Question = question;
            textBlockQuestion.Text = question.Name;
        }
    }
}
