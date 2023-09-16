using System;
using System.Collections.Generic;
using Newtonsoft.Json;

internal class Program
{
    static Dictionary<string, Notas> dictNotas = new Dictionary<string, Notas>();

    private static void Main(string[] args)
    {
        bool active = true;
        dictNotas = CargarDatos();
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
                        GuardarInformacion(dictNotas);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("2. Agregar Notas Quizzes.");
                        AgregarNotasQuizzes();
                        GuardarInformacion(dictNotas);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("3. Agregar Notas Trabajos.");
                        AgregarNotasTrabajos();
                        GuardarInformacion(dictNotas);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("4. Agregar Notas Parciales.");
                        AgregarNotasParciales();
                        GuardarInformacion(dictNotas);
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
            Notas notas = dictNotas[codigoEstudiante];

            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                        Console.WriteLine($"Ingrese Nota Quizz {i + 1}:");
                        int nota = int.Parse(Console.ReadLine());

                        if (nota >= 0 && nota <= 100)
                        {
                            notas.Quizzes.Add(nota);
                            break; 
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("¡Error! Notas Quizzes Inválidas. ");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("¡Error! Ingrese una nota válida.");
                    }
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

                for (int i = 0; i < 3; i++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                            Console.WriteLine($"Ingrese Nota Trabajo {i + 1}:");
                            int nota = int.Parse(Console.ReadLine());

                            if (nota >= 0 && nota <= 100)
                            {
                                notas.Trabajos.Add(nota);
                                break; // Sal del bucle while si la nota es válida.
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("¡Error! Notas Trabajos Inválidas. ");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("¡Error! Ingrese una nota válida.");
                        }
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

                // Accede al estudiante en el diccionario y agrega las notas de trabajos.
                Notas notas = dictNotas[codigoEstudiante];

                for (int i = 0; i < 2; i++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(" *** Notas Tipo Entero entre 0-100 ");
                            Console.WriteLine($"Ingrese Nota Parcial {i + 1}:");
                            int nota = int.Parse(Console.ReadLine());

                            if (nota >= 0 && nota <= 100)
                            {
                                notas.Parciales.Add(nota);
                                break; // Sal del bucle while si la nota es válida.
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("¡Error! Notas Parciales Inválidas. ");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("¡Error! Ingrese una nota válida.");
                        }
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
            Console.WriteLine("------------------------------------------------- Mostrar Estudiantes ---------------------------------------------------------");
            Console.WriteLine("{0,-25} {1,-25} {2,-25} {3,-25} {4, -25}", "Código", "Nombre", "Email", "Edad", "Dirección");
            foreach (var kvp in dictNotas)
            {
                Notas estudiante = kvp.Value;
                Console.WriteLine("{0,-25} {1,-25} {2,-25} {3,-25} {4, -25}", estudiante.Codigo, estudiante.Nombre, estudiante.Email, estudiante.Edad, estudiante.Direccion);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }
        static void MostrarNotas()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------- Mostrar Notas --------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25}",
                "Código", "Nombre", "Quizzes (Q1 Q2 Q3 Q4)", "Talleres (T1 T2 T3)", "Parciales (P1 P2)");

            foreach (var kvp in dictNotas)
            {
                Notas notasEstudiante = kvp.Value;

                // Verificar si hay notas para este estudiante
                if (notasEstudiante.Quizzes.Count == 4 && notasEstudiante.Trabajos.Count == 3 && notasEstudiante.Parciales.Count == 2)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25}",
                        notasEstudiante.Codigo, notasEstudiante.Nombre,
                        $"{notasEstudiante.Quizzes[0]} {notasEstudiante.Quizzes[1]} {notasEstudiante.Quizzes[2]} {notasEstudiante.Quizzes[3]}",
                        $"{notasEstudiante.Trabajos[0]} {notasEstudiante.Trabajos[1]} {notasEstudiante.Trabajos[2]}",
                        $"{notasEstudiante.Parciales[0]} {notasEstudiante.Parciales[1]}");
                }
                else
                {
                    // Mostrar un mensaje de error si faltan notas
                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25}",
                        notasEstudiante.Codigo, notasEstudiante.Nombre,
                        "Notas faltantes", "Notas faltantes", "Notas faltantes");
                }
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }

        static void MostrarDefinitivas()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------- Mostrar Definitivas -------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25} {5,-25}",
                "Código", "Nombre", "Definitiva Quizzes", "Definitiva Talleres", "Definitiva Parciales", "Definitiva Final");

            foreach (var kvp in dictNotas)
            {
                Notas notasEstudiante = kvp.Value;

                // Verificar si hay notas suficientes para calcular las definitivas
                if (notasEstudiante.Quizzes.Count == 4 && notasEstudiante.Trabajos.Count == 3 && notasEstudiante.Parciales.Count == 2)
                {
                    double defQuizzes = ((notasEstudiante.Quizzes[0] + notasEstudiante.Quizzes[1] + notasEstudiante.Quizzes[2] + notasEstudiante.Quizzes[3]) / 4) * 0.25;
                    double defTrabajos = ((notasEstudiante.Trabajos[0] + notasEstudiante.Trabajos[1] + notasEstudiante.Trabajos[2]) / 3) * 0.15;
                    double defParciales = ((notasEstudiante.Parciales[0] + notasEstudiante.Parciales[1]) / 2) * 0.60;
                    double defFinal = (defQuizzes + defTrabajos + defParciales);
                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25} {5,-25}", notasEstudiante.Codigo, notasEstudiante.Nombre, defQuizzes, defTrabajos, defParciales, defFinal);
                }
                else
                {
                    // Mostrar un mensaje de error si faltan notas
                    Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-25} {4,-25} {5,-25}", notasEstudiante.Codigo, notasEstudiante.Nombre, "Notas faltantes", "Notas faltantes", "Notas faltantes", "Notas faltantes");
                }
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
        public static void GuardarInformacion(Dictionary<string, Notas> dictNotas){
            string json = JsonConvert.SerializeObject(dictNotas, Formatting.Indented);
            File.WriteAllText("estudiantes.json", json);
        }
        public static Dictionary<string, Notas> CargarDatos()
        {
             try
            {
                using (StreamReader reader = new StreamReader("estudiantes.json"))
                {
                    string json = reader.ReadToEnd();
                    return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Notas>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new Dictionary<string, Notas>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde estudiantes.json: " + ex.Message);
                return new Dictionary<string, Notas>();
            }
        }
        public void EliminarEstudiante(Dictionary<string, Notas> dictNotas){
            string codigoEstudiante = VerificarEstudiante();
            if (codigoEstudiante != null)
            {
                Console.Clear();
                Console.WriteLine($"Estudiante con código {codigoEstudiante} eliminado correctamente.");

                // Accede al estudiante en el diccionario y elimina al estudiante
                dictNotas.Remove(codigoEstudiante);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró ningún estudiante con el código proporcionado.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }
        internal class Notas
        {
            public string Nombre { get; set; }
            public string Email { get; set; }
            public int Edad { get; set; }
            public string Direccion { get; set; }
            public string Codigo { get; set; }
            public List<int> Quizzes { get; set; } = new List<int>(); 
            public List<int> Trabajos { get; set; } = new List<int>(); 
            public List<int> Parciales { get; set; } = new List<int>();
            
            
        }
    }



                    


/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */
