namespace SEIntern.Models{
public class Order{
    public string? ProductID { get; set; }
    public string? SalesOrder { get; set; }
    public string? SalesOrderItem { get; set; }
    public string WorkOrder { get; set; }
    public string? ProductDescription { get; set; }
    public string? OrderStatus { get; set; }
    public decimal? OrderQuantity { get; set; }
    public DateTime? Timestamp { get; set; }
}
}