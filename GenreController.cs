using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication2.Models;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Streaming;Trusted_Connection=True;MultipleActiveResultSets=true";

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Genre genre = null;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM Genres WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                genre = new Genre
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Popularity = (int)reader["Popularity"]
                };
            }
        }
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] Genre genre)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Genres (Id, Name, Popularity) VALUES (@Id, @Name, @Popularity)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", genre.Id);
            command.Parameters.AddWithValue("@Name", genre.Name);
            command.Parameters.AddWithValue("@Popularity", genre.Popularity);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(int id, [FromBody] Genre genre)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "UPDATE Genres SET Id = @Id, Name = @Name, Popularity = @Popularity WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", genre.Name);
            command.Parameters.AddWithValue("@Popularity", genre.Popularity);
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
            string query = "DELETE FROM Genres WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }
}

