using App10.Model;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Microsoft.EntityFrameworkCore;
using System.IO;

namespace App10.View_Model
{
    public class EmployeeViewModel
    {



 /*     public EmployeeModel EmployeeModelSet { get; set; }
        
        public EmployeeViewModel() 
        {
            EmployeeModelSet = new EmployeeModel
            {
                ID = 1,
                Name = "Juan Dela Cruz",
                Email = "juandelacruz@auf.edu.ph",
                Address = "Angeles City"
            };
        }*/

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        //Insert or Add Employee to the database.
        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employees.ToListAsync();
            return res;
        }

        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c; 
        }
    }
}
