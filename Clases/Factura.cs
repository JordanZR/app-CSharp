using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario
{
    class Factura
    {
        private int cantidad, idfactura;
        private double costo;
        private string producto;

        public int Idfactura
        {
            get { return idfactura; }
            set { idfactura = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
      
        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        //Metodos traidos de factura 2

        double valor_mano_obra, costo_total;
      
        string descripcion_mano_obra;

     
     
        public string Descripcion_mano_obra
        {
            get { return descripcion_mano_obra; }
            set { descripcion_mano_obra = value; }
        }
     
        public double Valor_mano_obra
        {
            get { return valor_mano_obra; }
            set { valor_mano_obra = value; }
        }
        public double Costo_total
        {
            get { return costo_total; }
            set { costo_total = value; }
        }
    }
}
