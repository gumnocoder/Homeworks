using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13_bank_system.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
