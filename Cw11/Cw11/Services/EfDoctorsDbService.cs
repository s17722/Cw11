using Cw11.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class EfDoctorsDbService : IDoctorsDbService
    {
        private readonly DoctorsDbContext _context;

        public EfDoctorsDbService(DoctorsDbContext context)
        {
            _context = context;
        }
        public void AddDoctor(string firstName, string lastName, string email)
        {

            var prescription = new Prescription()
            {
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 2,
            };

            var set = new HashSet<Prescription> { prescription };

            var doctor = new Doctor()
            {
                FirstName = "F",
                LastName = "F",
                Email = "hshs@gmail.com",
                Prescriptions = set
            };

            _context.Doctors.Add(doctor);

            _context.SaveChanges();
        } 

        public Doctor GetDoctor(int idDoctor)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.IdDoctor == idDoctor);
            return doctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public void InsertExamples()
        {

            var patientOne = new Patient()
            {
                FirstName = "Tomasz",
                LastName = "T",
                BirthDate = new DateTime(1990,12,31)
            };

            var patientTwo = new Patient()
            {
                FirstName = "Adam",
                LastName = "A",
                BirthDate = new DateTime(1990, 11, 20)
            };

            var prescription = new Prescription()
            {
                Date = DateTime.Now,
            DueDate = DateTime.Now,
            IdPatient = 2,
            };

            var set = new HashSet<Prescription> { prescription };

            var doctor = new Doctor()
            {
                FirstName = "Karol",
                LastName = "K",
                Email = "ssghf@gmail.com",
                Prescriptions = set
            };

            _context.Patients.Add(patientOne);
            _context.Patients.Add(patientTwo);

            _context.Doctors.Add(doctor);

            _context.SaveChanges();
        }

        public void RemoveDoctor(int idDoctor)
        {
                var doctor = _context.Doctors.SingleOrDefault(x => x.IdDoctor == idDoctor);

                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
        }

        public void UpdateDoctor(int idDoctor, string lastName)
        {
            var doctor = _context.Doctors.SingleOrDefault(x => x.IdDoctor == idDoctor);

            if (lastName != null)
                doctor.LastName = lastName;
                _context.SaveChanges();

        }
    }
}
