using System.Diagnostics;
using System.Windows;
using static Homework_13_bank_system.ViewModels.AdminPanelVM;

namespace Homework_13_bank_system.ViewModels
{
    class CreateUserFormVM
    {
        private RelayCommand createUser;
        private string name = string.Empty;
        private string login = string.Empty;
        private string pass = string.Empty;
        private string type = string.Empty;

        string[] types = {
            "администратор",
            "модератор",
            "операционист",
            "специалист по ВИП",
            "специалист по Юр.лицам"
        };

        public string[] Types
        {
            get => types;
            set => types = value;
        }

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

        public string Type
        {
            get => type;
            set => type = value;
        }
        public RelayCommand CreateUser
        {
            get => createUser ??= new(CreateUserMethod);
        }
        private void CreateUserMethod(object sender)
        {
            if (
                Name != string.Empty &
                Login != string.Empty &
                Pass != string.Empty &
                Type != string.Empty)
            {
                new User(Name, Login, Pass, Type);

            }

            else { MessageBox.Show("Заполните все поля!"); }

            createUserForm.Close();
        }

        //private RelayCommand cancelBtn;
        //public RelayCommand CancelBtn
        //{
        //    get => cancelBtn ??= new(CancelBtnClick);
        //}

        //private void CancelBtnClick(object sender)
        //{
        //    createUserForm.Close();
        //}

        public static readonly RelayCommand CloseCommand =
            new(o => ((Window)o).Close());
    }
}
