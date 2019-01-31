using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface ILookUpService
    {
        /// <summary>
        /// Returns a dictionary of all {lookup-name, list-of-lookup-values}
        /// </summary>
        /// <returns></returns>
        IDictionary<string, IEnumerable<BaseLookUpModel>> GetAll();
    }
}
