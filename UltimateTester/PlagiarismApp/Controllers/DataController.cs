using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlagiarismApp.Data.Database;
using PlagiarismApp.Pages.Catalogs.Students;

namespace PlagiarismApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly IdentityDataContext _database;

        public DataController(IdentityDataContext database)
        {
            _database = database;
        }

        #region Projects
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            return await _database.Projects.Include(p => p.LabWork)
                                           .Include(p => p.Student)
                                           .ToListAsync();
        }

        [HttpGet("{studentId:int}/{labWorkId:int}")]
        public async Task<ActionResult<Project?>> GetProject(int studentId, 
                                                             int labWorkId)
        {
            return await _database.Projects.Include(p => p.LabWork)
                                           .Include(p => p.Student)
                                           .FirstOrDefaultAsync(p => p.StudentId == studentId
                                                                     && p.LabWorkId == labWorkId);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return NotFound($"Project cannot be null.");
                }
                _database.Entry(project).State = EntityState.Added;
                await _database.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut] // TODO: putprojects does not work
        public async Task<ActionResult<Project>> PutProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return NotFound($"Project cannot be null.");
                }
                _database.Attach(project);
                _database.Entry(project).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{studentId:int}/{labWorkId:int}")]
        public async Task<ActionResult<Project>> DeleteProject(int studentId, int labWorkId)
        {
            try
            {
                var projectToRemove = await _database.Projects
                    .SingleOrDefaultAsync(p => p.StudentId == studentId
                                               && p.LabWorkId == labWorkId);
                if (projectToRemove == null)
                {
                    return NotFound($"Project with LabWorkId = {studentId}," +
                        $" StudentId = {labWorkId} not found.");
                }
                _database.Projects.Remove(projectToRemove);
                await _database.SaveChangesAsync();
                return projectToRemove;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        #endregion

        #region Groups
        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            return await _database.Groups.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Group?>> GetGroup(int id)
        {
            return await _database.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            try
            {
                if (group == null)
                {
                    return NotFound($"Group cannot be null.");
                }
                _database.Groups.Add(group);
                await _database.SaveChangesAsync();
                return group;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Group>> PutGroup(Group group)
        {
            try
            {
                if (group == null)
                {
                    return NotFound($"Group cannot be null.");
                }
                _database.Attach(group);
                _database.Entry(group).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return group;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Group>> DeleteGroup(int id)
        {
            try
            {
                var groupToRemove = await _database.Groups.SingleOrDefaultAsync(g => g.Id == id);
                if (groupToRemove == null)
                {
                    return NotFound($"Group with Id = {id} not found.");
                }
                _database.Groups.Remove(groupToRemove);
                await _database.SaveChangesAsync();
                return groupToRemove;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        #endregion

        #region Students
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _database.Students.Include(s => s.Group)
                                           .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student?>> GetStudent(int id)
        {
            return await _database.Students.Include(s => s.Group)
                                           .FirstOrDefaultAsync(s => s.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return NotFound($"Student cannot be null.");
                }
                _database.Entry(student).State = EntityState.Added;
                await _database.SaveChangesAsync();
                return student;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Student>> PutStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return NotFound($"Student cannot be null.");
                }
                _database.Attach(student);
                _database.Entry(student).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return student;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var studentToRemove = await _database.Students.SingleOrDefaultAsync(s => s.Id == id);
                if (studentToRemove == null)
                {
                    return NotFound($"Student with Id = {id} not found.");
                }
                _database.Students.Remove(studentToRemove);
                await _database.SaveChangesAsync();
                return studentToRemove;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        #endregion

        #region LabWorks
        [HttpGet]
        public async Task<ActionResult<List<LabWork>>> GetLabWorks()
        {
            return await _database.LabWorks.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LabWork?>> GetLabWork(int id)
        {
            return await _database.LabWorks.FirstOrDefaultAsync(lw => lw.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<LabWork>> PostLabWork(LabWork labWork)
        {
            try
            {
                if (labWork == null)
                {
                    return NotFound($"Lab work cannot be null.");
                }
                _database.LabWorks.Add(labWork);
                await _database.SaveChangesAsync();
                return labWork;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<LabWork>> PutLabWork(LabWork labWork)
        {
            try
            {
                if (labWork == null)
                {
                    return NotFound($"Lab work cannot be null.");
                }
                _database.Attach(labWork);
                _database.Entry(labWork).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return labWork;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LabWork>> DeleteLabWork(int id)
        {
            try
            {
                var labWorkToRemove = await _database.LabWorks
                    .SingleOrDefaultAsync(lw => lw.Id == id);
                if (labWorkToRemove == null)
                {
                    return NotFound($"Lab work with Id = {id} not found.");
                }
                _database.LabWorks.Remove(labWorkToRemove);
                await _database.SaveChangesAsync();
                return labWorkToRemove;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        #endregion
    }
}
