namespace CadreForge.Models
{
    public class ListUnitModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ListUnitId { get; set; }


        public int StatusId { get; set; }

        public ListUnit ListUnit { get; set; } = null!;

        public ModelStatus Status { get; set; } = null!;
    }
}
