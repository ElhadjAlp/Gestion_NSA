using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Livraison
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La date de livraison est requise.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'adresse de livraison est requise.")]
        [StringLength(200, ErrorMessage = "L'adresse de livraison ne doit pas dépasser 200 caractères.")]
        public string AdresseLivraison { get; set; }

        [Required(ErrorMessage = "Le livreur est requis.")]
        public int LivreurId { get; set; }

        public Livreur Livreur { get; set; }

        [Required(ErrorMessage = "La commande est requise.")]
        public int CommandeId { get; set; }

        public Commande Commande { get; set; }
    }
}
