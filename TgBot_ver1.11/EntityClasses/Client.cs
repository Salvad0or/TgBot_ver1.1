using System;
using System.Collections.Generic;

namespace TgBot_ver1._11.EntityClasses
{
    public partial class Client
    {
        public Client()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string? Fname { get; set; }
        public string Phone { get; set; } = null!;
        public DateTime? Date { get; set; }
        public byte? StatusId { get; set; }
        public string? Comment { get; set; }

        public virtual ClientStatus? Status { get; set; }
        public virtual ClientBankAccout? ClientBankAccout { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
