using System.ComponentModel.DataAnnotations.Schema;

[Table("torres")]
public class Torre
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Localizacao { get; set; }
}
