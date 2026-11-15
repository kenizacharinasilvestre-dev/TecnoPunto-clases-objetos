using System;
using System.Collections.Generic;

namespace TecnoPuntoInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Inventario - TecnoPunto";
            List<Producto> inventario = new List<Producto>();
            const int cantidadProductosARegistrar = 3;

            Console.WriteLine("==================================================");
            Console.WriteLine("       REGISTRO DE INVENTARIO - TECNOPUNTO        ");
            Console.WriteLine("==================================================\n");

            // Bucle para registrar al menos 3 productos
            for (int i = 0; i < cantidadProductosARegistrar; i++)
            {
                Console.WriteLine($"\n--- Ingresando datos del Producto #{i + 1} ---");
                bool productoValido = false;

                while (!productoValido)
                {
                    try
                    {
                        Console.Write("Código del producto: ");
                        string codigo = Console.ReadLine();

                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Precio unitario: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                        {
                            throw new FormatException("El precio debe ser un valor numérico válido.");
                        }

                        Console.Write("Cantidad en existencia: ");
                        if (!int.TryParse(Console.ReadLine(), out int cantidad))
                        {
                            throw new FormatException("La cantidad debe ser un número entero válido.");
                        }

                        // Se instancia el producto; si algo falla, salta al bloque catch
                        Producto nuevoProducto = new Producto(codigo, nombre, precio, cantidad);
                        inventario.Add(nuevoProducto);

                        productoValido = true;
                        Console.WriteLine("-> ¡Producto registrado exitosamente!");
                    }
                    catch (ArgumentException ex)
                    {
                        // Captura los errores de validación de las propiedades (nombre vacío, precio <= 0, etc.)
                        Console.WriteLine($"\n[ERROR DE VALIDACIÓN]: {ex.Message} Intente nuevamente.\n");
                    }
                    catch (FormatException ex)
                    {
                        // Captura errores cuando se escriben letras en campos numéricos
                        Console.WriteLine($"\n[ERROR DE FORMATO]: {ex.Message} Intente nuevamente.\n");
                    }
                    catch (Exception ex)
                    {
                        // Captura cualquier otro error inesperado
                        Console.WriteLine($"\n[ERROR INESPERADO]: {ex.Message} Intente nuevamente.\n");
                    }
                }
            }

            // Mostrar toda la información de los productos registrados
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("         RESUMEN DE INVENTARIO REGISTRADO         ");
            Console.WriteLine("==================================================\n");

            decimal valorTotalInventario = 0;

            foreach (Producto prod in inventario)
            {
                prod.MostrarInfo();
                valorTotalInventario += prod.ValorTotal;
            }

            Console.WriteLine($"\nVALOR TOTAL GENERAL DEL INVENTARIO: {valorTotalInventario:C2}");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
