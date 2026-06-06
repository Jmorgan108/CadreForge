using CadreForge.Enums;

namespace CadreForge.Models
{
    public class PaintNote
    {
        public int Id { get; set; }

        public PaintScope Scope { get; set; }

        public int? ListUnitId { get; set; }

        public int? ListUnitModelId { get; set; }

        public string PartName { get; set; } = string.Empty;

        public string PaintText { get; set; } = string.Empty;
    }
}
