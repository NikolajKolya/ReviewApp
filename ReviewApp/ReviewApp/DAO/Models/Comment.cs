using System.ComponentModel.DataAnnotations;

namespace goods.DAO.Models;

public class Comment
{
    [Key]
    public Guid Id { get; set; }

    public Good Good { get; set; }
    
    public string Content { get; set; }
    
    public int Rating { get; set; }
}