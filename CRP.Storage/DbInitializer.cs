using System.Data.Entity;
using System.Diagnostics;

namespace CRP.Storage
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<CRPDbContext>
    {
        protected override void Seed(CRPDbContext context)
        {
            Debug.WriteLine("Seed DbInitializer : DropCreateDatabaseIfModelChanges");
            base.Seed(context);
        }
    }
}
