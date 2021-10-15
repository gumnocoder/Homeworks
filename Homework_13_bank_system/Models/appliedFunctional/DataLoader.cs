using static Homework_13_bank_system.Models.appliedFunctional.JsonDataLoadSave;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataLoader
    {
        public static void LoadingChain()
        {
            UsersLists bd = new();
            usersList = UsersFromJson();
        }

    }
}
