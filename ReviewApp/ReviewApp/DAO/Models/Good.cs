using System.ComponentModel.DataAnnotations;

namespace ReviewApp.DAO.Models
{
    public class Good
    {
        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TimeSpan { get; set; }
        
        public Guid PhotoFileId { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
