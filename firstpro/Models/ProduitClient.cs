namespace firstpro.Models
{
    public class ProduitClient
    {
        public Produit prod {  get; set; }
        public List<Client> cl = new List<Client>()
        {
            new Client() {id=1,name="bal"},
            new Client (){id=4,name="ham"},
        };
    }
}
