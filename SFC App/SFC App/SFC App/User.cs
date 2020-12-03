using System;
using System.Collections.Generic;
using System.Text;

namespace SFC_App
{
    class User
    {
        private int id;
        public int totalCO2;
        public string username;
        public string email;
        private string password;


        // Makes it possible to change the username, returns false if name change failed. 
        public bool ChangeUsername(string newUsername, string newUsernameConfirm, string userPassword)
        {
            if (userPassword == password)
            {
                if (newUsername == newUsernameConfirm)
                {
                    this.username = newUsername;
                    return true;
                }
                return false;
            }
            return false;
        }


        // Makes it possible to change the password, returns false if password change failed. 
        public bool ChangePassword(string oldPassword, string newPassword, string newPasswordConfirm)
        {
            if (oldPassword == this.password)
            {
                if (newPassword == newPasswordConfirm)
                {
                    this.password = newPassword;
                    return true;
                }
                return false;
            }
            return false;
        }


        // Change user email, only succeeds for correct password and new email (not the same one again).
        public bool ChangeEmail(string userPassword, string newEmail)
        {
            if(userPassword == this.password)
            {
                if(newEmail != this.email)
                {
                    this.email = newEmail;
                }
                return false;
            }
            return false;
        }
    }
}
