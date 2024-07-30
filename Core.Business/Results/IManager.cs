using Microsoft.AspNetCore.Mvc;

namespace Core.Business.Results
{
    public interface IManager
    {
        ObjectResult Result(object value);
    }
}