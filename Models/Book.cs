using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_System.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BookName { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Author> Author { get; set; }
        
    }
}