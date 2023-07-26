using BloodDB.Model;

namespace BloodDB.Services
{
    public interface IDonorService
    {
        Task<IEnumerable<Donor>> GetDonors();

        Task<Donor> GetDonorById(int id);
        Task<Donor> AddDonor(Donor donor);
        Task<Donor> UpdateDonor(Donor donor);
        //sk<Donor> DeleteDonor(int employeeId);
    }
}
