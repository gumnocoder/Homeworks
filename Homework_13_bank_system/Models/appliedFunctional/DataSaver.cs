using System.Windows;
using static Homework_13_bank_system.Models.appliedFunctional.JsonDataLoadSave;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataSaver
    {
        private static void savingBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingChain();
        }

        public static void SavingChain()
        {
            JsonSeralize(usersList, "users.json");
        }
    }
}
