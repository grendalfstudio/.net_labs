namespace EBanking.Logic
{
    public class SampleUser : User
    {
        public SampleUser()
        {
        }

        public SampleUser(AbstractUser<string> usr) : base(usr)
        {
        }

        public SampleUser(int id, string name, string surname, string password) : base(id, name, surname, password)
        {
        }

        
    }
}