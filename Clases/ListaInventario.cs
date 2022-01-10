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
    class ListaInventario
    {
        NodoInventario inicio;

        public ListaInventario()
        {
            inicio = null;
        }

        //Es el mismo método InsertarF que la Ing nos enseñó
        public void InsertarF(Inventario item)
        {
            NodoInventario aux = new NodoInventario();
            aux.info_inventario = item;
            aux.sgt = null;

            if (inicio == null)
            {
                inicio = aux;
            }
            else
            {
                NodoInventario puntero = inicio;
                while (puntero.sgt != null)
                {
                    puntero = puntero.sgt;
                }
                puntero.sgt = aux;
            }
        }

        //Hago un recorrido y si encuentra que el DUI es el igual al que mandamos, edita la info del trabajador
        public void Editar(int codigo, Inventario inventario)
        {
            NodoInventario aux = inicio;
            while (aux != null)
            {
                if (aux.info_inventario.Codigo == codigo)
                {
                    aux.info_inventario = inventario;
                }
                aux = aux.sgt;
            }
        }

        //Manda una cola que contiene todos los datos menos el que se quiere borrar
        public Queue<Inventario> EnCola(int codigo)
        {
            Queue<Inventario> cola = new Queue<Inventario>();
            NodoInventario aux = inicio;
            while (aux != null)
            {
                if (aux.info_inventario.Codigo != codigo)
                {
                    cola.Enqueue(aux.info_inventario);
                }
                aux = aux.sgt;
            }
            return cola;
        }

        //Mando una cola con todos los elementos
        public Queue<Inventario> Mostrar()
        {
            NodoInventario aux = inicio;
            Queue<Inventario> cola = new Queue<Inventario>();
            while (aux != null)
            {
                cola.Enqueue(aux.info_inventario);
                aux = aux.sgt;
            }
            return cola;
        }
    }
}
