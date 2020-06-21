using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Cw11.Services;

namespace Cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsDbService _context;

        public DoctorsController(IDoctorsDbService context)
        {
            _context = context;
        }

        //ZADANIE 2 - zwrocenie doktora
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }

        //ZADANIE 2 - zwrocenie doktora
        [HttpGet("{idDoctor}")]
        public IActionResult GetDoctor(int idDoctor)
        {
            return Ok(_context.GetDoctor(idDoctor));
        }

        //ZADANIE 2 - modyfikacja nazwiska doktora
        [HttpPut("{idDoctor}")]
        public IActionResult UpdateDoctor(int idDoctor, string lastName)
        {
            _context.UpdateDoctor(idDoctor, lastName);
            return Ok("Zaktualizowano nazwisko");
        }

        //ZADANIE 2 - usuniecie doktora
        [HttpDelete("{idDoctor}")]
        public IActionResult RemoveDoctor(int idDoctor)
        {

            _context.RemoveDoctor(idDoctor);

            return Ok("Usuwanie zakonczono");
        }

        //ZADANIE 1 - dodanie wstępnych wartości do bazy
        [HttpPost]
        public IActionResult InsertExamples()
        {

            _context.InsertExamples();

            return Ok("Wstawiono pierwsze dane do bazy");
        }


        //ZADANIE 2 - dodanie doktora
        [HttpPost("{idDoctor}")]
        public IActionResult AddDoctor(string firstName, string lastName, string email)
        {

            _context.AddDoctor(firstName, lastName, email);

            return Ok("Dodano doktora do bazy");
        }
    }
}
