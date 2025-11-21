using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("torres")]
public class Tower
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Localizacao { get; set; } = string.Empty;

    [Column("Ultimamanutencao")]
    public DateTime UltimaManutencao { get; set; }

    public string Status { get; set; } = string.Empty;

    public string HorarioPico { get; set; } = string.Empty;
}
