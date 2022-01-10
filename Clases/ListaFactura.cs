using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario
{
    class ListaFactura
    {
        NodoFactura inicio;

        public ListaFactura()
        {
            inicio = null;
        }

        //Es el mismo método InsertarF que la Ing nos enseñó
        public void InsertarF(Factura item)
        {
            NodoFactura aux = new NodoFactura();
            aux.info_factura = item;
            
            aux.sgt = null;

            if (inicio == null)
            {
                inicio = aux;
                
            }
            else
            {
                NodoFactura puntero = inicio;
                while (puntero.sgt != null)
                {
                    puntero = puntero.sgt;
                    
                }
                puntero.sgt = aux;
               
            }
        }

        //Hago un recorrido y si encuentra que el DUI es el igual al que mandamos, edita la info del trabajador
        
        public void Editar(int codigo, Factura factura)
        {
            NodoFactura aux = inicio;
            while (aux != null)
            {
                if (aux.info_factura.Idfactura == codigo)
                {
                    aux.info_factura = factura;
                }
                aux = aux.sgt;
            }
        }
        
        //Manda una cola que contiene todos los datos menos el que se quiere borrar
        public Queue<Factura> EnCola(int codigo)
        {
            Queue<Factura> cola = new Queue<Factura>();
            NodoFactura aux = inicio;
          
             while (aux != null)
            {
                if (aux.info_factura.Idfactura != codigo)
                {
                    cola.Enqueue(aux.info_factura);
                }
                aux = aux.sgt;
            }
            return cola;
        }

        //Mando una cola con todos los elementos
        public Queue<Factura> Mostrar()
        {
            NodoFactura aux = inicio;
            Queue<Factura> cola = new Queue<Factura>();
            while (aux != null)
            {
                cola.Enqueue(aux.info_factura);
                aux = aux.sgt;
            }
            return cola;
        }
    }
}
