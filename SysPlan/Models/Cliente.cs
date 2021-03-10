using System;
using System.ComponentModel.DataAnnotations;

namespace SysPlan.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }


    }
}
