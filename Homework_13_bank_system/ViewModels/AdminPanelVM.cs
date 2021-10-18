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
            get => CurrentUser.CanCreateUsers;
        }

        public bool HaveEditRights
        {
            get => CurrentUser.HaveUserEditRights;
        }

        public static CreateUserForm createUserForm;

        private void CreateUserClick(object sender)
        {
            createUserForm = new();
            createUserForm.ShowDialog();
        }

        public static UsersPermissionsPanel editPermissionsWindow;

        private RelayCommand editPermissions;
        public RelayCommand EditPermissions =>
            editPermissions ??= new(EditPermissionsClick);
        private void EditPermissionsClick(object sender)
        {
            editPermissionsWindow = new();
            editPermissionsWindow.ShowDialog();
        }
    }
}
