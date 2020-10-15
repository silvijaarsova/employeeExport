namespace EmployeeApp.Contracts
{
    public class Employee
    {
        public int Id { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public int? Bonus
        {
            get
            {
                var bonus = 0;
                if (Id % 3 == 0)
                    bonus = 30;
                if (Id % 7 == 0)
                    bonus += 70;
                return bonus;
            }           
        }
    }
}
