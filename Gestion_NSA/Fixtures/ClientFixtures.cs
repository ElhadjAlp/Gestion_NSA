using Gestion_NSA.Data;
using Gestion_NSA.Models;

namespace Gestion_NSA.Fixtures
{
    public class ClientFixtures
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientFixtures(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Load()
        {
            // Fixture pour Client
            if (!_dbContext.Clients.Any())
            {
                _dbContext.Clients.Add(new Client
                {
                    Nom = "Client1",
                    Prenom = "Prenom1",
                    Telephone = "0123456789",
                    Adresse = "Adresse1",
                    Solde = 100
                });
            }

            // Fixture pour Produit
            if (!_dbContext.Produits.Any())
            {
                _dbContext.Produits.Add(new Produit
                {
                    Libelle = "Produit1",
                    QuantiteEnStock = 100,
                    PrixUnitaire = 10.5m,
                    QuantiteSeuil = 10,
                    Images = "produit1.jpg"
                });
            }

            // Fixture pour Commande
            if (!_dbContext.Commandes.Any())
            {
                var client = _dbContext.Clients.FirstOrDefault();
                _dbContext.Commandes.Add(new Commande
                {
                    ClientId = client?.Id ?? 0,
                    Date = DateTime.Now,
                    Montant = 50.5m
                });
            }

            // Fixture pour Livraison
            if (!_dbContext.Livraisons.Any())
            {
                var commande = _dbContext.Commandes.FirstOrDefault();
                _dbContext.Livraisons.Add(new Livraison
                {
                    CommandeId = commande?.Id ?? 0,
                    Date = DateTime.Now,
                    AdresseLivraison = "Yoff"
                });
            }

            // Fixture pour Livreur
            if (!_dbContext.Livreurs.Any())
            {
                _dbContext.Livreurs.Add(new Livreur
                {
                    Nom = "Livreur1",
                    Prenom = "PrenomLivreur1",
                    Telephone = "0987654321"
                });
            }

            // Fixture pour Paiement
            if (!_dbContext.Paiements.Any())
            {
                var client = _dbContext.Clients.FirstOrDefault();
                _dbContext.Paiements.Add(new Paiement
                {
                    ClientId = client?.Id ?? 0,
                    Montant = 100.0m,
                    Date = DateTime.Now
                });
            }

            // Fixture pour ProduitCommande
            if (!_dbContext.ProduitCommandes.Any())
            {
                var commande = _dbContext.Commandes.FirstOrDefault();
                var produit = _dbContext.Produits.FirstOrDefault();
                _dbContext.ProduitCommandes.Add(new ProduitCommande
                {
                    CommandeId = commande?.Id ?? 0,
                    ProduitId = produit?.Id ?? 0,
                    Quantite = 2
                });
            }

            // Sauvegarder les changements dans la base de données
            _dbContext.SaveChanges();
        }
    }
}
