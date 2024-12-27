using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class ProduitCommande
    {
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure ou égale à 1.")]
        public int Quantite { get; set; }
    }
}
