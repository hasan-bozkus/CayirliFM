using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.AppUserDtos
{
    public class CreateLoginAppUserDto
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
