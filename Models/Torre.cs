using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("torres")]
public class Tower
{
    [Key]

    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Localizacao { get; set; }

    [Required]
    public DateTime Ultimamanutencao? { get; set; }
}