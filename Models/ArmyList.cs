using System.Collections.Generic;

namespace CadreForge.Models
{
    public class ArmyList
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int ArmyId { get; set; }

        public Army Army { get; set; } = null!;

        public ICollection<ListUnit> Units { get; set; }
            = new List<ListUnit>();
    }
}
