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
    
    public partial class NuskhaDisease
    {
        public int id { get; set; }
        public Nullable<int> disease_id { get; set; }
        public Nullable<int> nuskha_id { get; set; }
    
        public virtual NuskhaDisease NuskhaDisease1 { get; set; }
        public virtual NuskhaDisease NuskhaDisease2 { get; set; }
    }
}
