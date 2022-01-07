#nullable enable
namespace FitnessGym.Models
{
    public class Programs
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string ? Discription { get; set; }
        public List<User> ?Trainees { get; set; }
    }
}
