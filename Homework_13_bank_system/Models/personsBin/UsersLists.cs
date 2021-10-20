using System.Collections.Generic;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system
{
    class UsersLists<T> where T : ISerializible
    {
        public static List<T> usersList;

        public T this[int Id]
        {
            get
            {
                T u = default;

                if (usersList.Count > 0)
                {
                    foreach (T t in usersList)
                    { if ((t as User).UserId == Id) { u = t; } }
                }

                return u;
            }
        }
        public T this[string NameOrLogin]
        {
            get
            {
                T u = default;

                if (usersList.Count > 0)
                {
                    foreach (T t in usersList)
                    {
                        if (
                            (t as User).Name.ToLower() == NameOrLogin.ToLower() ||
                            (t as User).Login.ToLower() == NameOrLogin.ToLower())
                        { u = t; }
                    }
                }

                return u;
            }
        }

        public UsersLists()
        {
            usersList = new();
        }

        public static void AddToList(T user)
        {
            usersList.Add(user);
        }

        public static void RemoveFromList(T user)
        {
            usersList.Remove(user);
        }
    }
}