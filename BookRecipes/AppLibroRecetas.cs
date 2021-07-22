using System;
using System.Collections.Generic;

namespace BookRecipes{

    public class AppLibroRecetas{

        public static Libro LibroRecetas = new Libro();

        public static void MensajeDeCierre(){
            Console.WriteLine("Gracias por utilizar nuestra App Libro de Recetas! :)");
        }

        public static void OpcionNoDisponible(){
            Console.WriteLine("----- Esa opción no está disponible :( ... Intenta de nuevo. -----\n");
        }

        public static void NoRecetas(){
            Console.WriteLine("Aun no hay recetas!!! Agrega recetas a tu libro");
        }

        public static int IndexReceta(String action){
            Console.WriteLine(LibroRecetas.ToString());

            Console.Write($"Digite el # de la receta que desea {action} -> ");

            int index = Int32.Parse(Console.ReadLine());

            return index;
        }

        public static void Menu(){
            Console.WriteLine("\nBienvenido a tu libro de recetas, ¿qué deseas hacer?\n" +
            LibroRecetas.ToString() + "\n" +
            "======== Opciones ===========\n" +
            "1. Agregar una receta.\n" +
            "2. Ver una receta.\n" +
            "3. Eliminar una receta.\n" +
            "4. Modificar una receta.\n" +
            "5. Cerrar.\n" +
            "=============================\n"
            );    
        }

        public static void ModificarReceta(){

        if(LibroRecetas.Recetas.Count > 0){
      
            int indexReceta = IndexReceta("modificar");

            Receta aModificar = LibroRecetas.Recetas[indexReceta-1];

            bool finish = false;

            while(!finish){

                Console.WriteLine($"Receta\n{aModificar}\n¿Qué deseas modificar de la receta?");

                Console.WriteLine("1. Nombre de la receta\n" +
                "2. Tipo de comida\n" +
                "3. Tipo de receta\n" +
                "4. Ingredientes\n" +
                "5. Pasos\n" + 
                "6. Regresar al menú principal");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                    aModificar.Nombre = PedirNombreReceta();
                    break;
                    case "2":
                    aModificar.TipoComida = (TipoComida)PedirTipoComida();
                    break;
                    case "3":
                    aModificar.TipoReceta = (TipoReceta)PedirTipoReceta();
                    break;
                    case "4":
                    aModificar.Ingredientes = PedirIngredientes();
                    break;
                    case "5":
                    aModificar.Pasos = PedirPasos();
                    break;
                    case "6":
                    Console.Clear();
                    finish = true;
                    break;
                    default:
                    OpcionNoDisponible();
                    break;
                }


            }

        }else{

            NoRecetas();

        }

        }


        public static void EliminarReceta(){

            if(LibroRecetas.Recetas.Count > 0){
    
            int indexReceta = IndexReceta("eliminar");

            LibroRecetas.EliminarRecetaPorIndice(indexReceta);
            }else{
                NoRecetas();
            }
        }

        public static void VerReceta(){

            if(LibroRecetas.Recetas.Count > 0){

            int numReceta = IndexReceta("ver");

            if(numReceta > 0 && numReceta <= LibroRecetas.Recetas.Count)
            Console.WriteLine(LibroRecetas.obtenerRecetaPorIndice(numReceta));
            else
            Console.WriteLine("Lo sentimos no encontramos ninguna receta con ese numero");
            }else{
                NoRecetas();
            }
        }    

        public static void AgregarReceta(){
        
            string nombre = PedirNombreReceta();

            int tipoComida = PedirTipoComida();

            int tipoReceta = PedirTipoReceta();

            Receta receta = new Receta(nombre,(TipoReceta)tipoReceta,(TipoComida)tipoComida);

            receta.Ingredientes = PedirIngredientes();

            receta.Pasos = PedirPasos();

            LibroRecetas.AgregarReceta(receta);

        }

        public static String PedirNombreReceta(){
            Console.Write("¿Qué nombre le vas a poner a tu receta? -> ");

            String nombre = Console.ReadLine();

            return nombre;
        }

        public static int PedirTipoComida(){
            
            int tipoComida = -1;

            while(tipoComida == -1){

            Console.WriteLine("¿De qué tipo de comida es tu receta?\n" +
            "1. Desayuno\n" + 
            "2. Almuerzo\n" +
            "3. Cena\n" +
            "4. Postre\n");

            string optionTipoComida = Console.ReadLine();

            switch (optionTipoComida)
            {
                case "1":
                tipoComida = ((int)TipoComida.DESAYUNO);
                break;
                case "2":
                tipoComida = ((int)TipoComida.ALMUERZO);
                break;
                case "3":
                tipoComida = ((int)TipoComida.CENA);
                break;
                case "4": 
                tipoComida = ((int)TipoComida.POSTRE);
                break;
                default:
                OpcionNoDisponible();
                break;
            }

            }

            return tipoComida;
        }

        public static int PedirTipoReceta(){
            
            Console.WriteLine("¿Qué tipo de receta es?\n" +
            "1. Sal\n" + 
            "2. Dulce\n" +
            "3. Bebida\n");

            int tipoReceta = -1;

            while(tipoReceta == -1){

                string optionTipoReceta = Console.ReadLine();

                switch (optionTipoReceta)
                {
                    case "1":
                    tipoReceta = ((int)TipoReceta.SAL);
                    break;
                    case "2":
                    tipoReceta = ((int)TipoReceta.DULCE);
                    break;
                    case "3":
                    tipoReceta = ((int)TipoReceta.BEBIDA);
                    break;
                    default:
                    OpcionNoDisponible();
                    break;
                }

            }

            return tipoReceta;
        }

        public static List<Ingrediente> PedirIngredientes(){

            Console.Write("¿Cuántos ingredientes tiene tu receta? -> ");

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            int cantIngredientes = Int32.Parse(Console.ReadLine());
            
            for (int i = 0; i < cantIngredientes; i++)
            {
                Console.Write($"Nombre del ingrediente #{i+1} -> ");
                string nombreIngrediente = Console.ReadLine();
                Console.Write($"Cantidad del ingrediente #{i+1} -> ");
                string cantidadIngrediente = Console.ReadLine();

                ingredientes.Add(new Ingrediente(nombreIngrediente,cantidadIngrediente));    
            }

            return ingredientes;

        }

        public static List<String> PedirPasos(){

            Console.Write("¿En cuántos pasos se prepara esta receta? -> ");

            List<String> pasos = new List<String>();

            int numPasos = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numPasos; i++)
            {
                Console.WriteLine($"Escriba las instrucciones del paso #{i+1}");
                pasos.Add(Console.ReadLine());
            }

            return pasos;

        }


    }
}