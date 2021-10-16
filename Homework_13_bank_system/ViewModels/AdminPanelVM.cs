using Homework_13_bank_system.View;
using static Homework_13_bank_system.User;
namespace Homework_13_bank_system.ViewModels
{
    class AdminPanelVM : BaseViewModel
    {
        private RelayCommand createUser;
        public RelayCommand CreateUser => 
            createUser ??= new(CreateUserClick);

        private bool createUserBtnActivity;

        public bool CreateUserBtnActivity
        {
            get => createUserBtnActivity;
            set
            {
                if (currentUser.Name == "Администратор")
                    createUserBtnActivity = true;
                else createUserBtnActivity = false;
            }
        }
        private void CreateUserClick(object sender)
        {
            (new CreateUserForm()).ShowDialog();
        }

        public AdminPanelVM()
        {

        }
    }
}
