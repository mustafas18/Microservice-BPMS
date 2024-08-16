namespace Identity.API.Models
{
    public class Department : BaseEntity
    {
        public Department()
        {
                
        }
        public Department(int id,Guid departmentId,string name,string culture)
        {
            Id = id;
            DepartmentId = departmentId;
            Name = name;
            Culture = culture;
        }
        public Guid DepartmentId { get; private set; }
        public string Name { get; private set; }
        public string Culture { get; private set; }
       // public List<ApplicationUser> AppUser { get; private set; }
    }
}
