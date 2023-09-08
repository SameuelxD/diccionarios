using System;
using System.Collections.Generic;

namespace addEstudiantes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Estudiante> listEstudiantes = new List<Estudiante>();
            bool active = true;

            while (active)
            {
                Console.WriteLine("-------------------- MENU --------------------");
                Console.WriteLine("   1. Agregar Estudiante. ");
                Console.WriteLine("   2. Agregar Notas. ");
                Console.WriteLine("   3. Mostrar Estudiantes. ");
                Console.WriteLine("   4. Cerrar Programa. ");
                Console.WriteLine("----------------------------------------------");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("1. Agregar Estudiante");
                            Estudiante estudiante = AgregarEstudiante();
                            listEstudiantes.Add(estudiante);
                            break;
                        case 2:
                            Console.WriteLine("2. Agregar Notas");
                            break;
                        case 3:
                            Console.WriteLine("3. Mostrar Estudiantes");
                            MostrarEstudiantes(listEstudiantes);
                            break;
                        case 4:
                            Console.WriteLine("Cerrando Programa. Presione una tecla para continuar.");
                            Console.ReadLine();
                            active = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
            }
        }

        static Estudiante AgregarEstudiante()
        {
            Estudiante estudiante = new Estudiante();

            Console.WriteLine("Ingrese Código Numérico (máximo 15 caracteres):");
            estudiante.Codigo = Console.ReadLine();

            while (estudiante.Codigo.Length > 15 || !int.TryParse(estudiante.Codigo, out _))
            {
                Console.WriteLine("¡Error! Código Inválido. Ingrese Código Numérico (máximo 15 caracteres):");
                estudiante.Codigo = Console.ReadLine();
            }

            Console.WriteLine("Ingrese Nombre (máximo 40 caracteres):");
            estudiante.Nombre = Console.ReadLine();

            while (estudiante.Nombre.Length > 40)
            {
                Console.WriteLine("¡Error! Nombre Inválido. Ingrese Nombre (máximo 40 caracteres):");
                estudiante.Nombre = Console.ReadLine();
            }

            Console.WriteLine("Ingrese Email (máximo 40 caracteres):");
            estudiante.Email = Console.ReadLine();

            while (estudiante.Email.Length > 40)
            {
                Console.WriteLine("¡Error! Email Inválido. Ingrese Email (máximo 40 caracteres):");
                estudiante.Email = Console.ReadLine();
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese Edad:");
                    estudiante.Edad = int.Parse(Console.ReadLine());

                    if (estudiante.Edad > 100 || estudiante.Edad <= 0)
                    {
                        Console.WriteLine("¡Error! Edad Inválida.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("¡Error! Edad Inválida.");
                }
            }

            return estudiante;
        }
        static void AgregarNotas()
        {
            
        }

        static void MostrarEstudiantes(List<Estudiante> estudiantes)
        {
            Console.WriteLine("{0,-15} {1,-40} {2,-40} {3,-5}", "Código", "Nombre", "Email", "Edad");
            
            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("{0,-15} {1,-40} {2,-40} {3,-5}", estudiante.Codigo, estudiante.Nombre, estudiante.Email, estudiante.Edad);
            }
        }
    }

    internal class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
    }
}



/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */
