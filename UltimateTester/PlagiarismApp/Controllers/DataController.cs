using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlagiarismApp.Data.Database;
using PlagiarismApp.Pages.Menu;
using System.Net;

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
        public async Task<ActionResult<IEnumerable<object>>> GetProjects()
        {
            return await _database
                .Projects
                .AsNoTracking()
                .Include(p => p.ProjectType)
                .Include(p => p.Student)
                .Select(project => new
                {
                    project.Name,
                    project.Id,
                    project.OriginalityPercentage,
                    project.DateOfPassing,
                    ProjectType = new
                    {
                        project.ProjectType.Name,
                        project.ProjectType.Description
                    },
                    Student = new
                    {
                        project.Student.FirstName,
                        project.Student.Surname,
                        project.Student.Patronymic,
                    }
                }).ToArrayAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project?>> GetProject([FromRoute] int id)
        {
            return await _database.Projects.Include(p => p.ProjectType)
                                           .Include(p => p.Student)
                                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromBody] Project project)
        {
            try
            {
                if (!ModelState.IsValid || project == null)
                {
                    return NotFound($"Project cannot be null.");
                }
                _database.Entry(project).State = EntityState.Added;
                await _database.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Project>> PutProject([FromBody] Project project)
        {
            try
            {
                if (ModelState.IsValid && project != null)
                {
                    _database.Attach(project);
                    _database.Entry(project).State = EntityState.Modified;
                    await _database.SaveChangesAsync();
                    return project;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Project>> DeleteProject([FromRoute] int id)
        {
            try
            {
                var projectToRemove = await _database.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (projectToRemove == null)
                {
                    return NotFound($"Project with Id = {id} not found.");
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
            return await _database.Students.Include(s => s.Group).AsNoTracking()
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

        #region Project types
        [HttpGet]
        public async Task<ActionResult<List<ProjectType>>> GetProjectTypes()
        {
            return await _database.ProjectTypes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectType?>> GetProjectType(int id)
        {
            return await _database.ProjectTypes.FirstOrDefaultAsync(lw => lw.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectType>> PostProjectType(ProjectType projectType)
        {
            try
            {
                if (projectType == null)
                {
                    return NotFound($"Project type cannot be null.");
                }
                _database.ProjectTypes.Add(projectType);
                await _database.SaveChangesAsync();
                return projectType;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProjectType>> PutProjectType(ProjectType projectType)
        {
            try
            {
                if (projectType == null)
                {
                    return NotFound($"Project type cannot be null.");
                }
                _database.Attach(projectType);
                _database.Entry(projectType).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return projectType;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProjectType>> DeleteProjectType(int id)
        {
            try
            {
                var labWorkToRemove = await _database.ProjectTypes
                    .SingleOrDefaultAsync(lw => lw.Id == id);
                if (labWorkToRemove == null)
                {
                    return NotFound($"Project type with Id = {id} not found.");
                }
                _database.ProjectTypes.Remove(labWorkToRemove);
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
