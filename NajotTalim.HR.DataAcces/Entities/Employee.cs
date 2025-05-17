namespace NajotTalim.HR.DataAcces.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public Adress Adress { get; set; }
        public int AdressId { get; set; }
    }
}





