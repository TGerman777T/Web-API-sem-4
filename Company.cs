namespace WebApplication2.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersNumber { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Address { get; set; }
        public int Capitalization { get; set; }
        public int EmployeesNumber { get; set; }
    }
}
