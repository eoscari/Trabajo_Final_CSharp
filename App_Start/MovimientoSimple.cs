using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class MovimientoSimple
    {
        string tipoMovimiento;
        string moneda;
        double monto;
        int idFactura;

        public MovimientoSimple(string tipoMovimiento, string moneda, double monto, int idFactura)
        {
            this.tipoMovimiento = tipoMovimiento;
            this.moneda = moneda;
            this.monto= monto;
            this.idFactura = idFactura;
        }
        public string TipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
    }
}