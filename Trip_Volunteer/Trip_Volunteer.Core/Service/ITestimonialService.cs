using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface ITestimonialService
    {
        List<Testimonial> GetAllTestimonies();
        Testimonial GetTestimonyById(int id);
        void CreateTestimony(Testimonial testimonial);
        void UpdateTestimony(Testimonial testimonial);
        void DeleteTestimony(int id);
        Task<Dictionary<string, int>> GetStatusDistributionAsync();
    }
}
