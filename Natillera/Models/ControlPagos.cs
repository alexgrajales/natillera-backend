using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Natillera.Models
{
    public class ControlPagos
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public int usuarioID { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}