using System.Collections.Generic;

namespace Homework_13_bank_system
{
    class UsersLists
    {
        public static List<User> usersList;

        public User this[int Id]
        {
            get 
            {
                User u = null;

                if (usersList.Count > 0)
                {
                    foreach (User t in usersList)
                    {  if (t.UserId == Id) { u = t; } }
                }

                return u;
            }
        }
        public User this[string Name]
        {
            get
            {
                User u = null;

                if (usersList.Count > 0)
                {
                    foreach (User t in usersList)
                    { if (t.Name.ToLower() == Name.ToLower()) { u = t; } }
                }

                return u;
            }
        }

        public UsersLists()
        {
            usersList = new();
        }

        public static void AddToList(User user)
        {
            usersList.Add(user);
        }

        
    }
}
