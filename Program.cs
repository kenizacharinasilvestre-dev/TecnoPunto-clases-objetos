
           
using System;

namespace TecnoPuntoInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Inventario - TecnoPunto";

            Console.WriteLine("========================================");
            Console.WriteLine("       REGISTRO DE INVENTARIO");
            Console.WriteLine("             TECNOPUNTO");
            Console.WriteLine("========================================");

            // Registro de los tres productos
            Producto producto1 = RegistrarProducto(1);
            Producto producto2 = RegistrarProducto(2);
            Producto producto3 = RegistrarProducto(3);

            // Mostrar los productos registrados
            Console.WriteLine("\n========================================");
            Console.WriteLine("       RESUMEN DEL INVENTARIO");
            Console.WriteLine("========================================");

            producto1.MostrarInfo();
            producto2.MostrarInfo();
            producto3.MostrarInfo();

            // Sumar el valor de todos los productos
            decimal valorTotalInventario =
                producto1.ValorTotal +
                producto2.ValorTotal +
                producto3.ValorTotal;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"VALOR TOTAL DEL INVENTARIO: {valorTotalInventario:C2}");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Solicitar los datos de cada producto
        static Producto RegistrarProducto(int numero)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"\n--- REGISTRO DEL PRODUCTO {numero} ---");

                    Console.Write("Código del producto: ");
                    string codigo = Console.ReadLine() ?? "";

                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine() ?? "";

                    Console.Write("Precio unitario: ");
                    string entradaPrecio = Console.ReadLine() ?? "";

                    if (!decimal.TryParse(entradaPrecio, out decimal precio))
                    {
                        throw new FormatException();
                    }

                    Console.Write("Cantidad en existencia: ");
                    string entradaCantidad = Console.ReadLine() ?? "";

                    if (!int.TryParse(entradaCantidad, out int cantidad))
                    {
                        throw new FormatException();
                    }

                    // Crear el producto con los datos introducidos
                    Producto nuevoProducto = new Producto(
                        codigo, nombre, precio, cantidad);

                    Console.WriteLine("Producto registrado exitosamente.");

                    return nuevoProducto;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nDato inválido: " + ex.Message);
                    Console.WriteLine("Intente nuevamente.\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nDebe introducir un valor numérico válido.");
                    Console.WriteLine("Intente nuevamente.\n");
                }
            }
        }
    }
