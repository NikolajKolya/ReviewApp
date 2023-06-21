using Microsoft.EntityFrameworkCore;
using ReviewApp.DAO.Abstract;
using File = ReviewApp.DAO.Models.File;

namespace ReviewApp.DAO.Implementations;

public class FilesDao : IFilesDao
{
    private readonly MainDbContext _mainDbContext;
    
    public FilesDao(MainDbContext mainDbContext)
    {
        _mainDbContext = mainDbContext;
    }
    
    public async Task AddFileAsync(File file)
    {
        _ = file ?? throw new ArgumentNullException(nameof(file));

        _mainDbContext.Add(file);
        await _mainDbContext.SaveChangesAsync();
    }

    public async Task<File> GetFileByIdAsync(Guid fileId)
    {
        var result = await _mainDbContext
            .Files
            .SingleOrDefaultAsync(f => f.Id == fileId);

        _ = result ?? throw new ArgumentException("File not found!", nameof(fileId));

        return result;
    }

    public async Task DeleteFileByIdAsync(Guid fileId)
    {
        var file = await GetFileByIdAsync(fileId);
        _mainDbContext.Remove(file);
        await _mainDbContext.SaveChangesAsync();
    }
}