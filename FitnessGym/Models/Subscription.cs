#nullable enable

namespace FitnessGym.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Discription { get; set; }
        public double Fees { get; set; }
        public List<User> ? Trainees { get; set; }
    }
}
