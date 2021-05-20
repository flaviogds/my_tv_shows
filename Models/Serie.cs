using my_tv_shows.Enum;

namespace my_tv_shows.Models
{
    public class Serie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gener Gener { get; set; }

        public string Description { get; set; }
    }
}
