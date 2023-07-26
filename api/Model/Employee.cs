namespace BloodDB.Model
{
    public class Employee
    {

        public int Empid { get; set; }

        public string Empname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Fullname { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Donor> Donors { get; set; } = new List<Donor>();
    }
}
