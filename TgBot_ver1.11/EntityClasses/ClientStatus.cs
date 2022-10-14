using System;
using System.Collections.Generic;

namespace TgBot_ver1._11.EntityClasses
{
    public partial class ClientStatus
    {
        public ClientStatus()
        {
            Clients = new HashSet<Client>();
        }

        public byte Id { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
