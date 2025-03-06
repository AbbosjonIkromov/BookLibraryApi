namespace BookHub.WebApi.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }

        DateTime? UpdatedTime { get; set; }
    }
}
