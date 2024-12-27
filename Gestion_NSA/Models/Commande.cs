using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Commande
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La date de la commande est requise.")]
        [DataType(DataType.Date, ErrorMessage = "La date de commande doit être valide.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Le montant est requis.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être un montant positif.")]
        public decimal Montant { get; set; }

        [Required(ErrorMessage = "L'identifiant du client est requis.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Le client associé est requis.")]
        public Client Client { get; set; }

        public ICollection<ProduitCommande> ProduitCommandes { get; set; }

        public int? LivraisonId { get; set; }

        public Livraison Livraison { get; set; }
    }


}
