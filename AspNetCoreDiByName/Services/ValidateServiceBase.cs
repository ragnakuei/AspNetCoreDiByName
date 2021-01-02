using System.Collections.Generic;

namespace AspNetCoreDiByName.Services
{
    public abstract class ValidateServiceBase
    {
        protected Dictionary<string, IList<string>> ModelState = new Dictionary<string, IList<string>>();

        protected void AddModelState(string propetyName, string errorMessage)
        {
            var errorMessages = ModelState.GetValueOrDefault(propetyName);

            if (errorMessages == null)
            {
                errorMessages = new List<string>
                                {
                                    errorMessage
                                };
                ModelState.Add(propetyName, errorMessages);
            }
            else
            {
                errorMessages.Add(errorMessage);
            }
        }
    }
}