using System.Collections.Generic;
using AspNetCoreDiByName.Models;

namespace AspNetCoreDiByName.Services
{
    public class ValidateServiceDtoA : ValidateServiceBase, IValidateService
    {
        public Dictionary<string, IList<string>> Validate(object model)
        {
            if (model is DtoA dto)
            {
                ValidateName(dto.Name);
            }

            return ModelState;
        }

        private void ValidateName(string name)
        {
            var propertyName = nameof(DtoA.Name);

            if (string.IsNullOrWhiteSpace(name))
            {
                AddModelState(propertyName, "名稱不可以為空");
                return;
            }

            if (name.Length < 2)
            {
                AddModelState(propertyName, "名稱長度要大於等於 2 個字");
            }
        }
    }
}
