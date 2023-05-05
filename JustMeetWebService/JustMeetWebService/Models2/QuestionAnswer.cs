namespace JustMeetWebService.Models2
{
    public partial class QuestionAnswer
    {
        public int idQuestion { get; set; }
        public int idAnswer { get; set; }

        public QuestionAnswer(int idQuestion, int idAnswer)
        {
            this.idQuestion = idQuestion;
            this.idAnswer = idAnswer;
        }
    }
}
