using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Messages.Exceptions
{
    public static class ExceptionMessages
    {
        public static string EmailAlreadyRegistered =>
            "This email already registered";
        public static string EmailOrPasswordInCorrect =>
            "Email or Password is incorrect";
        public static string ClaimsNotFound =>
         "Claims not found.";
        public static string Forbidden403 =>
         "You are not authorized";
    }
}
