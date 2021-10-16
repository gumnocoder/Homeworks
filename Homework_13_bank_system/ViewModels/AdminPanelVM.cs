using Homework_13_bank_system.View;
using static Homework_13_bank_system.User;
namespace Homework_13_bank_system.ViewModels
{
    class AdminPanelVM : BaseViewModel
    {
        private RelayCommand createUser;
        public RelayCommand CreateUser => 
            createUser ??= new(CreateUserClick);

        public bool CreateUserBtnActivity
        {
            get => true;
            //get => CurrentUser.CanCreateUsers;
        }

        public static CreateUserForm createUserForm;

        private void CreateUserClick(object sender)
        {
            createUserForm = new();
            createUserForm.ShowDialog();
        }
    }
}
