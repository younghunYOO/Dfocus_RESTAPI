using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();                   // 새로운 Guid를 생성하여 Id에 저장
            _employeeContext.Employees.Add(employee);      //  EmployeeContext에 입력한 정보를 DB에 추가
            _employeeContext.SaveChanges();               //   DB를 저장하고 변환
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
             _employeeContext.Employees.Remove(employee);   //해당 직원정보를 DB에서 제거
            _employeeContext.SaveChanges();


        }

        public Employee EditEmployee(Employee employee)
        {
            var existEmployee = _employeeContext.Employees.Find(employee.Id);   // DB에서 해당 Id를 가진 직원정보를 DB에서 찾는다.
            if(existEmployee != null)                                           // 위에서 찾은 Id가 null이 아닐경우 해당 Guid를 가진 직원정보를 DB에서 수정한다.
            {
                existEmployee.Name = employee.Name;
                existEmployee.Position = employee.Position;
                existEmployee.Age = employee.Age;
                existEmployee.Introduce = employee.Introduce;
                _employeeContext.Employees.Update(existEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);             // 해당 Guid를 가진 직원정보를 DB에서 찾아서 가져온다.
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();                 // 모든 직원정보 리스트를 DB에서 가져온다.
        }
    }
}
