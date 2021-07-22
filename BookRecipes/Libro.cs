using System;
using System.Collections.Generic;

namespace BookRecipes{

    public class Libro{

        public List<Receta> Recetas {get; set;}

        public Libro(){
            Recetas = new List<Receta>();
        }

        public void AgregarReceta(Receta receta){
            Recetas.Add(receta);
        }

        public Receta obtenerRecetaPorIndice(int index){
            return Recetas[index-1];
        }

        public Receta obtenerRecetaPorNombre(String nombre){
            return Recetas.Find(receta => receta.Nombre.ToUpper().Equals(nombre.ToUpper()));
        }

        public void ModificarRecetaPorIndice(Receta NuevaReceta, int index){
            Recetas[index-1] = NuevaReceta;
        }

        public void EliminarRecetaPorIndice(int index){
            if(index-1 < Recetas.Count && index-1 >= 0){
            Recetas.RemoveAt(index-1);
            Console.WriteLine($"Se ha removido la receta #{index} con éxito!");
            }
            else
            Console.WriteLine($"No hay ninguna receta con el número {index}");
        }

        public void EliminarRecetaPorNombre(String nombre){
           Receta MyReceta = obtenerRecetaPorNombre(nombre);

            if(MyReceta != null){
                Recetas.Remove(MyReceta);
            }else{
                Console.WriteLine($"No se ha encontrado ninguna receta con el nombre {nombre}");
            }
        }

        
        public override string ToString()
        {
            String recetas = "\nRecetas\n";

            if(Recetas.Count > 0){
            for (int i = 0; i < Recetas.Count; i++)
            {
                recetas += $"{i+1}. {Recetas[i].Nombre}\n";
            }
            }else{
                recetas += "Aun no hay recetas :( \n";
            }

            return recetas;
        }

    }


}