using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Paiement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le type de paiement est requis.")]
        [StringLength(50, ErrorMessage = "Le type de paiement ne doit pas dépasser 50 caractères.")]
        public string Type { get; set; } // OM, Wave, chèque, etc.

        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être positif et supérieur à zéro.")]
        public decimal Montant { get; set; }

        [Required(ErrorMessage = "La référence du paiement est requise.")]
        [StringLength(100, ErrorMessage = "La référence ne doit pas dépasser 100 caractères.")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "La date du paiement est requise.")]
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
