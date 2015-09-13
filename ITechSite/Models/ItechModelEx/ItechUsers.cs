using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(ItechUsersData))]
    public partial class ItechUsers
    {

    }


    public class ItechUsersData
    {
        [Unique]
        public string UserId { get; set; }
    }
}