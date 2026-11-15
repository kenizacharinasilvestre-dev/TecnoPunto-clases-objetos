using System;
using System.Collections.Generic;
using System.Text;



    using System;

    namespace TecnoPuntoInventario
    {
        public class Producto
        {
            // Campos privados de respaldo para las validaciones
            private string _codigo;
            private string _nombre;
            private decimal _precio;
            private int _cantidad;

            // Propiedades con validación en el bloque set
            public string Codigo
            {
                get { return _codigo; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("El código del producto no puede estar vacío.");
                    }
                    _codigo = value.Trim();
                }
            }

            public string Nombre
            {
                get { return _nombre; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("El nombre del producto no puede estar vacío.");
                    }
                    _nombre = value.Trim();
                }
            }

            public decimal Precio
            {
                get { return _precio; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("El precio debe ser mayor que 0.");
                    }
                    _precio = value;
                }
            }

            public int Cantidad
            {
                get { return _cantidad; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("La cantidad en existencia no puede ser negativa.");
                    }
                    _cantidad = value;
                }
            }

            // Propiedad de solo lectura calculada automáticamente
            public decimal ValorTotal
            {
                get { return Precio * Cantidad; }
            }

            // Constructor que inicializa el objeto pasando por las validaciones de las propiedades
            public Producto(string codigo, string nombre, decimal precio, int cantidad)
            {
                Codigo = codigo;
                Nombre = nombre;
                Precio = precio;
                Cantidad = cantidad;
            }

            // Método para imprimir los datos formateados en consola
            public void MostrarInfo()
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Código:      {Codigo}");
                Console.WriteLine($"Producto:    {Nombre}");
                Console.WriteLine($"Precio:      {Precio:C2}");
                Console.WriteLine($"Cantidad:    {Cantidad} unidades");
                Console.WriteLine($"Valor Total: {ValorTotal:C2}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }

