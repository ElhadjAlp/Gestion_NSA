using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Définition des DbSet pour vos entités
        public DbSet<Client> Clients { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<ProduitCommande> ProduitCommandes { get; set; }

        // Configuration des entités et des relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la relation entre Commande et Client
            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Commandes)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration de la relation entre Commande et Livraison (1:1)
            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Livraison)
                .WithOne(l => l.Commande)
                .HasForeignKey<Livraison>(l => l.CommandeId) // Spécifier la clé étrangère
                .OnDelete(DeleteBehavior.Cascade); // Choix de la suppression en cascade

            // Configuration de la relation entre Livraison et Livreur (1:N)
            modelBuilder.Entity<Livraison>()
                .HasOne(l => l.Livreur)
                .WithMany(lv => lv.Livraisons)
                .HasForeignKey(l => l.LivreurId)
                .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade

            // Configuration de la relation entre Paiement et Client
            modelBuilder.Entity<Paiement>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Paiements)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade

            // Configuration de la relation entre Produit et Commande via ProduitCommande
            modelBuilder.Entity<ProduitCommande>()
                .HasKey(pc => new { pc.CommandeId, pc.ProduitId }); // Définir la clé composite

            modelBuilder.Entity<ProduitCommande>()
                .HasOne(pc => pc.Commande)
                .WithMany(c => c.ProduitCommandes)
                .HasForeignKey(pc => pc.CommandeId)
                .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade

            modelBuilder.Entity<ProduitCommande>()
                .HasOne(pc => pc.Produit)
                .WithMany(p => p.ProduitCommandes)
                .HasForeignKey(pc => pc.ProduitId)
                .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade
        }
    }
}
