using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    /// <summary>
    /// Represents an individual item in a to-do list.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the to-do item.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name or description of the to-do task.
        /// </summary>
        [Required]
        public string TaskName { get; set; }
    }
}
