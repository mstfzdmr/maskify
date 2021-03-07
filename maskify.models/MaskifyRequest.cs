using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace maskify.models
{
    public class MaskifyRequest : IValidatableObject
    {
        public string ReplacedJsonKeyValues { get; set; }
        public string Replacement { get; set; }
        public object Model { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ReplacedJsonKeyValues))
            {
                yield return new ValidationResult("ReplacedJsonKeyValues cannot be empty");
            }

            if (Model == null)
            {
                yield return new ValidationResult("Model cannot be empty");
            }
        }
    }
}
