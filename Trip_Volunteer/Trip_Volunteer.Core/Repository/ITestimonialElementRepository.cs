using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITestimonialElementRepository
    {
        List<TestimonialElement> GetAllTestimonialElements();
        TestimonialElement GetTestimonialElementById(int id);
        void CreateTestimonialElement(TestimonialElement testimonialElement);
        void UpdateTestimonialElement(TestimonialElement testimonialElement);
        void DeleteTestimonialElement(int id);

    }
}
