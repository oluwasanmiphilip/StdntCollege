namespace StdntCollege.Models
{
    //memory repository
    public static class CollegeRepository
    {
        public static List<Student> students 
        { 
            get; set; 
        
        } = new List<Student>() { 
                new Student()
                {
                    Id = 1,
                    StudentName = "Ire",
                    StudentEmail = "ireolu@gmail.com",
                    Address = "Festac Town",



                },
                new Student()
                {
                    Id = 2,
                    StudentName = "IreOlu",
                    StudentEmail = "ireolu@gmail.com",
                    Address = "Festac Town",

                },
            };
    }
}
