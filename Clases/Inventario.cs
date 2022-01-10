using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario
{
    class Inventario
    {
        int codigo;
        int existencia;

        string descripcion, ruta_imagen;

        double precio_compra, precio_venta;
        public int Codigo { get => codigo; set => codigo = value; }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Ruta_imagen
        {
            get { return ruta_imagen; }
            set { ruta_imagen = value; }
        }

        public double Precio_compra
        {
            get { return precio_compra; }
            set { precio_compra = value; }
        }

        public double Precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }

        
    }
}
