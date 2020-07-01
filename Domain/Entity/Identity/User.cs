using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.Identity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string SignImage  { get; set; }
        public string PortraitImage { get; set; }
        public string PosterImage { get; set; }
        public string BackgroundImage { get; set; }
    }
}
