using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Suniukai_MVC_Paskaita.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Vartotojas class
public class Vartotojas : IdentityUser
{
    [PersonalData]
    public string TurimasAugintinis { get; set; }
    public bool IsAdmin { get; set; }
}

