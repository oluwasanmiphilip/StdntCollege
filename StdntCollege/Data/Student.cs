using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StdntCollege.Data
{
    public class Student
    {
        //Data Source=DESKTOP-8SCFG0K\MSSQLSERVER01;Initial Catalog=demodb;Integrated Security=True;Trust Server Certificate=True

        
           
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public DateTime DOB {  get; set; } 

    }
}
