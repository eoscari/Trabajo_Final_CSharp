using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.Clases
{
    public class FacturaReal
    {
        private int idFactura;
        private DateTime fechaEmision;
        private DateTime fechaMovimiento;
        private string tipoCambio;
        private string modo;
        //private int DniCliente;//es el dni del cliente
        private int IdNota;
        private int IdCheque;
        string destinatario;
        string originante;
        double monto;
        string moneda;

        //CONSTRUCTOR

        public FacturaReal(int idFact, DateTime fEmision, DateTime fMovimiento, string tip, string mod, int cli, int not, int cheq, double monto, string moneda)
        {
            this.IdFactura = idFact;
            this.fechaEmision = fEmision;
            this.fechaMovimiento = fMovimiento;
            this.tipoCambio = tip;
            this.Modo = mod;
            //this.DniCliente = cli;
            this.IdNota = not;
            this.IdCheque = cheq;
            this.monto = monto;
            this.moneda = moneda;

        }

        //PROPERTIES

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public DateTime FechaMovimiento
        {
            get { return fechaMovimiento; }
            set { fechaMovimiento = value; }
        }

        public string TipoCambio
        {
            get { return tipoCambio; }
            set { tipoCambio = value; }
        }

        public string Modo
        {
            get { return modo; }
            set { modo = value; }
        }

        //public int Cliente
        //{
        //    get { return DniCliente; }
        //    set { DniCliente = value; }
        //}

        public int idNota
        {
            get { return IdNota; }
            set { IdNota = value; }
        }

        public int Cheque
        {
            get { return IdCheque; }
            set { IdCheque = value; }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Originante
        {
            get { return originante; }
            set { originante = value; }
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
        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }

        public int Tamaño //tamaño del registro Persona
        {
            // Longitud en bytes de los atributos (un long = 8 bytes)
            get { return (8 + FormatoFecha(fechaEmision).Length*2 + FormatoFecha(fechaMovimiento).Length * 2 + tipoCambio.Length * 2 + modo.Length * 2 + 8 + 8 + destinatario.Length * 2 + originante.Length * 2 + 16 + moneda.Length * 2); }
        }
    }
}