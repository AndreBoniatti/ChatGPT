namespace PPI.Models.Dtos;

public class PaginationDto<T> where T : class
{
    public List<T>? Data { get; set; }
    public int Count { get; set; }
}