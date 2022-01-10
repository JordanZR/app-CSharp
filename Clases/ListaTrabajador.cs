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
    class ListaTrabajador
    {
        NodoTrabajador inicio;

        public ListaTrabajador()
        {
            inicio = null;
        }

        //Es el mismo método InsertarF que la Ing nos enseñó
        public void InsertarF(Trabajadores item)
        {
            NodoTrabajador aux = new NodoTrabajador();
            aux.info_traba = item;
            aux.sgt = null;

            if (inicio == null)
            {
                inicio = aux;
            }
            else
            {
                NodoTrabajador puntero = inicio;
                while (puntero.sgt != null)
                {
                    puntero = puntero.sgt;
                }
                puntero.sgt = aux;
            }
        }

        //Hago un recorrido y si encuentra que el DUI es el igual al que mandamos, edita la info del trabajador
        public void Editar(string dui, Trabajadores trabajador)
        {
            NodoTrabajador aux = inicio;
            while (aux != null)
            {
                if (aux.info_traba.Dui == dui)
                {
                    aux.info_traba = trabajador;
                }
                aux = aux.sgt;
            }
        }

        //Manda una cola que contiene todos los datos menos el que se quiere borrar
        public Queue<Trabajadores> EnCola(string dui)
        {
            Queue<Trabajadores> cola = new Queue<Trabajadores>();
            NodoTrabajador aux = inicio;
            while (aux != null)
            {
                if (aux.info_traba.Dui != dui)
                {
                    cola.Enqueue(aux.info_traba);
                }
                aux = aux.sgt;
            }
            return cola;
        }

        //Mando una cola con todos los elementos
        public Queue<Trabajadores> Mostrar()
        {
            NodoTrabajador aux = inicio;
            Queue<Trabajadores> cola = new Queue<Trabajadores>();
            while (aux != null)
            {
                cola.Enqueue(aux.info_traba);
                aux = aux.sgt;
            }
            return cola;
        }
    }
}
