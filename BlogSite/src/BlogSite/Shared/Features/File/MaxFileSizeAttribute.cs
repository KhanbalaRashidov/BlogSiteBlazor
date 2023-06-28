using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Shared.Features.File
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly double _maxFileSize;
        public MaxFileSizeAttribute(double maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {_maxFileSize} bytes.";
        }
    }
}
