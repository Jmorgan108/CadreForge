using System.Collections.Generic;

namespace CadreForge.Models
{
    public class ListUnit
    {
        public int Id { get; set; }

        public int ArmyListId { get; set; }

        public string UnitName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public bool AllowModelNames { get; set; }

        public ArmyList ArmyList { get; set; } = null!;

        public ICollection<ListUnitModel> Models { get; set; }
            = new List<ListUnitModel>();
    }
}
