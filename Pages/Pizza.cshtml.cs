using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPP.Models;
using WebAPP.Services;

// dotnet new page --name Pizza --namespace WebAPP.Pages --output Pages
namespace WebAPP.Pages
{
    public class PizzaModel : PageModel
    {
        public List<Pizza> pizzas = new();
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public void OnGet()
        {
            pizzas = PizzaServices.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaServices.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaServices.Delete(id);
            return RedirectToAction("Get");
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free": "Not Gluten Free";
        }
    }
}
