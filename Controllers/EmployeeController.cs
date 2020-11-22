
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeData;
using RestApiCRUD.Models;
using System;

namespace RestApiCRUD.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;    //인터페이스를 불러온다.
        
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        //직원 목록 전체 가져오기
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }
         
        //직원 상세보기
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);   // 해당 Guid를 가진 직원 상세정보를 불러운다.
            if (employee != null)                           // 위에서 찾은 Guid가 있을경우 해당 직원정보를 리턴한다.
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id : {id} was not Found");  // 없을경우 찾지못했다는 메세지 표시
            
        }

        //직원정보 등록
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);        //  직원정보를 추가한다.
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,employee); //

        }

        //직원정보 삭제
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();

            }
            return NotFound($"Employee with Id : {id} was not Found");

        }

        //직원 정보 수정
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if(existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
                
            }
            return Ok(employee);

        }


    }
}
