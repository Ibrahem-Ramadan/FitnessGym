using FitnessGym.Models;

namespace FitnessGym.ViewModels
{
    public class DashboardVM
    {
        public List<User> Trainees { get; set; }
        public List<Programs> Programs { get; set; }
        public List<Subscription> Subscriptions { get; set; }

    }
}
