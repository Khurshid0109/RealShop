
namespace RealShop.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime DeletedAt { get; set; } = DateTime.Now;
}

