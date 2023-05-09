namespace JustMeetWebService.Models
{
    public partial class UserGame
    {
        public UserGame(int idGame, int idUser)
        {
            IdGame = idGame;
            IdUser = idUser;
        }
        //public int IdGame { get; set; }

        //public int IdUser { get; set; }

        //public virtual Game IdGameNavigation { get; set; } = null!;

        //public virtual User IdUserNavigation { get; set; } = null!;

        //public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
