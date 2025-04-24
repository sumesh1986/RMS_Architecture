using Admin_Lte.Models;
using Microsoft.AspNetCore.Mvc;
using RMS_Models.Models;

namespace RMS_Layout.Controllers
{
    public class DepartmentController : Controller
    {
        private static List<Department> _departments = new()
        {
            new Department
            {
                Id = 1,
                Name = "International Office",
                Owner = 2,
                SysId = 30,
                Status = "Active"
            },
            new Department
            {
                Id = 2,
                Name = "PLANNER",
                Owner = 1,
                SysId = 10,
                Status = "Active"
            },
            new Department
            {
                Id = 3,
                Name = "Field Manager",
                Owner = 1,
                SysId = 11,
                Status = "Active"
            },
            new Department
            {
                Id = 4,
                Name = "Full Field Staff",
                Owner = 12,
                SysId = 12,
                Status = "Active"
            },
            new Department
            {
                Id = 5,
                Name = "Security Staff",
                Owner = 5,
                SysId = 8,
                Status = "Active"
            }
        };

        public IActionResult Index()
        {
            ViewBag.Department = new Department { Status = "Active" };
            return View(_departments);
        }

        [HttpPost]
        public IActionResult SaveDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDept = _departments.FirstOrDefault(d => d.Id == department.Id);
            if (existingDept != null)
            {
                // Update existing department
                existingDept.Name = department.Name;
                existingDept.Owner = department.Owner;
                existingDept.SysId = department.SysId;
                existingDept.Status = department.Status;
                return Json(new { success = true, message = "Department updated successfully", department = existingDept });
            }

            // Add new department
            department.Id = _departments.Any() ? _departments.Max(d => d.Id) + 1 : 1;
            _departments.Add(department);
            return Json(new { success = true, message = "Department created successfully", department = department });
        }

        [HttpPost]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _departments.Remove(department);
                return Json(new { success = true, message = "Department deleted successfully" });
            }
            return NotFound(new { success = false, message = "Department not found" });
        }

        [HttpGet]
        public IActionResult GetDepartment(int id)
        {
            var department = _departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                return Json(department);
            }
            return NotFound(new { success = false, message = "Department not found" });
        }


        //user

        private static List<UserRole> _userRoles = new()
    {
        new UserRole { Id = 1, Name = "Admin", Status = "Active" },
        new UserRole { Id = 2, Name = "Manager", Status = "Active" },
        new UserRole { Id = 3, Name = "Supervisor", Status = "Inactive" },
        new UserRole { Id = 4, Name = "Staff", Status = "Active" },
        new UserRole { Id = 5, Name = "Guest", Status = "Inactive" }
    };

        public IActionResult UserRole()
        {
            return View();
        }
    }
}
