using System.ComponentModel.DataAnnotations;

namespace ShalomeTestProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}