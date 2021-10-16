using System.Diagnostics;
using Homework_13_bank_system.ViewModels;
using static Homework_13_bank_system.IdSetter;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system
{
    public class User : BaseViewModel
    {
        public static User currentUser = null;



        string login;
        public string Login
        {
            get => login;
            set => login = value;
        }

        int userId;
        public int UserId 
        { 
            get => userId; 
            set => userId = value; 
        }

        string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        string pass;
        public string Pass
        {
            get => pass;
            set => pass = value;
        }

        //public User(string Name, string Pass)
        //{
        //    this.Name = Name;
        //    this.Pass = Pass;
        //    UserId = ReturnCurrentId();
        //    AddToList(this);
        //    writeOrderToFile();
        //}

        public User(string Name, string Login, string Pass)
        {
            this.Name = Name;
            this.Login = Login;
            this.Pass = Pass;
            UserId = ReturnCurrentId();
            AddToList(this);
            foreach (var e in usersList)
            {
                Debug.WriteLine(e);
            }
            writeOrderToFile();
        }

        public void ReName(string newName)
        {
            Name = newName;
        }

        public void ResetPass(string newPass)
        {
            Pass = newPass;
        }
        public override string ToString()
        {
            //string tmpName = Name ?? Login;
            return $"[{UserId}] {Name}";
        }
    }
}
