using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SucceededMessage = "Progress was completed properly!"; // field
        public static string FailedMessage = "Progress was NOT completed properly!";
        public static string CheckIfImageLimitRanOutOf = "You cannot add anymore new images. Limit has been reached!";
        public static string AuthorizationDenied = "You have not been authorizated!";
        public static string UserRegistered = "User has been registered succesfully!";
        public static string UserNotFound = "User is not found!";
        public static string PasswordError = "Password is incorrect!";
        public static string SuccessfulLogin = "Login has been emerged!";
        public static string UserAlreadyExists = "That user is already exist!";
        public static string AccessTokenCreated = "Access Token has been created successfully!";
    }
}
