namespace brewery.Models.Dto; 

public class BeerCreateDto {
    
    public string BeerName { get; set; }
    
    public string BeerStyle { get; set; }

    public string Upc { get; set; }

    public decimal Price { get; set; }
}