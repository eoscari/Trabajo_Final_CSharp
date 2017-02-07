using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Trabajo_final_csharp.Clases;

namespace Trabajo_final_csharp.App_Start
{
    public class ListaFacturaReal
    {
        private FileStream fs;          // flujo subyacente
        private BinaryWriter bw;        // flujo hacia el fichero
        private BinaryReader br;        // flujo desde el fichero
        private int nregs;              // número de registros
        private int tamañoReg = 130;    // tamaño del registro en bytes

        //CONSTRUCTOR
        public ListaFacturaReal(String fichero)
        {
            abrirFichero(fichero);
        }

        public void abrirFichero(String path)
        {
            if (Directory.Exists(path))
                throw new IOException(Path.GetFileName(path) + " no es un fichero");
            fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            this.nregs = (int)Math.Ceiling((double)fs.Length / (double)this.tamañoReg);
        }

        public void CerrarFichero() { bw.Close(); br.Close(); fs.Close(); }

        public int Registro
        {
            get { return this.nregs; }
        }

        public void agregarRegistro(FacturaReal obj)
        {
            if (EscribirRegistro(this.nregs, obj))
                this.nregs++;
        }

        public bool EscribirRegistro(int i, FacturaReal fac)
        {
            try
            {
                if (i >= 0 && i <= nregs)
                {
                    if (fac.Tamaño + 4 > tamañoReg)
                    {
                        Console.WriteLine("Tamaño de registro excedido.");
                        return false;
                    }
                    else
                    {
                        bw.BaseStream.Seek(i * this.tamañoReg, SeekOrigin.Begin);
                        bw.Write(fac.IdFactura);
                        bw.Write(fac.FechaEmision.ToString());//lo mando al dato datetime a string para poder guardarlo en el fichero
                        bw.Write(fac.FechaMovimiento.ToString());
                        bw.Write(fac.TipoCambio);
                        bw.Write(fac.Modo);
                        //estos son los id`s de cliente nota y cheques los gaurdo en el fichero
                        //bw.Write(fac.Cliente);
                        bw.Write(fac.idNota);
                        bw.Write(fac.Cheque);
                        bw.Write(fac.Destinatario);
                        bw.Write(fac.Originante);
                        bw.Write(fac.Monto);
                        bw.Write(fac.Moneda);                      
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }

        public FacturaReal LeerReg(int i)//lee registro mandandole la posicion
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
                int idFactura = br.ReadInt32();
                string fechaEmision = br.ReadString();
                string fechaCobro = br.ReadString();
                string tipo = br.ReadString();
                string modo = br.ReadString();
                int IdCliente = br.ReadInt32();
                int idnota = br.ReadInt32();
                int idcheque = br.ReadInt32();
                return (new FacturaReal(idFactura, Convert.ToDateTime(fechaEmision), Convert.ToDateTime(fechaCobro), tipo, modo, IdCliente, idnota, idcheque));
            }
            else { return null; }
        }

        //BUSCA POR ID DE LA FACTURA y devuelve la posicion en el fichero
        public int BuscarReg(int IDFactura)
        {
            FacturaReal obj;
            int ide;
            int reg_i = 0;
            bool encontrado = false;

            if (IDFactura < 0) { return -1; }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerReg(reg_i);
                    ide = obj.IdFactura;
                    if (ide == IDFactura)
                    {
                        encontrado = true;
                    }
                    else { reg_i++; }
                }

                if (encontrado)
                {
                    return reg_i;
                }
                else
                {
                    return -1;
                }
            }
        }

        //BUSCA POR DOCUMENT0 DE CLIENTE y devuelve la posicion en el fichero de la factura
        //public int BuscarClienteReg(long dni)
        //{
        //    FacturaReal obj;
        //    long num;
        //    int reg_i = 0;
        //    bool encontrado = false;
        //    try
        //    {
        //        if (dni < 0) { return -1; }
        //        else
        //        {
        //            while ((reg_i <= nregs) && (!encontrado))
        //            {
        //                obj = LeerReg(reg_i);
        //                //num = obj.Cliente;
        //                if (num == dni)
        //                {
        //                    encontrado = true;
        //                }
        //                else
        //                { reg_i++; }
        //            }
        //            if (encontrado)
        //            {
        //                return reg_i;
        //            }
        //            else
        //            {
        //                return -1;
        //            }
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        CerrarFichero(); Console.WriteLine("error:" + e.Message); return -1;
        //    }
        //}
        //BUSCA NOTA POR ID
        //public int BuscarNotaReg(int idnota)
        //{

            //FacturaReal obj;
            //int num;
            //int reg_i = 0;
            //bool encontrado = false;

            //if (idnota < 0) return -1;
            //while ((reg_i < nregs) && (!encontrado))
            //{
            //    obj = LeerReg(reg_i);
            //    num = obj.Nota;
            //    if (num == idnota)
            //    {
            //        encontrado = true;
            //    }
            //    else
            //        reg_i++;
            //}
            //if (encontrado)
            //{
            //    return reg_i;
            //}
            //else
            //{
            //    return -1;
            //}
        //}
        //BUSCAR CHEQUE POR ID
        //public int BuscarChequeReg(int idcheque)
        //{
        //    clsFactura obj;
        //    int num;
        //    int reg_i = 0;
        //    bool encontrado = false;

        //    if (idcheque < 0) return -1;
        //    while ((reg_i < nregs) && (!encontrado))
        //    {
        //        obj = LeerReg(reg_i);
        //        num = obj.Cheque;
        //        if (num == idcheque)
        //        {
        //            encontrado = true;
        //        }
        //        else
        //            reg_i++;
        //    }
        //    if (encontrado)
        //    {
        //        return reg_i;
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        public int devuelve_pos()
        {
            br.BaseStream.Seek(-this.tamañoReg, SeekOrigin.End);
            int idFactura = br.ReadInt32();
            return idFactura;
        }
    }
}