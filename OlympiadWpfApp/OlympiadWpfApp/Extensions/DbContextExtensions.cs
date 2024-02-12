using Microsoft.EntityFrameworkCore;

namespace OlympiadWpfApp.Extensions;

public static class DbContextExtensions
{
    public static void RejectChanges(this DbContext dbContext) // https://stackoverflow.com/questions/16437083/dbcontext-discard-changes-without-disposing
    {
        foreach (var entry in dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
}