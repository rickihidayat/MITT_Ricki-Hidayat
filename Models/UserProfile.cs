using System;

#nullable disable

namespace MITT_Ricki_Hidayat.Models
{
    public partial class UserProfile
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Bod { get; set; }
        public string Email { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
