using firstpro.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstpro.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            Produit produit = new Produit() { Nom = "Produit 1" };
            List<Produit> produits = new List<Produit>()
            {
            new Produit() {Nom ="Produit 2" },
            new Produit() { Nom = "Produit 3" },
            };
            return View(produits);
        }
        public IActionResult Edit(int id)
        {
            return Content("id   " + id);
        }
        public IActionResult List()
        {
         
                ProduitClient produitClient = new ProduitClient();
            produitClient.prod = new Produit()
            {
                id = 1,
                Nom = "produit1"
            };
            produitClient.cl = new List<Client> { new Client() { id = 1, name="nour"},
                new Client() { id = 4,name="balsem" } };

            return View(produitClient);

        }

    }
}