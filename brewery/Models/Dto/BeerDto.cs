namespace brewery.Models.Dto; 

public class BeerDto {
    public Guid Id { get; set; }
    
    public int Version { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime LastModifiedDate { get; set; }
    
    public string BeerName { get; set; }
    
    public string BeerStyle { get; set; }

    public string Upc { get; set; }

    public decimal Price { get; set; }

    public int QuantityOnHand { get; set; }
}