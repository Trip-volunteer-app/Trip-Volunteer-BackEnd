using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public List<Testimonial> GetAllTestimonies()
        {
            return _testimonialRepository.GetAllTestimonies();
        }
        public List<TestimonialDTO> GetAcceptedTestimonies()
        {
            return _testimonialRepository.GetAcceptedTestimonies();
        }
        public Testimonial GetTestimonyById(int id)
        {
            return _testimonialRepository.GetTestimonyById(id);
        }
        public void CreateTestimony(Testimonial testimonial)
        {
            _testimonialRepository.CreateTestimony(testimonial);
        }
        public void UpdateTestimony(Testimonial testimonial)
        {
            _testimonialRepository.UpdateTestimony(testimonial);
        }
        public void DeleteTestimony(int id)
        {
            _testimonialRepository.DeleteTestimony(id);
        }


        public async Task<Dictionary<string, int>> GetStatusDistributionAsync()
        {
            var testimonials = _testimonialRepository.GetAllTestimonies();

            // Count the number of testimonials by status
            var statusDistribution = testimonials
                .GroupBy(t => t.Status)
                .ToDictionary(g => g.Key ?? "Unknown", g => g.Count());

            return statusDistribution;
        }
        public List<TestimonyCountDTO> GetTestimonyStatusCounts()
        {
            return _testimonialRepository.GetTestimonyStatusCounts();
        }
    }
}
