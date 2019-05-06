using System;
using Epicor3S.Core.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Epicor3S.OData
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<School>("Schools");
            builder.EntitySet<Student>("Students");
            return builder.GetEdmModel();
        }
    }
}
