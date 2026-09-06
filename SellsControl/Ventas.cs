using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellsControl
{
    class Ventas
    {

        private string _producto;
        private int _cantidad;


        public string producto 
        {
        
            get {  return _producto; }
            set { _producto = value; }
        
        }


        public int cantidad
        {

            get { return _cantidad; }
            set { _cantidad = value;}

        }


        //asignacion de precio de los productos 

        public double AsignarPrecio()
        {

            switch (producto)
            {

                case "Teclado":  return 35;
                case "Impresora": return 350;
                case "Monitor": return 550;
                case "Bocinas": return 50;
                case "Mouses": return  20;
            }
            return 0;

        }

        public double SubTotal()
        {

            return AsignarPrecio() * cantidad;

        }

       public double Descuento()
        {

            double subtotal = SubTotal();

            if (subtotal <= 300) return 5.0 / 100 * subtotal;
            else if (subtotal > 300 && subtotal <= 500) return 10.0 / 100 * subtotal;
            else return 12.5 / 100 * subtotal;  
        }


    public double Neto()
    {

            return SubTotal() - Descuento();

    }

    }
}
