using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Equipment;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Item> Items { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH for Character hierarchy
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m=> m.MonsterType)
                .HasValue<Goblin>("Goblin");

            // Configure TPH for Ability hierarchy
            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>(pa=>pa.AbilityType)
                .HasValue<ShoveAbility>("ShoveAbility");

            // Configure many-to-many relationship
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithMany(a => a.Players)
                .UsingEntity(j => j.ToTable("PlayerAbilities"));

            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>(i => i.ItemType)
                .HasValue<Weapon>("Weapon")
                .HasValue<Armor>("Armor");

            // these created tables are for when there is only one iteration of a specific item
            //      (I.E. a named sword that's one of a kind)
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Players)
                .WithMany(p => p.Inventory)
                .UsingEntity(j => j.ToTable("PlayerItems"));

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Monsters)
                .WithMany(m => m.Inventory)
                .UsingEntity(j => j.ToTable("MonsterItems"));

            base.OnModelCreating(modelBuilder);
        }

    }
}


