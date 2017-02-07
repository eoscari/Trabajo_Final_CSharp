using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class MovimientoRecurrente
    {
        DateTime fechaInicio;
        string tipoMovimiento;
        int frecfacturacion;
        int plazoEjecucion;
        int idRecurrente;

        public MovimientoRecurrente(DateTime fechaInicio, string tipoMovimiento, int frecfacturacion, int plazoEjecucion)
        {
            this.tipoMovimiento = tipoMovimiento;
            this.frecfacturacion = frecfacturacion;
            this.fechaInicio = fechaInicio;
            this.plazoEjecucion = plazoEjecucion;
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public string TipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }
        public int Frecfacturacion
        {
            get { return frecfacturacion; }
            set { frecfacturacion = value; }
        }
        public int PlazoEjecucion
        {
            get { return plazoEjecucion; }
            set { plazoEjecucion = value; }
        }
        public int IdRecurrente
        {
            get { return idRecurrente; }
            set { idRecurrente = value; }
        }
    }
}