using Lab_MVC_Book_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_MVC_Book_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            List<Book> books = new ();
            Book book1 = new()
            {
                Id = 1,
                Author = "Patrick Ness",
                Name = "The Knife of Never Letting Go",
                Genre = "Young-adult, science fiction",
                Publishing = "Walker Books",
                YearOfPublishing = 2008,
                FilePath = "/images/Knife_of_Never_letting_Go_cover.jpg"
            };
            Book book2 = new()
            {
                Id = 2,
                Author = "Patrick Ness",
                Name = "The Ask and the Answer ",
                Genre = "Young-adult, science fiction",
                Publishing = "Walker Books",
                YearOfPublishing = 2009,
                FilePath = "/images/The_Ask_and_the_Answer.jpg"
            };
            books.Add (book1);
            books.Add (book2);
            return View(books);
        }

        public IActionResult Details(int id)
        {
            string str = "";
            if(id == 1)
            {
                str = "„A bleak and unflinching novel with fascinating characters and extraordinary " +
                    "dialogue which creates a fully-realised world that the reader really buys into. " +
                    "The dog Manchee is an inspired creation! Ness conveys a real sense of terror " +
                    "and the ending is devastating. A novel that really stands out.“";
            }
            else if(id == 2)
            {
                str = "„A visceral and compelling story of incredible power which combines " +
                    "some fantastic writing with intelligent consideration of some important issues: " +
                    "the nature of war, terrorism and the treatment of women. A challenging novel which " +
                    "really lives inside your head.“";

            }
            return View((Object)str);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}