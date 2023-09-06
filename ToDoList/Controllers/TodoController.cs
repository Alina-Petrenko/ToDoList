using ToDoList.Models;
using ToDoList.Database;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    /// <summary>
    /// Controller for managing to-do list items.
    /// </summary>
    public class TodoController : Controller
    {
        /// <summary>
        /// The database context for to-do items.
        /// </summary>
        private readonly TodoDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class with the provided database context.
        /// </summary>
        /// <param name="context">The database context for to-do items.</param>
        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays a list of to-do items.
        /// </summary>
        /// <returns>The view displaying the list of tasks.</returns>
        public IActionResult Index()
        {
            var tasks = _context.Items.ToList();
            return View(tasks);
        }

        /// <summary>
        /// Displays the form for creating a new to-do item.
        /// </summary>
        /// <returns>The view for creating a new task.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the creation of a new to-do item.
        /// </summary>
        /// <param name="todoItem">The to-do item to be created.</param>
        /// <returns>Redirects to the index page if successful, or shows the creation form with errors if validation fails.</returns>
        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(todoItem);
        }

        /// <summary>
        /// Displays the confirmation page for deleting a to-do item.
        /// </summary>
        /// <param name="id">The ID of the to-do item to delete.</param>
        /// <returns>The confirmation view for deleting the selected task.</returns>

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var todoItem = _context.Items.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        /// <summary>
        /// Handles the deletion of a to-do item.
        /// </summary>
        /// <param name="id">The ID of the to-do item to delete.</param>
        /// <returns>Redirects to the index page after deletion.</returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var todoItem = _context.Items.Find(id);
            if (todoItem != null)
            {
                _context.Items.Remove(todoItem);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
