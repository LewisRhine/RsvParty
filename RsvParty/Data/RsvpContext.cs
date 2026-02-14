using Microsoft.EntityFrameworkCore;
using RsvParty.Models;

namespace RsvParty.Data;

public class RsvpContext(DbContextOptions<RsvpContext> options) : DbContext(options)
{
    public DbSet<Rsvp> Rsvps { get; set; }
}