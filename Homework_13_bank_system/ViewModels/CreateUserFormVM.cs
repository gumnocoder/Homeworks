using System.Diagnostics;
using System.Windows;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.ViewModels.AdminPanelVM;

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
                
            else { MessageBox.Show("Заполните все поля!"); }
        }

        private RelayCommand cancelBtn;
        public RelayCommand CancelBtn
        {
            get => cancelBtn ??= new(CancelBtnClick);
        }

        private void CancelBtnClick(object sender)
        {
            AdminPanelVM.createUserForm.Close();
        }

        public static readonly RelayCommand CloseCommand =
            new(o => ((Window)o).Close());
    }
}
