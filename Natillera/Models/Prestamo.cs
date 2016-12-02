using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Natillera.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicial { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        public double Valor { get; set; }
        public float Porcentaje { get; set; }
        public int usuarioID { get; set; }
        public virtual Usuario usuario { get; set; }                       
        public virtual ObservableCollection<ControlPagos> pagos { get; set; }
    }
}