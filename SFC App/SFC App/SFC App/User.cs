using System;
using System.Collections.Generic;
using System.Text;

namespace SFC_App
{
    public class User
    {

        public int id { get; }

        public int totalCO2 { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }


        public User(int Id, int TotalCO2, string Username, string Email, string Password)
        {
            id = Id;
            totalCO2 = TotalCO2;
            username = Username;
            email = Email;
            password = Password;
        }
        

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
