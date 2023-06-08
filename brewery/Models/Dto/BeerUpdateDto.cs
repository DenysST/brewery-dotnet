namespace brewery.Models.Dto; 

public class BeerUpdateDto {
    public Guid Id { get; set; }

    public string BeerName { get; set; }
    
    public string BeerStyle { get; set; }

    public string Upc { get; set; }

    public decimal Price { get; set; }

    public int MinOnHand { get; set; }
    public int QuantityToBrew { get; set; }
}