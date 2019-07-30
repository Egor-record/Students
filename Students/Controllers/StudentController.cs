using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Persistence;
using Students.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Controllers
{
    [Route("api/")]
    public class StudentController : Controller
    {

        private readonly IRepository<Student> _studentRepository;

        private readonly IUnitOfWork _unitOfWork;


        public StudentController(IRepository<Student> studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }




        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int id) {

            var getResult = _studentRepository.Get(id);

            if (getResult == null)
            {
                return BadRequest($"Student not found");

            } else
            {
                return Ok(getResult);
            }
             
        }

        [HttpGet("getall")]
        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")] 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] Student value)
        {
            _studentRepository.Delete(value);
            
            _unitOfWork.SaveChanges();
        }

        [HttpPost("update/")]
        public IActionResult Update([FromBody] Student value)
        {

            if (string.IsNullOrWhiteSpace(value.FirstName))
            {
                return BadRequest("Name is empty");
            }

            var getResult = value.Id > 0 ? _studentRepository.Get(value.Id) : null;

            if (getResult == null) {
                _studentRepository.Create(value);
            } else
            {
                value = _studentRepository.Update(value);
            }

            _unitOfWork.SaveChanges();

            return Ok(value);


        }
    }
}
