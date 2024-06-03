using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication2.Models;

[ApiController]
[Route("api/[controller]")]
public class MovieSeriesController : ControllerBase
{
    private readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Streaming;Trusted_Connection=True;MultipleActiveResultSets=true";

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        MovieSeries project = null;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM FilmsNSeries WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                project = new MovieSeries
                {
                    Id = (int)reader["Id"],
                    Title = (string)reader["Title"],
                    Budget = (int)reader["Budget"],
                    ProductionCountry = (string)reader["ProductionCountry"],
                    Description = (string)reader["Description"],
                    Duration = (int)reader["Duration"],
                    SeasonNumber = (int)reader["SeasonNumber"],
                    EpisodesNumber = (int)reader["EpisodesNumber"],
                    Rating = (int)reader["Rating"],
                    Exclusivity = (int)reader["Exclusivity"],
                    ViewsNumber = (int)reader["ViewsNumber"],
                    Genre = (int)reader["Genre"]
                };
            }
        }
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] MovieSeries project)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO FilmsNSeries (Id, Title, Budget, ProductionCountry, Description, Duration, " +
                "SeasonNumber, EpisodesNumber, Rating, Exclusivity, ViewsNumber, Genre) VALUES (@Id, @Title, @Budget, " +
                "@ProductionCountry, @Description, @Duration, @SeasonNumber, @EpisodesNumber, @Rating, @Exclusivity, " +
                "@ViewsNumber, @Genre)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", project.Id);
            command.Parameters.AddWithValue("@Title", project.Title);
            command.Parameters.AddWithValue("@Budget", project.Budget);
            command.Parameters.AddWithValue("@ProductionCountry", project.ProductionCountry);
            command.Parameters.AddWithValue("@Description", project.Description);
            command.Parameters.AddWithValue("@Duration", project.Duration);
            command.Parameters.AddWithValue("@SeasonNumber", project.SeasonNumber);
            command.Parameters.AddWithValue("@EpisodesNumber", project.EpisodesNumber);
            command.Parameters.AddWithValue("@Rating", project.Rating);
            command.Parameters.AddWithValue("@Exclusivity", project.Exclusivity);
            command.Parameters.AddWithValue("@ViewsNumber", project.ViewsNumber);
            command.Parameters.AddWithValue("@Genre", project.Genre);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(int id, [FromBody] MovieSeries project)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "UPDATE FilmsNSeries SET Id = @Id, Title = @Title, Budget = @Budget, ProductionCountry = " +
                "@ProductionCountry, Description = @Description, Duration = @Duration, SeasonNumber = @SeasonNumber, " +
                "EpisodesNumber = @EpisodesNumber, Rating = @Rating, Exclusivity = @Exclusivity, ViewsNumber = @ViewsNumber, " +
                "Genre = @Genre WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Title", project.Title);
            command.Parameters.AddWithValue("@Budget", project.Budget);
            command.Parameters.AddWithValue("@ProductionCountry", project.ProductionCountry);
            command.Parameters.AddWithValue("@Description", project.Description);
            command.Parameters.AddWithValue("@Duration", project.Duration);
            command.Parameters.AddWithValue("@SeasonNumber", project.SeasonNumber);
            command.Parameters.AddWithValue("@EpisodesNumber", project.EpisodesNumber);
            command.Parameters.AddWithValue("@Rating", project.Rating);
            command.Parameters.AddWithValue("@Exclusivity", project.Exclusivity);
            command.Parameters.AddWithValue("@ViewsNumber", project.ViewsNumber);
            command.Parameters.AddWithValue("@Genre", project.Genre);
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
            string query = "DELETE FROM FilmsNSeries WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
        return Ok();
    }
}
