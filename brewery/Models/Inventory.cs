using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace brewery.Models; 

public class Inventory {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public int Version { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime LastModifiedDate { get; set; }
    
    public Guid BeerId { get; set; }

    public int QuantityOnHand { get; set; }
}