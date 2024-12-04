using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure.Seeding;

namespace SportApp_Infrastructure
{
    public class SportAppDbContext: IdentityDbContext<User,Role,Guid>
    {
        public SportAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<SportField> SportField { get; set; }
        public DbSet<FieldType> FieldType { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; } 
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Spec> Spec { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<BookingTimeSlot> BookingTimeSlots { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<SportProduct> SportProduct { get; set; }
        public DbSet<SportProductVariant> SportProductVariant { get; set; }
        public DbSet<ImageProduct> ImageProduct { get; set; }  
        public DbSet<Size> Size {  get; set; }
        public DbSet<Cart> Cart {  get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SportTeam> SportTeam { get; set; }
        public DbSet<UserSportTeam> UserSportTeam { get;set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<SportFieldVoucher> SportFieldVouchers { get; set; }
        public DbSet<SportProductRating> SportProductRatings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Rating
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Ratings)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.SportField)
                .WithMany()
                .HasForeignKey(b => b.SportFieldId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region SportField
            modelBuilder.Entity<SportField>()
                .HasIndex(s => s.EndPoint)
                .HasDatabaseName("IX_SportField_Endpoint")
                .IsUnique();
            modelBuilder.Entity<SportField>()
                .Property(s => s.Stars)
                .HasColumnType("decimal(2,1)");
            #endregion
            #region BookingTimeSlot
            modelBuilder.Entity<BookingTimeSlot>()
            .HasKey(e => new { e.BookingId, e.TimeSlotId });
            modelBuilder.Entity<BookingTimeSlot>()
                .HasOne(b => b.Booking)
                .WithMany(b => b.TimeSlotBookeds)
                .HasForeignKey(b => b.BookingId);

            modelBuilder.Entity<BookingTimeSlot>()
                .HasOne(b => b.TimeSlot)
                .WithMany()
                .HasForeignKey(b => b.TimeSlotId);
            modelBuilder.Entity<BookingTimeSlot>()
                .HasOne(b => b.Booking)
                .WithMany(b => b.TimeSlotBookeds)
                .HasForeignKey(b => b.BookingId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region UserNotificaiton
            modelBuilder.Entity<UserNotification>()
                .HasKey(u => new { u.NotificationId, u.UserId });
            modelBuilder.Entity<UserNotification>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<UserNotification>()
                .HasOne(b => b.Notification)
                .WithMany()
                .HasForeignKey(b => b.NotificationId);
            #endregion
            #region UserSportTeam
            modelBuilder.Entity<UserSportTeam>()
            .HasKey(e => new { e.SportTeamId, e.CustomerId });
            modelBuilder.Entity<UserSportTeam>()
                .HasOne(b => b.SportTeam)
                .WithMany(c=>c.Members)
                .HasForeignKey(b => b.SportTeamId);

            modelBuilder.Entity<UserSportTeam>()
                .HasOne(b => b.Customer)
                .WithMany(c=>c.Teams)
                .HasForeignKey(b => b.CustomerId);
            #endregion
            #region SportFieldVoucher
            modelBuilder.Entity<SportFieldVoucher>()
                .HasKey(s => new { s.SportFieldId, s.VoucherId });
            modelBuilder.Entity<SportFieldVoucher>()
               .HasOne(s => s.SportField)
               .WithMany(s=>s.Vouchers)
               .HasForeignKey(b => b.SportFieldId);

            modelBuilder.Entity<SportFieldVoucher>()
                .HasOne(s => s.Voucher)
                .WithMany()
                .HasForeignKey(s=>s.VoucherId);
            #endregion
        }
    }
}
