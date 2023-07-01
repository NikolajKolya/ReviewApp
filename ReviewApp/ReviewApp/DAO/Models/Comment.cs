using System.ComponentModel.DataAnnotations;

namespace ReviewApp.DAO.Models;

public class Comment
{
    [Key]
    public Guid Id { get; set; }

    public Good Good { get; set; }
    
    public string Content { get; set; }
    
    public int Rating { get; set; }

    public DateTime CreationTime { get; set; }

    public Good ParentGood { get; set; }
}