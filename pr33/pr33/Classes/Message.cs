using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr33.Classes
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автогенерация ID
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
    }
}
