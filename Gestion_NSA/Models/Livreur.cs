using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Livreur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du livreur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom du livreur est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string Telephone { get; set; }

        public ICollection<Livraison> Livraisons { get; set; }
    }
}
