using System;
using System.Collections.Generic;

namespace TgBot_ver1._11.EntityClasses
{
    public partial class CarCharacteristic
    {
        public string? Oil { get; set; }
        public string? OilFilter { get; set; }
        public string? AirFilter { get; set; }
        public string? SalonFilter { get; set; }
        public string? Сandles { get; set; }
        public string? PadsFront { get; set; }
        public string? PadsRear { get; set; }
        public string? FuelFilter { get; set; }
        public int? CarId { get; set; }
        public int Id { get; set; }

        public virtual Car? Car { get; set; }
    }
}
