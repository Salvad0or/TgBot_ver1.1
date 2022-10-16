using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgBot_ver1._11.EntityClasses
{
    public class Bot
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public long ChatId { get; set; }

        public virtual Client? Cient { get; set; }
    }
}
