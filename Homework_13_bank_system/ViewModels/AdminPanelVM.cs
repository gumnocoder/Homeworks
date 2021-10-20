using Homework_13_bank_system.View;
using static Homework_13_bank_system.Models.personsBin.User;

namespace Homework_13_bank_system.ViewModels
{
    class AdminPanelVM : BaseViewModel
    {
        #region Команды

        private RelayCommand createUser;
        public RelayCommand CreateUser =>
            createUser ??= new(CreateUserClick);
        private void CreateUserClick(object sender)
        {
            createUserForm = new();
            createUserForm.ShowDialog();
        }

        private RelayCommand createClient;
        public RelayCommand CreateClient =>
            createClient ??= new(CreateClientClick);
        private void CreateClientClick(object sender)
        {

        }

        private RelayCommand appSettings;
        public RelayCommand AppSettings =>
            appSettings ??= new(AppSettingsClick);
        private void AppSettingsClick(object sender)
        {

        }

        private RelayCommand editPermissions;
        public RelayCommand EditPermissions =>
            editPermissions ??= new(EditPermissionsClick);
        private void EditPermissionsClick(object sender)
        {
            editPermissionsWindow = new();
            editPermissionsWindow.ShowDialog();
        }

        #endregion

        #region Активность кнопок
        public bool CreateUserBtnActivity => CurrentUser.CanCreateUsers;

        public bool HaveEditRights => CurrentUser.HaveUserEditRights;
        public bool CreateUsersBtnActivity => CurrentUser.CanCreateUsers;
        public bool LoginedAsAdministrator => CurrentUser.Type == "администратор";

        #endregion

        #region Переменные

        public static CreateUserForm createUserForm;

        public static UsersPermissionsPanel editPermissionsWindow;

        #endregion
    }
}
