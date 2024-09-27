using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class TestimonialElementService: ITestimonialElementService
    {
        private readonly ITestimonialElementRepository _testimonialElementRepository;
        public TestimonialElementService(ITestimonialElementRepository testimonialElementRepository)
        {
            _testimonialElementRepository = testimonialElementRepository;
        }
        public List<TestimonialElement> GetAllTestimonialElements()
        {
           return _testimonialElementRepository.GetAllTestimonialElements();
        }
        public TestimonialElement GetTestimonialElementById(int id)
        {
            return _testimonialElementRepository.GetTestimonialElementById(id);
        }
        public void CreateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementRepository.CreateTestimonialElement(testimonialElement);
        }
        public void UpdateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementRepository.UpdateTestimonialElement(testimonialElement);
        }
        public void DeleteTestimonialElement(int id)
        {
            _testimonialElementRepository.DeleteTestimonialElement(id);
        }
    }
}
