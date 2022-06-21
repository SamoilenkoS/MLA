using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}:{Id}{Environment.NewLine}" +
                $"{nameof(FirstName)}:{FirstName}{Environment.NewLine}" +
                $"{nameof(LastName)}:{LastName}{Environment.NewLine}" +
                $"{nameof(Phone)}:{Phone}";
        }
    }
}
