using System;
using System.Collections.Generic;

internal class Program
{
    static Dictionary<string, Notas> dictNotas = new Dictionary<string, Notas>();

    private static void Main(string[] args)
    {
        bool active = true;
        while (active)
        {
            Console.Clear();
            Console.WriteLine("-------------------- MENU --------------------");
            Console.WriteLine("   1. Agregar Estudiante.");
            Console.WriteLine("   2. Agregar Notas Quizzes.");
            Console.WriteLine("   3. Agregar Notas Trabajos.");
            Console.WriteLine("   4. Agregar Notas Parciales.");
            Console.WriteLine("   5. Mostrar Estudiantes.");
            Console.WriteLine("   6. Mostrar Notas.");
            Console.WriteLine("   7. Mostrar Definitivas.");
            Console.WriteLine("   8. Cerrar Programa.");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Digite una opcion: ");
            
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Agregar Estudiante.");
                        AgregarEstudiante();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("2. Agregar Notas Quizzes.");
                        AgregarNotasQuizzes();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("3. Agregar Notas Trabajos.");
                        AgregarNotasTrabajos();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("4. Agregar Notas Parciales.");
                        AgregarNotasParciales();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("5. Mostrar Estudiantes.");
                        MostrarEstudiantes();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("6. Mostrar Notas.");
                        MostrarNotas();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("7. Mostrar Definitivas");
                        MostrarDefinitivas();
                        break;
                    case 8:
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

    static void AgregarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("------------ Agregar Estudiantes -------------");
        Console.WriteLine("----------------------------------------------");
        Notas notas = new Notas();

        Console.WriteLine("Ingrese Código Numérico (máximo 15 caracteres):");
        Console.WriteLine(" *** El codigo no se puede repetir *** ");
        notas.Codigo = Console.ReadLine();
        notas.Codigo = notas.Codigo.Replace(" ", "");

        while (notas.Codigo.Length > 15 || !int.TryParse(notas.Codigo, out int codigo) || codigo <= 0)
        {
            Console.Clear();
            Console.WriteLine("¡Error! Código Inválido. Ingrese Código Numérico (máximo 15 caracteres):");
            Console.WriteLine(" *** El codigo no se puede repetir *** ");
            notas.Codigo = Console.ReadLine();
            notas.Codigo = notas.Codigo.Replace(" ", "");
        }
        Console.Clear();
        Console.WriteLine("Ingrese Nombre (máximo 40 caracteres):");
        notas.Nombre = Console.ReadLine();
        notas.Nombre = notas.Nombre.Replace(" ", "");
        while (string.IsNullOrWhiteSpace(notas.Nombre) || notas.Nombre.Length > 40)
        {
            Console.Clear();
            Console.WriteLine("¡Error! Nombre Inválido. Ingrese Nombre (máximo 40 caracteres):");
            notas.Nombre = Console.ReadLine();
            notas.Nombre = notas.Nombre.Replace(" ", "");
        }
        Console.Clear();
        Console.WriteLine("Ingrese Email (máximo 40 caracteres):");
        Console.WriteLine("Ejemplo: xxx@xxx");
        notas.Email = Console.ReadLine();
        notas.Email = notas.Email.Replace(" ", "");
        while (string.IsNullOrWhiteSpace(notas.Email) || notas.Email.Length > 40 || !IsValidEmail(notas.Email))
        {
            Console.Clear();
            Console.WriteLine("¡Error! Email Inválido. Ingrese Email (máximo 40 caracteres):");
            Console.WriteLine("Ejemplo: xxx@xxx");
            notas.Email = Console.ReadLine();
            notas.Email = notas.Email.Replace(" ", "");
        }
        Console.Clear();
        while (true)
        {
            try
            {
                Console.WriteLine("Ingrese Edad:");
                Console.WriteLine(" *** Digite una edad entre los 1-100 años");
                notas.Edad = int.Parse(Console.ReadLine());

                if (notas.Edad > 100 || notas.Edad <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("¡Error! Edad Inválida.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("¡Error! Edad Inválida.");
            }
        }
        Console.Clear();
        Console.WriteLine("Ingrese Dirección (máximo 35 caracteres):");
        notas.Direccion = Console.ReadLine();
        notas.Direccion = notas.Direccion.Replace(" ", "");
        while (string.IsNullOrWhiteSpace(notas.Direccion) || notas.Direccion.Length > 35)
        {
            Console.Clear();
            Console.WriteLine("¡Error! Dirección Inválida. Ingrese Dirección (máximo 35 caracteres):");
            notas.Direccion = Console.ReadLine();
            notas.Direccion = notas.Direccion.Replace(" ", "");
        }

        // Verifica si ya existe una entrada en el diccionario para el código del estudiante.
        if (!dictNotas.ContainsKey(notas.Codigo))
        {
            dictNotas[notas.Codigo] = notas;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ya existe un estudiante con el mismo código en el sistema.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }
    }

    static void AgregarNotasQuizzes()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("------------ Agregar Notas Quizzes -------------");
        Console.WriteLine("------------------------------------------------");

        string codigoEstudiante = VerificarEstudiante();

        if (codigoEstudiante != null)
        {
            Console.Clear();
            Console.WriteLine($"Estudiante con código {codigoEstudiante} verificado correctamente.");

            // Accede al estudiante en el diccionario y agrega las notas de quizzes.
            Notas notas = dictNotas[codigoEstudiante];
            while (true)
            {
                try
                {
                    Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                    Console.WriteLine("Ingrese Nota Quizz 1:");
                    notas.Quizz_1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese Nota Quizz 2:");
                    notas.Quizz_2 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese Nota Quizz 3:");
                    notas.Quizz_3 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese Nota Quizz 4:");
                    notas.Quizz_4 = int.Parse(Console.ReadLine());

                    if((notas.Quizz_1 > 100 || notas.Quizz_1 < 0) || (notas.Quizz_2 > 100 || notas.Quizz_2 < 0) || (notas.Quizz_3 > 100 || notas.Quizz_3 < 0) || (notas.Quizz_4 > 100 || notas.Quizz_4 < 0))
                    {
                        Console.Clear();
                        Console.WriteLine("¡Error! Notas Quizzes Inválidas. ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("¡Error! Notas Quizzes Inválidas. ");
                }
            }
            Console.WriteLine("Notas de Quizzes agregadas correctamente.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No se encontró ningún estudiante con el código proporcionado.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }
    }

            // ...
        static void AgregarNotasTrabajos()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------------ Agregar Notas Trabajos -------------");
            Console.WriteLine("-------------------------------------------------");

            string codigoEstudiante = VerificarEstudiante();

            if (codigoEstudiante != null)
            {
                Console.Clear();
                Console.WriteLine($"Estudiante con código {codigoEstudiante} verificado correctamente.");

                // Accede al estudiante en el diccionario y agrega las notas de trabajos.
                Notas notas = dictNotas[codigoEstudiante];
                while (true)
                {
                    try
                    {
                        Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                        Console.WriteLine("Ingrese Nota Trabajo 1:");
                        notas.Trabajo_1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese Nota Trabajo 2:");
                        notas.Trabajo_2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese Nota Trabajo 3:");
                        notas.Trabajo_3 = int.Parse(Console.ReadLine());

                        if((notas.Trabajo_1 > 100 || notas.Trabajo_1 < 0) || (notas.Trabajo_2 > 100 || notas.Trabajo_2 < 0) || (notas.Trabajo_3 > 100 || notas.Trabajo_3 < 0))
                        {
                            Console.Clear();
                            Console.WriteLine("¡Error! Notas Trabajos Inválidas. ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("¡Error! Notas Trabajos Inválidas. ");
                    }
                }
                Console.WriteLine("Notas de Trabajos agregadas correctamente.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró ningún estudiante con el código proporcionado.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }

        static void AgregarNotasParciales()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("------------ Agregar Notas Parciales -------------");
            Console.WriteLine("--------------------------------------------------");

            string codigoEstudiante = VerificarEstudiante();

            if (codigoEstudiante != null)
            {
                Console.Clear();
                Console.WriteLine($"Estudiante con código {codigoEstudiante} verificado correctamente.");

                // Accede al estudiante en el diccionario y agrega las notas de parciales.
                Notas notas = dictNotas[codigoEstudiante];

                while (true)
                {
                    try
                    {
                        Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                        Console.WriteLine("Ingrese Nota Parcial 1:");
                        notas.Parcial_1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese Nota Parcial 2:");
                        notas.Parcial_2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese Nota Parcial 3:");
                        notas.Parcial_3 = int.Parse(Console.ReadLine());

                        if((notas.Parcial_1 > 100 || notas.Parcial_1 < 0) || (notas.Parcial_2 > 100 || notas.Parcial_2 < 0) || (notas.Parcial_3 > 100 || notas.Parcial_3 < 0))
                        {
                            Console.Clear();
                            Console.WriteLine("¡Error! Notas Parciales Inválidas. ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("¡Error! Notas Parciales Inválidas. ");
                    }
                }
                Console.WriteLine("Notas de Parciales agregadas correctamente.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró ningún estudiante con el código proporcionado.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }

        

        static string VerificarEstudiante()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el Código del Estudiante para verificarlo (máximo 15 caracteres): ");
            string codigo = Console.ReadLine();
            codigo = codigo.Replace(" ", "");
            while (codigo.Length > 15 || !int.TryParse(codigo, out int code) || code <= 0)
            {
                Console.Clear();
                Console.WriteLine("¡Error! Código Inválido. Ingrese Código del Estudiante para verificarlo (máximo 15 caracteres):");
                codigo = Console.ReadLine();
                codigo = codigo.Replace(" ", "");
            }

            // Verifica si el estudiante ya existe en el diccionario.
            if (dictNotas.ContainsKey(codigo))
            {
                return codigo;
            }

            return null;
        }

        static void MostrarEstudiantes()
        {
            Console.WriteLine("---------------------------------------------------------------- Mostrar Estudiantes -------------------------------------------------------------------------");
            Console.WriteLine("{0,-35} {1,-35} {2,-35} {3,-35} {4, -35}", "Código", "Nombre", "Email", "Edad", "Dirección");
            foreach (var kvp in dictNotas)
            {
                Notas estudiante = kvp.Value;
                Console.WriteLine("{0,-35} {1,-35} {2,-35} {3,-35} {4, -35}", estudiante.Codigo, estudiante.Nombre, estudiante.Email, estudiante.Edad, estudiante.Direccion);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }
        static void MostrarNotas()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------- Mostrar Notas ----------------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-45} {3,-45} {4,-45}",
                "Código", "Nombre", "Quizzes (Q1 Q2 Q3 Q4)", "Talleres (T1 T2 T3)", "Parciales (P1 P2 P3)");

            foreach (var kvp in dictNotas)
            {
                Notas notasEstudiante = kvp.Value;
                Console.WriteLine("{0,-15} {1,-15} {2,-45} {3,-45} {4,-45}",
                    notasEstudiante.Codigo, notasEstudiante.Nombre,
                    $"{notasEstudiante.Quizz_1} {notasEstudiante.Quizz_2} {notasEstudiante.Quizz_3} {notasEstudiante.Quizz_4}",
                    $"{notasEstudiante.Trabajo_1} {notasEstudiante.Trabajo_2} {notasEstudiante.Trabajo_3}",
                    $"{notasEstudiante.Parcial_1} {notasEstudiante.Parcial_2} {notasEstudiante.Parcial_3}");
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }
        static void MostrarDefinitivas(){
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- Mostrar Definitivas ------------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-35} {3,-35} {4,-35} {5,-35}",
                "Código", "Nombre", "Definitiva Quizzes", "Definitiva Talleres", "Definitiva Parciales", "Definitiva Final");
            foreach (var kvp in dictNotas)
            {
                Notas notasEstudiante = kvp.Value;
                double defQuizzes = ((notasEstudiante.Quizz_1+notasEstudiante.Quizz_2+notasEstudiante.Quizz_3+notasEstudiante.Quizz_4)/4)*0.25;
                double defTrabajos = ((notasEstudiante.Trabajo_1+notasEstudiante.Trabajo_2+notasEstudiante.Trabajo_3)/3)*0.15;
                double defParciales = ((notasEstudiante.Parcial_1+notasEstudiante.Parcial_2+notasEstudiante.Parcial_3)/3)*0.60;
                double defFinal = (defQuizzes+defTrabajos+defParciales);
                Console.WriteLine("{0,-15} {1,-15} {2,-35} {3,-35} {4,-35} {5,-35}",notasEstudiante.Codigo, notasEstudiante.Nombre, defQuizzes, defTrabajos, defParciales, defFinal );
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        internal class Notas
        {
            public string Nombre { get; set; }
            public string Email { get; set; }
            public int Edad { get; set; }
            public string Direccion { get; set; }
            public string Codigo { get; set; }
            public int Quizz_1 { get; set; }
            public int Quizz_2 { get; set; }
            public int Quizz_3 { get; set; }
            public int Quizz_4 { get; set; }
            public int Trabajo_1 { get; set; }
            public int Trabajo_2 { get; set; }
            public int Trabajo_3 { get; set; }
            public int Parcial_1 { get; set; }
            public int Parcial_2 { get; set; }
            public int Parcial_3 { get; set; }
            
        }
    }



                    


/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */
