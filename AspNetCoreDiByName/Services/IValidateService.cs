using System.Collections.Generic;

namespace AspNetCoreDiByName.Services
{
    public interface IValidateService
    {
        Dictionary<string, IList<string>> Validate(object model);
    }
}
