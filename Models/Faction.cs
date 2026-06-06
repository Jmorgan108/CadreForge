namespace CadreForge.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        public int? AlignmentId { get; set; }
        public Alignment? Alignment { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
    }
}
