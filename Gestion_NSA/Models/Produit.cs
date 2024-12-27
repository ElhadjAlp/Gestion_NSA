using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est requis.")]
        [StringLength(100, ErrorMessage = "Le libellé ne doit pas dépasser 100 caractères.")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "La quantité en stock est requise.")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être un nombre positif.")]
        public int QuantiteEnStock { get; set; }

        [Required(ErrorMessage = "Le prix unitaire est requis.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix unitaire doit être supérieur à 0.")]
        public decimal PrixUnitaire { get; set; }

        [Required(ErrorMessage = "La quantité seuil est requise.")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité seuil doit être un nombre positif.")]
        public int QuantiteSeuil { get; set; }

        [StringLength(200, ErrorMessage = "Le chemin des images ne doit pas dépasser 200 caractères.")]
        public string Images { get; set; }

        public ICollection<ProduitCommande> ProduitCommandes { get; set; }
    }
}
