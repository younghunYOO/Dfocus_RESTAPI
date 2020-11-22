using RestApiCRUD.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestApiCRUD.Models
{
    public class Employee
    {
        [Key]
        public Guid Id{ get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Position can only be 40 characters long")]
        public string Position { get; set; }

        [Required]
        [JsonConverter(typeof(IntToStringConverter))]
        public int Age { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Introduce can only be 100 characters long")]
        public string Introduce { get; set; }

    }
}
