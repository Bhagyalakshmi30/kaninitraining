namespace BloodDB.Model;

public class Donor
{

    public int Donorid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string BloodGroup { get; set; } = null!;

    public int? Empassit { get; set; }

    public virtual Employee? EmpassitNavigation { get; set; }
}
