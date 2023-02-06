using System;
using System.Collections.Generic;
using System.Text;

namespace QuizV2
{
    class Quiz
    {
       public int score { get; set; }
      public  int questionsCount { get; set; }

            
        public Quiz() { 
        
            score= 0;
            questionsCount= 10;

        }

    }

    class QuizQuestion
    {
       public string content { get; set; }
        public List<string> answers { get; set; }
       public string realAnswer { get; set; }

        public QuizQuestion(string c, List<string> ans, string rans)
        {
            this.content = c;
            this.answers = ans;
            this.realAnswer = rans;

        }



    }
}


