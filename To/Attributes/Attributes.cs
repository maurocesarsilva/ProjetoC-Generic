using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To.Attributes
{
    /// <summary>
    /// CustomValidationAttribute para marcar se uma coluna deve possuir somatório
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SomaAttribute : ValidationAttribute
    {
        public SomaAttribute() { }

        /// <summary>
        /// Método de validação customizado, apenas para marcar se uma coluna dos relatórios deve apresentar somatório no final
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>Sempre retorna true</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MediaAttribute : ValidationAttribute
    {
        public MediaAttribute() { }

        /// <summary>
        /// Método de validação customizado, apenas para marcar se uma coluna dos relatórios deve apresentar somatório no final
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>Sempre retorna true</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}
