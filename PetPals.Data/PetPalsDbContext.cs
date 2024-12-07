using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetPals.Data.Models;

namespace PetPals.Data;

public class PetPalsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public PetPalsDbContext(DbContextOptions<PetPalsDbContext> options)
        : base(options)
    {

    }


    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<AdoptionRequest> AdoptionRequests { get; set; } = null!;
    public DbSet<Donation> Donations { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Volunteer> Volunteers { get; set; } = null!;
    public DbSet<Feedback> Feedbacks { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
