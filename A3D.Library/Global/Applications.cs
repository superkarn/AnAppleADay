using System;
using System.Collections.Generic;
using System.Text;

namespace A3D.Library.Global
{
    public class Application
    {
        public string Name;
        public string BaseUrl;

        public static Application Api { get; set; } = new Application
        {
            Name = "Api",
            BaseUrl = "https://localhost:44385" // TODO figure out how to un-hardcode this
        };

        public static Application Authentication { get; set; } = new Application
        {
            Name = "Authentication",
            BaseUrl = "https://localhost:44311" // TODO figure out how to un-hardcode this
        };

        public static Application Web { get; set; } = new Application
        {
            Name = "Web",
            BaseUrl = "https://localhost:44359" // TODO figure out how to un-hardcode this
        };

        /// <summary>
        /// List of available applications
        /// </summary>
        public static IEnumerable<Application> Values
        {
            get { return new[] { Api, Authentication, Web }; }
        }

        /// <summary>
        /// Convert Application to string
        /// </summary>
        /// <param name="application"></param>
        public static explicit operator string(Application application)
        {
            return application.Name.ToLower();
        }

        /// <summary>
        /// Convert string to Application
        /// </summary>
        /// <param name="application"></param>
        public static explicit operator Application(string application)
        {
            return new Application { Name = application };
        }
    }
}
