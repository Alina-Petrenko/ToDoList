using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Database
{
    /// <summary>
    /// Represents the database context for managing to-do list items.
    /// </summary>
    public class TodoDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoDbContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{TContext}"/> used to configure the context.</param>
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets a DbSet of <see cref="TodoItem"/> representing the collection of to-do list items in the database.
        /// </summary>
        public DbSet<TodoItem> Items { get; set; }
    }
}
