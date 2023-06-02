using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class AddModel
    {
        public AddModel()
        {
            this.ModelSocialSites = new List<ModelSocialSite>();
        }

        public int ModelID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> ModfiyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> AllNudes { get; set; }
        public Nullable<bool> AllBoudoir { get; set; }
        public Nullable<bool> AllErotica { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<ModelSocialSite> ModelSocialSites { get; set; }
    }
}
