﻿using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Client.Utils.File
{
    public class ClientMaxFileSizeAttribute : ValidationAttribute
    {
        private readonly double _maxFileSize;
        public ClientMaxFileSizeAttribute(double maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IBrowserFile;
            if (file != null)
            {
                if (file.Size > _maxFileSize)
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
