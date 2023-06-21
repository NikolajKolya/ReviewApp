using System.ComponentModel.DataAnnotations;

namespace ReviewApp.DAO.Models;

public class File
{
    [Key]
    public Guid Id { get; set; }
    
    public string EncodedFile { get; set; }
    
    public string FileType { get; set; }
}