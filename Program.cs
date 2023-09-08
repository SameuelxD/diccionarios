using System;
using System.Collections.Generic;

namespace addEstudiantes
{
    internal class Program
    {
        static Estudiante estudiante;
        private static void Main(string[] args)
        {
            List<Estudiante> listEstudiantes = new List<Estudiante>();
            bool active = true;

            while (active)
            {
                Console.Clear();
                Console.WriteLine("-------------------- MENU --------------------");
                Console.WriteLine("   1. Agregar Estudiante. ");
                Console.WriteLine("   2. Agregar Notas. ");
                Console.WriteLine("   3. Mostrar Estudiantes. ");
                Console.WriteLine("   4. Cerrar Programa. ");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Digite una opcion: ");
                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("1. Agregar Estudiante.");
                            Estudiante estudiante = AgregarEstudiante();
                            listEstudiantes.Add(estudiante);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("2. Agregar Notas.");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("3. Mostrar Estudiantes.");
                            MostrarEstudiantes(listEstudiantes);
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Cerrando Programa. Presione una tecla para continuar.");
                            Console.ReadLine();
                            active = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
            }
        }

        static Estudiante AgregarEstudiante()
        {
            bool passive = true;
            while(passive)
            {
                Console.Clear();
                Console.WriteLine("------------ Agregar Estudiantes -------------");
                Console.WriteLine("----------------------------------------------");
                Estudiante estudiante = new Estudiante();

                Console.WriteLine("Ingrese Código Numérico (máximo 15 caracteres):");
                estudiante.Codigo = Console.ReadLine();

                while (estudiante.Codigo.Length > 15 || !int.TryParse(estudiante.Codigo, out _))
                {
                    Console.Clear();
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
                Console.WriteLine("Ingrese Direccion (máximo 35 caracteres):");
                estudiante.Direccion = Console.ReadLine();
                while (estudiante.Direccion.Length > 35)
                {
                    Console.WriteLine("¡Error! Direccion Inválida. Ingrese Direccion (máximo 35 caracteres):");
                    estudiante.Direccion = Console.ReadLine();
                }
                Console.WriteLine("Digite enter para volver a ingresar un estudiante o presione cualquier tecla para salir");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                return estudiante;
                passive=(keyInfo.Key == ConsoleKey.Enter);
            }
            return estudiante;
        }
        static void AgregarNotas(List<Estudiante> listEstudiantes)
        {
            Console.WriteLine("---------------- Agregar Notas ---------------");
            Console.WriteLine("   1. Agregar Notas Quizzes.");
            Console.WriteLine("   2. Agregar Notas Trabajos.");
            Console.WriteLine("   3. Agregar Notas Parciales.");
            Console.WriteLine("   4. Volver al Menu Principal.");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Digite una opcion: ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                bool passive=true;
                    while(passive)
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("1. Agregar Notas Quizzes.");
                                VerificarEstudiante(listEstudiantes);
                                /*Quizzes quizz = AgregarQuizzes();
                                listEstudiantes.Add(estudiante);*/
                                break;
                            case 2:
                                Console.WriteLine("2. Agregar Notas Trabajos.");
                                break;
                            case 3:
                                Console.WriteLine("3. Agregar Notas Parciales.");
                                MostrarEstudiantes(listEstudiantes);
                                break;
                            case 4:
                                Console.WriteLine("Volviendo al menu principal. Presione una tecla para continuar.");
                                Console.ReadLine();
                                passive = false;
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Intente de nuevo.");
                                break;
                        }
                    }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo.");
            }
            
            
            /*static void AgregarQuizzes()
            {
                
            }*/
        }
        static void VerificarEstudiante(List<Estudiante> estudiantes)
        {
            Console.WriteLine("Ingrese el codigo del estudiante para verificarlo: ");
            string codigo = Console.ReadLine();
            while (codigo.Length > 15 || !int.TryParse(codigo, out _))
            {
                Console.WriteLine("¡Error! Código Inválido. Ingrese Código Numérico (máximo 15 caracteres):");
                codigo = Console.ReadLine();
            }
            foreach (Estudiante estudiante in estudiantes)
            {
                if(codigo == estudiante.Codigo){
                    Console.WriteLine($"Codigo {codigo} satisfactoriamente encontrado.");
                    break; 
                }
            }
        }

        static void MostrarEstudiantes(List<Estudiante> estudiantes)
        {
            Console.WriteLine("------------- Mostrar Estudiantes -------------");
            Console.WriteLine("{0,-15} {1,-40} {2,-40} {3,-5}", "Código", "Nombre", "Email", "Edad");
            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("{0,-15} {1,-40} {2,-40} {3,-5}", estudiante.Codigo, estudiante.Nombre, estudiante.Email, estudiante.Edad, estudiante.Direccion);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("-----------------------------------------------");    
        }
    }

    internal class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }
}
    internal class Quizzes
    {
        public string Codigo { get; set; }
        public int Nota_1 { get; set; }
        public int Nota_2 { get; set; }
        public int Nota_3 { get; set; }
        public int Nota_4 { get; set; }
    }


/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */
