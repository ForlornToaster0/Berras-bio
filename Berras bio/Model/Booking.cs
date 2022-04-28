namespace Berras_bio.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Tickets { get; set; }
        public DateTime DateTime { get; set; }
    }
}
