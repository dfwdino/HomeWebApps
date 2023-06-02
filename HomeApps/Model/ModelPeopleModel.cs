using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Model
{
    public class ModelPeopleModel : ModelPeople
    {
        public List<SocialSite> SocialSitesForModels { get; set; }
    }
}
