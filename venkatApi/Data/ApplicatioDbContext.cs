using Microsoft.EntityFrameworkCore;


namespace ApplicationApi.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options) : base(options)
        {

        }
    }
}

