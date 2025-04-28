using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopcionMascotas.Models
{
    public class Adopcion
    {
         [Key]
         public int AdopcionId { get; set; }
 
         [ForeignKey("Mascota")]
         public int MascotaId { get; set; }
         public Mascota Mascota { get; set; }
 
         [ForeignKey("Adoptante")]
         public int AdoptanteId { get; set; }
         public Adoptante Adoptante { get; set; }
 
         [Required]
         public string Estado { get; set; } // Finalizada o Pendiente
    }
}