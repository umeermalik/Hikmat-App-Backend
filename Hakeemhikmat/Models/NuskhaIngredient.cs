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
    
    public partial class NuskhaIngredient
    {
        public int id { get; set; }
        public Nullable<int> nuskha_id { get; set; }
        public Nullable<int> ingredient_id { get; set; }
        public Nullable<int> quanity { get; set; }
        public string unit { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Nuskha Nuskha { get; set; }
    }
}
