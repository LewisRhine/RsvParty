using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RsvParty.Models;

namespace RsvParty.Data;

public class RsvpContext(DbContextOptions<RsvpContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Rsvp> Rsvps { get; set; }
}