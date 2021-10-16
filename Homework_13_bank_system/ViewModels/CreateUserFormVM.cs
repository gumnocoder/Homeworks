using System.Diagnostics;
using static Homework_13_bank_system.UsersLists;
namespace Homework_13_bank_system.ViewModels
{
    class CreateUserFormVM
    {
        private RelayCommand createUser;
        private string name = "";
        private string login = "";
        private string pass = "";

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Login
        {
            get => login;
            set => login = value;
        }

        public string Pass
        {
            get => pass;
            set => pass = value;
        }
        public RelayCommand CreateUser
        {
            get => createUser ??= new(CreateUserMethod);
        }
        private void CreateUserMethod(object sender)
        {
            if (Name != "" & Login != "" & Pass != "")
            {
                new User(Name, Login, Pass);
                Debug.WriteLine(usersList.Count);
                Name = "";
                Login = "";
                Pass = "";
            }
                
            else { System.Windows.MessageBox.Show("Заполните все поля!"); }
        }
    }
}
