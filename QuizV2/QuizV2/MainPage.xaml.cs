using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizV2
{
    public partial class MainPage : ContentPage
    {
        List<int> questionsCount = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        List<int> Listawylosowanych = new List<int>();
        bool isExist;
        List<QuizQuestion> pytania = new List<QuizQuestion>();
        Quiz quiz = new Quiz();
        int qCounter = 0;

        public MainPage()
        {
            InitializeComponent();
            StartGame();
            NextQuestion();
        }

        private void Checkclick(object sender, EventArgs e)
        {
                Button senderButton= sender as Button;
         if (senderButton.Text == pytania[questionsCount[0] - 1].realAnswer)    
            {
                quiz.score++;
                qCounter++;

                if (qCounter < questionsCount.Count)
                {
                LaWynik.Text = quiz.score + "/10";
                DisplayAlert("KLAAAAAAAASA", "masz farta", "SPOCZKO");
                   // pytania.Remove(pytania[questionsCount[0] - 1]);
                  
                    NextQuestion();
                }
                else
                {
                DisplayAlert("YEEE", $"Odpowiedziales dobrze na {quiz.score} pytan z {quiz.questionsCount}", "SPOCZKO");
                    RestartGame();

                }
            }
            else
            {
                qCounter++;

                if (qCounter < questionsCount.Count)
                {
                DisplayAlert("HAHAHHAHAH", "zle", "no SPOCZKO");
                   // pytania.Remove(pytania[questionsCount[0]-1]);
                    NextQuestion();
                }else
                {
                    DisplayAlert("YEEE", $"Odpowiedziales dobrze na {quiz.score} pytan z {quiz.questionsCount}", "SPOCZKO");
                    RestartGame();
                }

            }

        }

        private void StartGame()
        {

            
            


            List<string> question_answersList = new List<string>();
            question_answersList.Add("odpowiedz");
            question_answersList.Add("odpowiedz");
            question_answersList.Add("odpowiedz");
            question_answersList.Add(null);


            pytania.Add(new QuizQuestion("Pytanie1?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie2?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie3?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie4?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie5?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie6?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie7?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie8?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie9?", question_answersList, "KoziarCword"));
            pytania.Add(new QuizQuestion("Pytanie10?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie11?", question_answersList, "odpowiedzdobra"));
            pytania.Add(new QuizQuestion("Pytanie12?", question_answersList, "odpowiedzdobra"));





        }

        private void RestartGame()
        {
            quiz.score= 0;
            qCounter = 0;
            questionsCount = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12};
            LaWynik.Text = quiz.score + "/10";

            StartGame();
            NextQuestion();
        }

        private void NextQuestion()
        {
            Random rng = new Random();
            do
            {

                var losowoPytania = questionsCount.OrderBy(a => rng.Next()).ToList();
                questionsCount = losowoPytania;
                bool isExist = Listawylosowanych.Contains(questionsCount[0]);

            } while (isExist);
            Listawylosowanych.Add(questionsCount[0]);

            List<Button> buttons = new List<Button>();
            buttons.Add(ans1);
            buttons.Add(ans2);
            buttons.Add(ans3);
            buttons.Add(ans4);

            fotka.Source = "_" + (questionsCount[0]).ToString();

            var losowoguziki = buttons.OrderBy(a => rng.Next()).ToList();
            
            buttons = losowoguziki;
            foreach (var button in buttons)
            {
                button.Text = null;
            }

            for (int i = 0; i < 3; i++)
            {
                buttons[i].Text = pytania[questionsCount[0]-1].answers[i];
            }
            

        

            LaTresc.Text = pytania[questionsCount[0] - 1].content;

            foreach (var item in buttons)
            {
                if (item.Text == null)
                {
                    item.Text = pytania[questionsCount[0] - 1].realAnswer;
                }
            }

           
        }

        private void restartButton_Clicked(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
