using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Verificar CURP");
        Console.WriteLine("2. Verificar Correo Electrónico");
        Console.Write("Ingrese el número de la opción: ");

        // Lee la opción del usuario
        string opcion = Console.ReadLine();

        // Lógica para seleccionar la expresión regular correcta
        string patron = "";
        if (opcion == "1")
        {
            patron = @"^[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{5}[0-9A-Z]{2}[0-9]{1}$";
        }
        else if (opcion == "2")
        {
            patron = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
        }
        else
        {
            Console.WriteLine("Opción no válida. Saliendo del programa.");
            Console.ReadLine(); // Espera a que el usuario presione Enter
            return;
        }

        bool entradaValida = false;

        // Ciclo para permitir al usuario intentar nuevamente hasta que la entrada sea válida
        while (!entradaValida)
        {
            Console.Write($"Ingrese {(opcion == "1" ? "la CURP" : "el correo electrónico")}: ");
            string entradaUsuario = Console.ReadLine();

            // Verificar la entrada del usuario con la expresión regular
            if (Regex.IsMatch(entradaUsuario, patron))
            {
                entradaValida = true;
                Console.WriteLine($"La {(opcion == "1" ? "CURP" : "dirección de correo electrónico")} es válida.");
            }
            else
            {
                Console.WriteLine($"La {(opcion == "1" ? "CURP" : "dirección de correo electrónico")} no es válida. Inténtelo nuevamente.");
            }
        }

        Console.ReadLine(); // Espera a que el usuario presione Enter antes de salir
    }
}
