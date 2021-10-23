using System;
using System.ComponentModel;
using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;

namespace Homework_13_bank_system.Models.personsBin
{
    public class User : UsersPermissions, ISerializible, IRenamableObject
    {
        public static User CurrentUser;

        string login;
        public string Login
        {
            get => login;
            set => login = value;
        }

        long userId;
        public long UserId
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

        public User(string Name, string Login, string Pass, string Type)
        {
            this.Name = Name;
            this.Login = Login;
            this.Pass = Pass;
            this.Type = Type;
            SetId();
            UsersLists<User>.AddToList(this);
        }

        private void SetId()
        {
            UserId = ++ThisBank.currentUserID;
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
            return $"[{UserId}] {Name}, {Type}";
        }
    }
}







