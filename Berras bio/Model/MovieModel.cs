using System.ComponentModel.DataAnnotations;

namespace Berras_bio.Model
{
    public class MovieModel
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public float Seats { get; set; }
    }
}
