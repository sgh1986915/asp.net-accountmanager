//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServerDatabase
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public int DatabaseId { get; set; }
    
        public virtual Database Database { get; set; }
        public virtual Server Server { get; set; }
    }
}
