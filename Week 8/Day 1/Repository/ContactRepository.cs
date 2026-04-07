using System.Security.Cryptography.Pkcs;
using WebApplication10.Models;
using Dapper;
using WebApplication10.Data;


namespace WebApplication10.Repository
{
    public class ContactRepository: IContactRepository
    {
        private readonly DapperContext _context;
       
        public ContactRepository(DapperContext context)
        {
            _context = context;
        } 
        
        public List<ContactInfo> GetAllContacts()
        {
            string query = @"
                SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId,
                       c.MobileNo, c.Designation, c.CompanyId,
                       c.DepartmentId,
                       co.CompanyName,
                       d.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company co ON c.CompanyId = co.CompanyId
                INNER JOIN Department d ON c.DepartmentId = d.DepartmentId";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<ContactInfo>(query).ToList();
            }
        }
        public ContactInfo GetContactById(int id)
        {
            string query = @"
                SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId,
                       c.MobileNo, c.Designation, c.CompanyId,
                       c.DepartmentId,
                       co.CompanyName,
                       d.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company co ON c.CompanyId = co.CompanyId
                INNER JOIN Department d ON c.DepartmentId = d.DepartmentId
                WHERE c.ContactId = @Id";

            using (var connection = _context.CreateConnection())
            {
                return connection.QueryFirstOrDefault<ContactInfo>(query, new { Id = id });
            }
        }
        public void AddContact(ContactInfo contact)
        {
            string query = @"
                INSERT INTO ContactInfo
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES
                (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, contact);
            }
        }
        public void UpdateContact(ContactInfo contact)
        {
            string query = @"
                UPDATE ContactInfo
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    EmailId = @EmailId,
                    MobileNo = @MobileNo,
                    Designation = @Designation,
                    CompanyId = @CompanyId,
                    DepartmentId = @DepartmentId
                WHERE ContactId = @ContactId";

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, contact);
            }
        }
        public void DeleteContact(int id)
        {
            string query = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { Id = id });
            }
        }
        public List<Company> GetCompanies()
        {
            string query = "SELECT * FROM Company";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Company>(query).ToList();
            }
        }
        public List<Department> GetDepartments()
        {
            string query = "SELECT * FROM Department";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Department>(query).ToList();
            }
        }
    }
}


