using System.ComponentModel.DataAnnotations;

namespace Faker.Solution.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}