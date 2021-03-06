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
    
    public partial class Enterprise
    {
        public Enterprise()
        {
            this.Database = new HashSet<Database>();
            this.UserEnterprise = new HashSet<UserEnterprise>();
            this.Server = new HashSet<Server>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public Nullable<int> MaxFemales { get; set; }
        public string Config { get; set; }
        public string Culture { get; set; }
        public int OwnerUserId { get; set; }
        public string SharedFileSystemId { get; set; }
        public string EnterpriseCode { get; set; }
        public Nullable<int> DefaultServerId { get; set; }
        public Nullable<System.DateTime> NextRenewalDate { get; set; }
        public int MaxWebUsers { get; set; }
        public int MaxRemoteAppUsers { get; set; }
        public bool ManagedWebServer { get; set; }
        public int Tier { get; set; }
        public int ConsultantLicenses { get; set; }
        public int DesktopLicenses { get; set; }
        public int MobileLicenses { get; set; }
        public int ServerAndDesktopLicenses { get; set; }
        public Nullable<int> ResellerUserId { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual ICollection<Database> Database { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<UserEnterprise> UserEnterprise { get; set; }
        public virtual ICollection<Server> Server { get; set; }
    }
}
