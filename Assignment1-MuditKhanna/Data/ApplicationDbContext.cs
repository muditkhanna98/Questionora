using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_MuditKhanna.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
    }
}