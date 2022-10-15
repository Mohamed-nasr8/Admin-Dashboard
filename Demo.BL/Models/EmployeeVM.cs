using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace Demo.BL.Models
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(50, ErrorMessage = "Max Len 50")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Salary Required")]
        [Range(2000,10000, ErrorMessage ="Range Btw 2000 : 10000")]
        public double Salary { get; set; }

        public DateTime HireDate { get; set; }



        public bool IsActive { get; set; }


        public string Notes { get; set; }

        [EmailAddress(ErrorMessage =" Email Invalid")]
        public string Email { get; set; }

        //[RegularExpression("[0-9]{2,5}-[A-Za-z]{2,5}-[A-Za-z]{2,5}-[A-Za-z]{2,5} ",ErrorMessage ="like : 12-Street-City-Country")]
        public string Address { get; set; }


      [Required(ErrorMessage ="Choose Department")]
        public int DepartmentId { get; set; }

        public DateTime CreationDate { get; set; }

        public Department Department { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }


        public string PhotoName { get; set; }
        public string CvName { get; set; }

        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }

    }
}
