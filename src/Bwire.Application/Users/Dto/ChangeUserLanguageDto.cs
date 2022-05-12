using System.ComponentModel.DataAnnotations;

namespace Bwire.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}