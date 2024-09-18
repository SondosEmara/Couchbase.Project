using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Demoes.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }

}
