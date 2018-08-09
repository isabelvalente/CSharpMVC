using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [DisplayName ("Repository Link")]
        public string RepositoryLink { get; set; }
        public string Language { get; set; }

    }
}