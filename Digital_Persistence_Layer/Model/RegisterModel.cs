using Npgsql.Internal.Postgres;
using System.ComponentModel.DataAnnotations;

namespace Digital_Persistence_Layer.Model
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
        public string ConfirmPassword { get; set; }

    }
}
