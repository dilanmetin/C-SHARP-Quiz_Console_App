using System;

class Question

        
{
   
    public Question(string text, string[] choices, string answer)
    {
        this.Text = text;
        this.Choices = choices;
        this.Answer = answer;
        
    }
    
    public string Text { get; set; }

    public string[] Choices { get; set; }

    public string Answer { get; set; }

    public bool checkAnswer (string answer)
    {
      return   this.Answer.ToLower() == answer.ToLower(); 
    }
}
class Quiz
{
    public Quiz(Question[] questions)
    {
        this.Questions = questions;
        this.QuestionIndex = 0;
        this.Score = 0;
    }
    private Question[] Questions { get; set; }

    private int QuestionIndex { get; set; }
    private int Score { get; set; }

    private Question GetQuestion()
    {
        return this.Questions[this.QuestionIndex];  
    }
    public void DisplayQuestion()
    {
        var question = this.GetQuestion();
        this.DisplayProgress();

        Console.WriteLine($"Soru {this.QuestionIndex+1}: {question.Text}");
        foreach (var c in question.Choices)
        {
            Console.WriteLine($"-{c}");
        }

        Console.Write("cevap:");
        var result = Console.ReadLine();
        this.Guess(result);
    }
    private void Guess(string answer)
    {
        var question = this.GetQuestion();
        if (question.checkAnswer(answer))
        {
            Score++;
        }
        this.QuestionIndex++;
        if (this.Questions.Length == this.QuestionIndex)
        {
            this.DisplayScore();
        }
        else
        {
            this.DisplayQuestion();

        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"Skor: {this.Score}");
    }

    private void DisplayProgress()
    {
        int totalQuestion = this.Questions.Length;
        int questionNumber = this.QuestionIndex + 1;
        if(totalQuestion>=questionNumber) {
            Console.WriteLine($"Question {questionNumber} of {totalQuestion}");
        }
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        var q1 = new Question("Mod alma işlemini aşağıdaki karakterlerden hangisi gerçekleştirir?", new string[] { "A) >", "B) !", "C) %", "D) &" }, "C");
        var q2 = new Question("Program boyunca sabit kalacak veriyi hangi kelime ile tanımlarız?", new string[] { "A) FLOAT", "B) DOUBLE", "C) BOOL", "D) CONST" }, "D");
        var q3 = new Question("Aşağıdakilerden hangisi veri tiplerinden değildir?", new string[] { "A) STRİNG", "B) SLONG", "C) İNT", "D) BYTE" }, "B");

        var questions = new Question[] { q1, q2, q3 };

        var quiz = new Quiz(questions);
        

        quiz.DisplayQuestion();    


    } 
}