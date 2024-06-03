using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication2.Models;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Streaming;Trusted_Connection=True;MultipleActiveResultSets=true";

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Company company = null; 
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM Companies WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                company = new Company
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    UsersNumber = (int)reader["UsersNumber"],
                    FoundationDate = (DateTime)reader["FoundationDate"],
                    Address = (string)reader["Address"],
                    Capitalization = (int)reader["Capitalization"],
                    EmployeesNumber = (int)reader["EmployeesNumber"]
                };
            }
        }
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] Company company)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Companies (Id, Name, UsersNumber, FoundationDate, Address, Capitalization, " +
                "EmployeesNumber) VALUES (@Id, @Name, @UsersNumber, @FoundationDate, @Address, @Capitalization, @EmployeesNumber)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", company.Id);
            command.Parameters.AddWithValue("@Name", company.Name);
            command.Parameters.AddWithValue("@UsersNumber", company.UsersNumber);
            command.Parameters.AddWithValue("@FoundationDate", company.FoundationDate);
            command.Parameters.AddWithValue("@Address", company.Address);
            command.Parameters.AddWithValue("@Capitalization", company.Capitalization);
            command.Parameters.AddWithValue("@EmployeesNumber", company.EmployeesNumber);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(int id, [FromBody] Company company)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "UPDATE Companies SET Id = @Id, Name = @Name, UsersNumber = @UsersNumber, FoundationDate = " +
                "@FoundationDate, Address = @Address, Capitalization = @Capitalization, EmployeesNumber = @EmployeesNumber " +
                "WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", company.Name);
            command.Parameters.AddWithValue("@UsersNumber", company.UsersNumber);
            command.Parameters.AddWithValue("@FoundationDate", company.FoundationDate);
            command.Parameters.AddWithValue("@Address", company.Address);
            command.Parameters.AddWithValue("@Capitalization", company.Capitalization);
            command.Parameters.AddWithValue("@EmployeesNumber", company.EmployeesNumber);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(int id)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "DELETE FROM Companies WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }
}

