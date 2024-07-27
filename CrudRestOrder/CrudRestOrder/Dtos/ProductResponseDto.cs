namespace CrudRestOrder.Dtos
{
    public class ProductResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ProductDto Data { get; set; }
    }
}
