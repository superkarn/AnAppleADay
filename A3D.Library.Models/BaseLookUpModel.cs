﻿namespace A3D.Library.Models
{
    /// <summary>
    /// This is the base class for the application models.
    /// </summary>
    public abstract class BaseLookUpModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
