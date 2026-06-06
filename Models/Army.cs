using CadreForge.Data;
using System.Collections.Generic;

namespace CadreForge.Models
{
    public class Army
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int GameId { get; set; }

        public int? FactionId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public Game Game { get; set; } = null!;

        public Faction? Faction { get; set; }

        public ICollection<ArmyList> Lists { get; set; }
            = new List<ArmyList>();
    }
}
