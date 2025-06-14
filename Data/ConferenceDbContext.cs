using Code_Academy___Conference_Management_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Code_Academy___Conference_Management_System.Data
{
    public class ConferenceDbContext : IdentityDbContext<IdentityUser>
    {
        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          

            // Event
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

               

                entity.HasOne(e => e.Location)
                      .WithMany()
                      .HasForeignKey(e => e.LocationId);

                entity.HasOne(e => e.EventType)
                      .WithMany()
                      .HasForeignKey(e => e.EventTypeId);

                entity.HasOne(e => e.Organizer)
                      .WithMany()
                      .HasForeignKey(e => e.OrganizerId);
            });

            // Invitation
            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.HasOne(i => i.Event)
                      .WithMany()
                      .HasForeignKey(i => i.EventId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(i => i.User)
                      .WithMany()
                      .HasForeignKey(i => i.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(i => i.InvitationStatus)
                      .IsRequired();

                entity.Property(i => i.SentAt)
                      .IsRequired();
            });

            // Participation
            modelBuilder.Entity<Participation>(entity =>
            {
                entity.HasOne(p => p.Invitation)
                      .WithMany()
                      .HasForeignKey(p => p.InvitationId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.CheckInTime)
                      .IsRequired(false);

                entity.Property(p => p.SeatNumber)
                      .HasMaxLength(20);
            });

            // EventType
            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // Location
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(l => l.Name)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(l => l.Address)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(l => l.Capacity)
                      .IsRequired();
            });

            // Organizer
            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.Property(o => o.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(o => o.Email)
                      .IsRequired();
            });

            // Notification
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(n => n.Event)
                      .WithMany()
                      .HasForeignKey(n => n.EventId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(n => n.Message)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(n => n.SentAt)
                      .IsRequired();
            });

            // Feedback
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(f => f.Event)
                      .WithMany()
                      .HasForeignKey(f => f.EventId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.User)
                      .WithMany()
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(f => f.Rating)
                      .IsRequired();

                entity.Property(f => f.Comment)
                      .HasMaxLength(1000);

                entity.Property(f => f.SubmittedAt)
                      .IsRequired();
            });
        }

    }
}
