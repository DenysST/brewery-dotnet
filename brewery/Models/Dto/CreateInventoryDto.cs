namespace brewery.Models.Dto; 

public class CreateInventoryDto {
    public Guid Id { get; set; }
    public Guid BeerId { get; set; }

    public int QuantityOnHand { get; set; }
}