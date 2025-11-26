namespace Eksamensplaner.Core.Models
{
    public class Eksamen
    {
        public int Id { get; set; }
        public string Uddannelse { get; set; }
        public string Aktivitet { get; set; }
        public int Semester { get; set; }
        public string Type { get; set; }
    }
}