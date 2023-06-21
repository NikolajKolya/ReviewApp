using File = ReviewApp.DAO.Models.File;

namespace ReviewApp.DAO.Abstract;

public interface IFilesDao
{
    Task AddFileAsync(File file);

    Task<File> GetFileByIdAsync(Guid fileId);
}