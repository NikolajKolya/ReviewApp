namespace ReviewApp.Services.Abstract;

public interface IFilesService
{
    /// <summary>
    /// Get form file and convert it bytes array
    /// </summary>
    Task<byte[]> FileToBytesArrayAsync(IFormFile file);
    
    /// <summary>
    /// Add file to database
    /// </summary>
    Task<Guid> AddFileAsync(string type, byte[] content);

    /// <summary>
    /// Get file from DB.
    /// Tuple.Item1 - file type
    /// Tuple.Item2 - file content
    /// </summary>
    Task<Tuple<string, byte[]>> GetFileByIdAsync(Guid fileId);
}