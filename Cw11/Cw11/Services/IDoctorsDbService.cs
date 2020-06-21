using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;

namespace Cw11.Services
{
   public interface IDoctorsDbService
    {
        public Doctor GetDoctor(int idDoctor);
        public void InsertExamples();
        public void AddDoctor(string firstName, string lastName, string email);
        public void RemoveDoctor(int idDoctor);
        public void UpdateDoctor(int idDoctor, string lastName);
        public IEnumerable<Doctor> GetDoctors();
    }
}
