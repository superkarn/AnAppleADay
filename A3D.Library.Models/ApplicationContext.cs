using System.Collections.Generic;

namespace A3D.Library.Models
{
    public class ApplicationContext
    {
        // TODO add more data for context

        public ApplicationUser CurrentUser { get; set; }

        public IDictionary<string, object> Data { get; set; }
    }
}
