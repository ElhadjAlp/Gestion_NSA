using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_NSA.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        [StringLength(100, ErrorMessage = "L'adresse ne doit pas dépasser 100 caractères.")]
        public string Adresse { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le solde doit être un montant positif.")]
        public decimal Solde { get; set; }

        // Une relation avec la table Commande
        public ICollection<Commande> Commandes { get; set; }

        // Ajout de la collection Paiements pour établir la relation avec Paiement
        public ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
    }
}
