using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.IdSetter;
using static Homework_13_bank_system.JsonDataLoadSave;
using Homework_13_bank_system.ViewModels;

namespace Homework_13_bank_system
{
    public class User : BaseViewModel
    {
        public static User currentUser = null;

        int userId;
        public int UserId 
        { 
            get => userId; 
            set => userId = value; 
        }

        public string Name 
        {
            get ;
            set;
        }

        string pass;
        public string Pass 
        { 
            get => pass;
            set => pass = value; 
        }

        public User(string Name, string Pass)
        {
            this.Name = Name;
            this.Pass = Pass;
            UserId = ReturnCurrentId();
            AddToList(this);
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
            return $"{Name} {Pass} {UserId}";
        }
    }
}
