using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApps.Model
{
    public class CameraModel
    {
        public int ModelID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> ModfiyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> AllNudes { get; set; }
        public Nullable<bool> AllBoudoir { get; set; }
        public Nullable<bool> AllErotica { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<ModelSocialSite> ModelSocialSites { get; set; }
        public virtual ICollection<ModelImage> ModelImages { get; set; }
    }
}
