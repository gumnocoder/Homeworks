using Homework_13_bank_system.ViewModels;

namespace Homework_13_bank_system
{
    public abstract class UsersPermissions : BaseViewModel
    {
        #region Поля
        private bool canCreateUsers;
        private bool canCreateClients;
        private bool canRemoveUsers;
        private bool canRemoveClients;
        private bool haveUserEditRights;
        private bool canCloseAccounts;
        private bool canOpenDebitAccounts;
        private bool canOpenCreditAccounts;
        private bool haveAccessToAppSettings;
        #endregion
        #region Свойства
        public bool HaveAccessToAppSettings
        {
            get => haveAccessToAppSettings;
            set
            {
                haveAccessToAppSettings = value;
                OnPropertyChanged();
            }
        }
        public bool CanOpenCreditAccounts
        {
            get => canOpenCreditAccounts;
            set
            {
                canOpenCreditAccounts = value;
                OnPropertyChanged();
            }
        }
        public bool CanOpenDebitAccounts
        {
            get => canOpenDebitAccounts;
            set
            {
                canOpenDebitAccounts = value;
                OnPropertyChanged();
            }
        }
        public bool CanCloseAccounts
        {
            get => canCloseAccounts;
            set
            {
                canCloseAccounts = value;
                OnPropertyChanged();
            }
        }
        public bool HaveUserEditRights
        {
            get => haveUserEditRights;
            set
            {
                haveUserEditRights = value;
                OnPropertyChanged();
            }
        }

        public bool CanCreateUsers
        {
            get => canCreateUsers;
            set
            {
                canCreateUsers = value;
                OnPropertyChanged();
            }
        }

        public bool CanCreateClients
        {
            get => canCreateClients;
            set
            {
                canCreateClients = value;
                OnPropertyChanged();
            }
        }

        public bool CanRemoveUsers
        {
            get => canRemoveUsers;
            set
            {
                canRemoveUsers = value;
                OnPropertyChanged();
            }
        }

        public bool CanRemoveClients
        {
            get => canRemoveClients;
            set
            {
                canRemoveClients = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public void Turn(bool property)
        {
            property = !property;
        }
    }
}







