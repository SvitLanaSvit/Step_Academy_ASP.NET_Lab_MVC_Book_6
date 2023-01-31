using Lab_MVC_Book_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Lab_MVC_Book_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Book> repository; 

        public HomeController(ILogger<HomeController> logger, IRepository<Book> repository)
        {
            _logger = logger;
            this.repository = repository; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BookInfo()
        {
            IEnumerable<Book> books = repository.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            Book? book = repository.Get(id);
            return View((Object)book!.AboutBook);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return Content("<html><h2 style='color: red'>There aren`t all filled fields!</h2><html>", "text/html");
            }
            int id = repository.GetAll().Max(x => x.Id);
            book.Id = ++id;
            repository.Add(book);
            return RedirectToAction("BookInfo");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return Content("<html><h2 style='color: red;'>You must provide id of book!</h2></html>", "text/html");
            }
            Book? book = repository.Get(id.Value);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                repository.Edit(book);
                return RedirectToAction("BookInfo");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Content("<html><h2 style='color: red;'>You must provide id of book!</h2></html>", "text/html");
            }
            Book? book = repository.Get(id.Value);
            return View(book);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id) 
        {
            if (repository.Delete(id!.Value))
            {
                return RedirectToAction("BookInfo");
            }
            else
            {
                return Content($"<html><h2 style='color: red;'>The book with id = {id} is not exists!</h2></html>", "text/html");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}