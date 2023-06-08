using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace brewery.Models;

public class Beer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public int Version { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime LastModifiedDate { get; set; }

    [Required] 
    public string BeerName { get; set; }

    [Required] 
    public string BeerStyle { get; set; }

    public string Upc { get; set; }

    public decimal Price { get; set; }

    public int MinOnHand { get; set; }
    public int QuantityToBrew { get; set; }
}