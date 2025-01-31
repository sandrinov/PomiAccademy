
namespace TestWebAppMVC.TestWebAppMVC.DAL
{
    public class EFDataSource : IDataSource
    {
        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Test",
                    IdEmployee = 1,
                    LastName = "TestTest"
                }
            };
        }
    }
}
