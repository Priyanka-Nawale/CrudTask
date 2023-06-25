using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CrudOpeartion.Models
{
    public class EmploeedataAccess
    {
        private readonly string filePath;

        public EmploeedataAccess(string filePath)
        {
            this.filePath = filePath;
        }

        //To store data in text file
        private void SaveEmployees(List<Employee> employees)
        {
            List<string> lines = employees.Select(e => $"Employee Id:{e.Id},Employee Name:{e.Name},Department:{e.Department}").ToList();
            File.WriteAllLines(filePath, lines);
        }


        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string[] lines = File.ReadAllLines(filePath);

            foreach(string line in lines)
            {
                string[] data = line.Split(',');
                Employee employee = new Employee()
                {
                    Id =int.Parse(data[0].Split(':')[1]),
                    Name=data[1].Split(':')[1],
                    Department=data[2].Split(':')[1]
                };
                employees.Add(employee);
            }
            return employees;
        }

        public void Create(Employee employee)
        {
            List<Employee> employees = GetAllEmployees();

            //To generate new id for new employee
            int newid = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
            employee.Id = newid;

            employees.Add(employee);
            SaveEmployees(employees);
        }

        public void Update(Employee employee)
        {
            List<Employee> employees = GetAllEmployees();
            Employee existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);

            if(existingEmployee!=null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.DOB = employee.DOB;

                SaveEmployees(employees);
            }
        }

        public void Delete(int id)
        {
            List<Employee> employees = GetAllEmployees();
            Employee employeeDelete = employees.FirstOrDefault(e => e.Id == id);
            if(employeeDelete!=null)
            {
                employees.Remove(employeeDelete);
                SaveEmployees(employees);

            }

  
        }
    }
}