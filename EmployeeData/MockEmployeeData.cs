

using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()     //직원정보를 임의로 생성
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One",
                Position = "new recruit",
                Age = 20,
                Introduce = "Hi I m One"

            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two",
                Position = "manager",
                Age = 25,
                Introduce = "Hi I m Two"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();   //Guid를 만들어 employee의 Id에 저장
            employees.Add(employee);        //추가
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);     //해당 직원 목록 삭제
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);    // 해당 Id를 가진 직원정보를 가져온다.
            existingEmployee.Name = employee.Name;              // 위에서 찾은 해당 Id의 직원 이름을 바꾼다.
            existingEmployee.Position = employee.Position;
            existingEmployee.Age = employee.Age;
            existingEmployee.Introduce = employee.Introduce;
            return existingEmployee;                            
        }
        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);  //해당 Id를 가진 직원리스트중 하나의 정보만을 가지고온다.
        }

        public List<Employee> GetEmployees()
        {
            return employees;           //모든 직원정보 리스트를 가지고온다.
        }


    }
}
