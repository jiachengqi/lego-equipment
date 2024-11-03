using System.ComponentModel.DataAnnotations;

namespace shared
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EquipmentState CurrentState { get; set; }
    }

    public enum EquipmentState
    {
        Red,
        Yellow,
        Green
    }
}

