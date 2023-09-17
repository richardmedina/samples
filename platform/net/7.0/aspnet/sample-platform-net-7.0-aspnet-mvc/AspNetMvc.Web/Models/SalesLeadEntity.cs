namespace AspNetMvc.Web.Models
{
    public class SalesLeadEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Source { get; set; } = null!;
    }
}
