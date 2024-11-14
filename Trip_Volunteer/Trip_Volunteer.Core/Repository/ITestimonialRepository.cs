using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITestimonialRepository
    {
        List<Testimonial> GetAllTestimonies();
        Testimonial GetTestimonyById(int id);
        void CreateTestimony(Testimonial testimonial);
        void UpdateTestimony(Testimonial testimonial);
        void DeleteTestimony(int id);
        List<TestimonialDTO> GetAcceptedTestimonies();
        List<TestimonyCountDTO> GetTestimonyStatusCounts();

    }
}
