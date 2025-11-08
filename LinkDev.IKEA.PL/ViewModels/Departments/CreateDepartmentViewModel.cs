namespace LinkDev.IKEA.PL.ViewModels.Departments
{
    public class CreateDepartmentViewModel
    {
        public int Id { get; set; }
        public required  string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
