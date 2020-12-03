using System;
using System.Collections.Generic;
using System.Text;

namespace SFC_App
{
    class UserList
    {
        private List<User> allUsers = new List<User>() { };   //Empty when object is created
        public List<User> AllUsers
        {
            get { return allUsers; }
        }


        private int userCount 
        {
            get { return allUsers.Count; }
        } 


        // Add a single user to the list, if this fails return false.
        public bool AddUser(User newUser)
        {
            try
            {
                allUsers.Add(newUser);
                return true;
            }

            catch
            {
                return false;
            }
            
        }

        
        public int GetUserIndex(User wantedUser)
        {            
            int userIndex = allUsers.IndexOf(wantedUser);   // Returns -1 if index was not found.
            return userIndex;
        }

        
        public bool RemoveUser(User toRemUser)
        {
            try
            {
                int userIndex = this.GetUserIndex(toRemUser);
                allUsers.RemoveAt(userIndex);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool AddUserList(List<User> listOfUsers)
        {
            try
            {
                allUsers.AddRange(listOfUsers);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
