using System.Collections.Generic;
using AspNetCoreDiByName.Models;

namespace AspNetCoreDiByName.Services
{
    public class ValidateServiceDtoA : IValidateService
    {
        public Dictionary<string, IList<string>> Validate(object model)
        {
            var result = new Dictionary<string, IList<string>>();

            if (model is not DtoA dto)
            {
                return result;
            }

            ValidateName(result, dto);

            return result;
        }

        private static void ValidateName(Dictionary<string, IList<string>> result, DtoA dto)
        {
            var nameErrorMessages = new List<string>();
            result.Add(nameof(DtoA.Name), nameErrorMessages);

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                nameErrorMessages.Add("名稱不可以為空");
                return;
            }

            if (dto.Name.Length < 2)
            {
                nameErrorMessages.Add("名稱長度要大於等於 2 個字");
            }
        }
    }
}