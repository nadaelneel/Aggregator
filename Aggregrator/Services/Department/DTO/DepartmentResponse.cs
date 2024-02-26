namespace Aggregrator.Services.Department.DTO
{
    public class DepartmentResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
