using System;

namespace BookRecipes{

    public class Ingrediente{

        public String Nombre {get; set;}
        public String Cantidad {get; set;}

        public Ingrediente(String Nombre, String Cantidad){
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} | Cantidad: {Cantidad}";
        }

    }


}