using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StdntCollege.Models;
using StdntCollege.MyLogging;

namespace StdntCollege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("All", Name = "GetStudents")]
        //memory repository To get all students
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            //var students = new List<StudentDTO>();
            //foreach (var item in CollegeRepository.students)
            //{
            //    StudentDTO obj = new StudentDTO()
            //    {

            //        Id = item.Id,
            //        StudentName = item.StudentName,
            //        Address = item.Address,
            //        StudentEmail = item.StudentEmail
            //    };
            //    students.Add(obj);
            //}

            //Using LINQ To convert students list to studentdto list create DTO

            _logger.LogInformation("GetStudents Method start executed");
            var studens = CollegeRepository.students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Address = s.Address,
                StudentEmail = s.StudentEmail,
            });

            //memory repository for all students
            //Ok-200 Succes
            return Ok(CollegeRepository.students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //memory repository for single student by id
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            //BadRequest-400 Succes Client error
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            //_logger.LogInformation("GetStudent Method started");
            var student = CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();
            //BadRequest-404 NotFound
            if (student == null)
            {
                _logger.LogError($"Student with this Id {id} not found");
                return NotFound($"The student with Id {id} not found");
            }
            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                StudentEmail = student.StudentEmail,
            };
            //memory repository for all students
            return Ok(studentDTO);
        }
        [HttpGet("{name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            //BadRequest-400 Succes Client error
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var student = CollegeRepository.students.Where(n => n.StudentName == name).FirstOrDefault();
            //BadRequest-404 NotFound
            if (student == null)
                return NotFound($"the student with name {name} not found");

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                StudentEmail = student.StudentEmail,
            };
            //memory repository to get student by name.
            return Ok(studentDTO);
        }

        [HttpPost]
        [Route("Create")]
        //api/student/create

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {
            //if (!ModelState.IsValid)
            //  return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            //if (model.AdmissionDate < DateTime.Now)
            //{
            //    //1 way is Directly adding error message to modelstate
            //    //2 way is using cutom attribute
            //    ModelState.AddModelError("AddmissionDate Error", "Admission date must be greater than or equal to today's date");
            //    return BadRequest(ModelState);
            //}
            int newId = CollegeRepository.students.LastOrDefault().Id + 1;
            Student Student = new Student
            {
                Id = newId,
                StudentName = model.StudentName,
                Address = model.Address,
                StudentEmail = model.StudentEmail,
            };
            CollegeRepository.students.Add(Student);
            model.Id = Student.Id;
            //Status --201
            //https://localhost:7169/api/student/3

            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);


        }

        [HttpPut]
        [Route("Update")] 
        //api/student/Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateStudent([FromBody] StudentDTO model)
        {
            if (model == null | model.Id <= 0)
                BadRequest();
            var existingStudent = CollegeRepository.students.Where(s => s.Id == model.Id).FirstOrDefault();

            if(existingStudent == null)
                return NotFound();
            existingStudent.StudentName= model.StudentName;
            existingStudent.StudentEmail= model.StudentEmail;
            existingStudent.Address= model.Address;
            // return Ok(existingStudent);
            return NoContent();

        }

        [HttpPatch]
        [Route("{id:int}UpdatePartial")]
        //api/student/Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
                BadRequest();
            var existingStudent = CollegeRepository.students.Where(s => s.Id ==id).FirstOrDefault();

            if (existingStudent == null)
                return NotFound();

            var studentDTO = new StudentDTO
            {
                Id = existingStudent.Id,
                StudentName = existingStudent.StudentName,
                StudentEmail = existingStudent.StudentEmail,
                Address = existingStudent.Address,
            };

            patchDocument.ApplyTo(studentDTO, ModelState);
            if (ModelState.IsValid)
                return BadRequest(ModelState);    
            
            existingStudent.StudentName =  studentDTO.StudentName;
            existingStudent.StudentEmail = studentDTO.StudentEmail;
            existingStudent.Address = studentDTO.Address;
            // return Ok(existingStudent);

            //204 NoContent
            return NoContent();

        }


        [HttpDelete("{id}", Name = "DeletStudentsById")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeletStudent(int id)
        {
            //BadRequest-400 Succes Client error
            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();
            //BadRequest-404 NotFound
            if (student == null)
                return NotFound($"the student with id {id} not found");
            //memory repository to delete delete single student
            
            CollegeRepository.students.Remove(student);
            return Ok(true);
        }
        
    }
}
