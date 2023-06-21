using ReviewApp.DAO.Abstract;
using ReviewApp.DAO.Models;
using ReviewApp.Services.Abstract;
using File = ReviewApp.DAO.Models.File;

namespace ReviewApp.Services.Implementations;

public class FilesService : IFilesService
{
    private readonly IFilesDao _filesDao;

    public FilesService
    (
        IFilesDao filesDao
    )
    {
        _filesDao = filesDao;
    }

    public async Task<byte[]> FileToBytesArrayAsync(IFormFile file)
    {
        _ = file ?? throw new ArgumentNullException(nameof(file));

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
        
            return memoryStream.ToArray();
        }
    }

    public async Task<Guid> AddFileAsync(string type, byte[] content)
    {
        _ = content ?? throw new ArgumentNullException(nameof(content));

        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException(nameof(type));
        }

        var file = new File()
        {
            Id = Guid.Empty, // Пустой, бессмысленный GUID
            FileType = type,
            EncodedFile = Convert.ToBase64String(content)
        };

        await _filesDao.AddFileAsync(file);

        return file.Id;
    }

    public async Task<Tuple<string, byte[]>> GetFileByIdAsync(Guid fileId)
    {
        var file = await _filesDao.GetFileByIdAsync(fileId);

        return new Tuple<string, byte[]>(file.FileType, Convert.FromBase64String(file.EncodedFile));
    }
}