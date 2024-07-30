
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Business.Results
{
    public class Manager : IManager
    {
        public ObjectResult Result(object value)
        {
            return new ObjectResult(value)
            {
                StatusCode = value == null
                           ? StatusCodes.Status500InternalServerError
                           : StatusCodes.Status200OK,
            };
        }
    }



}
