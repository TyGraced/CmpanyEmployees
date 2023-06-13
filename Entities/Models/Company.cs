using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company Address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Address { get; set; }

        public string? Country { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }

    #region 
    public enum BookGenre
    {
        Science,
        Art,
        Commercial
    }

    public class Book : IValidatableObject
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Range(10, int.MaxValue)]
        public int Price { get; set; }

        //[ScienceBook(BookGenre.Science)]
        public string? Genre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errorMessage = $"The genre of the book must be {BookGenre.Science}";
            if (!Genre.Equals(BookGenre.Science.ToString()))
                yield return new ValidationResult(errorMessage, new[]
                {
                    nameof(Genre)
                });
        }
    }

    public class ScienceBookAttribute : ValidationAttribute
    {
        public BookGenre Genre { get; set; }
        public string Error => $"The genre of the book must be {BookGenre.Science}";

        public ScienceBookAttribute(BookGenre genre)
        {
            Genre = genre;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;

            if (!book.Genre.Equals(Genre.ToString()))
                return new ValidationResult(Error);

            return ValidationResult.Success;
        }
    }
    #endregion
}
