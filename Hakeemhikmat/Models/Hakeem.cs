//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hakeemhikmat.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hakeem
    {
        public int id { get; set; }
        public Nullable<int> hakeem_id { get; set; }
        public string Experiences { get; set; }
    
        public virtual User User { get; set; }
    }
}
