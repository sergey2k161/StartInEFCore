using Microsoft.EntityFrameworkCore;
using StartInEFCore.Models;

namespace StartInEFCore.Repositories;

public class MovieStudioRepository
{
    private readonly ApplicationDBContext _dbContext;

    public MovieStudioRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<MovieStudio>> Get()
    {
        return await _dbContext.MovieStudios.ToListAsync();
    }

    public async Task<List<MovieStudio>> GetWithFilms()
    {
        return await _dbContext.MovieStudios
            .Include(c => c.Films)
            .ToListAsync();
    }

    public async Task<MovieStudio?> GetById(Guid id)
    {
        return await _dbContext.MovieStudios
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<MovieStudio>> GetByFilter(string title)
    {
        var query = _dbContext.MovieStudios.AsNoTracking();

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(c => c.Title.Contains(title));
        }

        return await query.ToListAsync();
    }

    // Пагинация
    public async Task<List<MovieStudio>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.MovieStudios
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(Guid id, Guid directorId, string title, string discription)
    {
        var movieStudio = new MovieStudio
        {
            Id = id,
            DirectorId = directorId,
            Title = title,
            Discription = discription
        };

        await _dbContext.AddAsync(movieStudio);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update2(Guid id, Guid directorId, string title, string discription)
    {
        await _dbContext.MovieStudios
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.DirectorId, directorId)
                .SetProperty(c => c.Discription, discription));
    }


    public void DeleteById(Guid id)
    {
        _dbContext.MovieStudios
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}
