using System;

namespace BookRecipes
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.Clear();
            bool isClosed = false;
            
            while(!isClosed){
                AppLibroRecetas.Menu();
                string option = Console.ReadLine();
            
                switch (option)
                {
                    case "1":
                    Console.Clear();
                    AppLibroRecetas.AgregarReceta();
                    break;
                    case "2":
                    Console.Clear();
                    AppLibroRecetas.VerReceta();
                    break;
                    case "3":
                    Console.Clear();
                    AppLibroRecetas.EliminarReceta();
                    break;
                    case "4":
                    Console.Clear();
                    AppLibroRecetas.ModificarReceta();
                    break;
                    case "5":
                    AppLibroRecetas.MensajeDeCierre();
                    isClosed = true;
                    break;
                    default:
                    Console.Clear();
                    AppLibroRecetas.OpcionNoDisponible();
                    break;
                }


            }
        }
    }
}
