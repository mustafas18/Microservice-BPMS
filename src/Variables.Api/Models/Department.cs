namespace Variables.API.Models
{
    public class Department : BaseEntity
    {
        public Department()
        {
                
        }
        public Department(int id,Guid departmentId,Guid parentId,string name,string adminId)
        {
            Id = id;
            ParentId = parentId;
            DepartmentId = departmentId;
            Name = name;
            AdminId = adminId;
        }
        public Guid DepartmentId { get; private set; }
        public Guid ParentId {  get; private set; }
        public string Name { get; private set; }
        public string AdminId { get; private set; }

       // public List<ApplicationUser> AppUser { get; private set; }
    }
}
