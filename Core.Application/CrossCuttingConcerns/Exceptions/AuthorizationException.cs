using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Reflection;
using System.Text.Json;

namespace Core.Application.CrossCuttingConcerns.Exceptions
{
    public class AuthorizationException:Exception
    {
        public AuthorizationException(string message):base(message)
        {
        }
    }
}

