using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Core.Model
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string EmployeeAcenumber { get; set; }
        public int SpaceId { get; set; }
        public string? VehicalRegistrationNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ReservationDate { get; set; }
        public Nullable<int> TotalHours { get; set; }

    }
}
