using BloodDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BloodDB.Services
{
    public class DonorService:IDonorService
    {

        private readonly BloodDbContext bloodBankContext;

        public DonorService(BloodDbContext bloodBankContext)
        {
            this.bloodBankContext = bloodBankContext;
        }

        public async Task<IEnumerable<Donor>> GetDonors()
        {
            return await bloodBankContext.Donors.ToListAsync();
        }

        public async Task<Donor> GetDonorById(int Donorid)
        {
            return await bloodBankContext.Donors.FirstOrDefaultAsync(d => d.Donorid == Donorid);
        }

        public async Task<Donor> AddDonor(Donor donor) 
        {
            var result = await bloodBankContext.Donors.AddAsync(donor);
            await bloodBankContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Donor> UpdateDonor (Donor donor)
        {
            var result = await bloodBankContext.Donors
                .FirstOrDefaultAsync(e => e.Donorid == donor.Donorid);

            if (result != null)
            {
                result.Firstname = donor.Firstname;
                result.Phone = donor.Phone;
                result.Email = donor.Email;
                result.Gender = donor.Gender;
                result.Lastname = donor.Lastname;
                result.Address = donor.Address;
                result.BloodGroup = donor. BloodGroup;
                


                await bloodBankContext.SaveChangesAsync();

                return result;
            }

            return null;
        }



        public async Task<Donor> DeleteDonore(int Donorid)
        {
            var result = await bloodBankContext.Donors
                .FirstOrDefaultAsync(e => e.Donorid == Donorid);
            if (result != null)
            {
                bloodBankContext.Donors.Remove(result);
                await bloodBankContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
