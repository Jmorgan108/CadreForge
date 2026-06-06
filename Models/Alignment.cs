namespace CadreForge.Models
{
    public class Alignment
    {
        public int? Id { get; set; }

        public int GameId { get; set; }

        public string Name { get; set; } = string.Empty;

        public Game Game { get; set; } = null!;
    }
}
