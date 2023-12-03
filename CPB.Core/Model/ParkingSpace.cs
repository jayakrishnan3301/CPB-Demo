using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CPB.Core.Model
{
    public class ParkingSpace
    {
        [Key]
        public int SpaceId { get; set; }
        public int SpaceNumber { get; set; }
        public bool IsOccupied { get; set; }
    }
}
