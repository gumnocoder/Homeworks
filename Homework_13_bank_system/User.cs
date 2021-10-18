using System.ComponentModel;
using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.ViewModels;
using static Homework_13_bank_system.IdSetter;
//using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system
{
    public interface IManager
    {

    }

    public interface IRegular : IManager
    {

    }

    public interface IVip : IManager
    {

    }

    public interface ILegalEntity : IManager
    {

    }

    public abstract class UsersPermissions : BaseViewModel
    {
        bool canCreateUsers;
        bool canCreateClients;
        bool canRemoveUsers;
        bool canRemoveClients;
        bool haveUserEditRights;
        bool canCloseAccounts;
        bool canOpenDebitAccounts;
        bool canOpenCreditAccounts;
        public bool CanOpenCreditAccounts
        {
            get => canOpenCreditAccounts;
            set => canOpenCreditAccounts = value;
        }
        public bool CanOpenDebitAccounts
        {
            get => canOpenDebitAccounts;
            set => canOpenDebitAccounts = value;
        }
        public bool CanCloseAccounts
        {
            get => canCloseAccounts;
            set => canCloseAccounts = value;
        }
        public bool HaveUserEditRights
        {
            get => haveUserEditRights;
            set => haveUserEditRights = value;
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
            set => canCreateClients = value;
        }

        public bool CanRemoveUsers
        {
            get => canRemoveUsers;
            set => canRemoveUsers = value;
        }

        public bool CanRemoveClients
        {
            get => canRemoveClients;
            set => canRemoveClients = value;
        }
        public void Turn(bool property)
        {
            property = !property;
        }
    }

    public class User : UsersPermissions, ISerializible
    {
        public static User CurrentUser;

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

        string type;

        public string Type
        {
            get => type;
            set => type = value;
        }

        //public User(string Name, string Pass)
        //{
        //    this.Name = Name;
        //    this.Pass = Pass;
        //    UserId = ReturnCurrentId();
        //    AddToList(this);
        //    writeOrderToFile();
        //}

        public User(string Name, string Login, string Pass, string Type)
        {
            this.Name = Name;
            this.Login = Login;
            this.Pass = Pass;
            this.Type = Type;
            UserId = ReturnCurrentId();
            UsersLists<User>.AddToList(this as User);
            foreach (var e in UsersLists<User>.usersList)
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







