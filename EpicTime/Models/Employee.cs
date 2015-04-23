using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EpicTime.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}