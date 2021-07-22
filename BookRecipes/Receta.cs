using System;
using System.Collections.Generic;

namespace BookRecipes{

    public class Receta{

        public String Nombre {get; set;}
        public List<Ingrediente> Ingredientes {get; set;}
        public List<String> Pasos {get; set;}
        public TipoReceta TipoReceta {get; set;}
        public TipoComida TipoComida {get; set;}
        
        
        public Receta(String Nombre, TipoReceta TipoReceta, TipoComida TipoComida){

            this.Nombre = Nombre;
            this.TipoReceta = TipoReceta;
            this.TipoComida = TipoComida;

            Ingredientes = new List<Ingrediente>();

            Pasos = new List<String>();

        }

        public override string ToString()
        {
            String receta = $"============= RECETA ==================\n*Nombre: {Nombre}\n*Tipo Receta: {TipoReceta}\n*Tipo Comida: {TipoComida}\n*Ingredientes: \n";

            foreach(var Ingrediente in Ingredientes)
            {
                receta += "\t- " + Ingrediente.ToString()+"\n";
                        
            }

            receta += "Pasos:\n";

            for (int i = 0; i < Pasos.Count; i++)
            {
                receta += $"\t{i+1}. " + Pasos[i] + "\n"; 
            }

            receta += "=======================================";

            return receta;
        }

    }


}