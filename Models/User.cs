using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }
}