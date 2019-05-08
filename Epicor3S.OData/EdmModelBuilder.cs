using Epicor3S.Core.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Epicor3S.OData
{
    public class EdmModelBuilder
    {
        public IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<School>(nameof(School))
                .EntityType
                .Filter() // Allow for the $filter Command
                .Count() // Allow for the $count Command
                .Expand() // Allow for the $expand Command
                .OrderBy() // Allow for the $orderby Command
                .Page() // Allow for the $top and $skip Comman
                .Select()// Allow for the $select Command;
                .HasMany(x => x.Students)
                .Expand();

            builder.EntitySet<Student>("Students")
                .EntityType
                .Filter() // Allow for the $filter Command
                .Count() // Allow for the $count Command
                .Expand() // Allow for the $expand Command
                .OrderBy() // Allow for the $orderby Command
                .Page() // Allow for the $top and $skip Comman
                .Select();// Allow for the $select Command;

            return builder.GetEdmModel();
        }
    }
}
