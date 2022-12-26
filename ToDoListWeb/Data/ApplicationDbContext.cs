using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListWeb.Models;

namespace ToDoListWeb.Data;

public class ApplicationDbContext:IdentityDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
    public DbSet<Category> Categories { get; set;}


}
 