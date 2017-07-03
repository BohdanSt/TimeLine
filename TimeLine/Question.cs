using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeLine
{
    class Question
    {

        public string Name { get; set; }
        public int Index { get; set; }

        public static List<Question> ReadQuestions()
        {
            int i = 0;
            List<Question> Qst = new List<Question>();
            string[] readText = File.ReadAllLines("Question.txt");
            foreach (string s in readText)
            {
                i++;
                Qst.Add(new Question() { Name = s, Index = i });   
            }
            return Qst;
        }

    }
}
