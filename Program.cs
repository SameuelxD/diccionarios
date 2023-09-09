using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


internal class Program
{
    static Estudiante estudiante;
    static Quizz quizz;
    static List<Estudiante> listEstudiantes = new List<Estudiante>();
    static List<Quizz> notasQuizz = new List<Quizz>();
    private static void Main(string[] args)
    {
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
                        AgregarNotas();
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
        Console.Clear();
        Console.WriteLine("------------ Agregar Estudiantes -------------");
        Console.WriteLine("----------------------------------------------");
        estudiante = new Estudiante();

        Console.WriteLine("Ingrese Código Numérico (máximo 15 caracteres):");
        estudiante.Codigo = Console.ReadLine();
        estudiante.Codigo=estudiante.Codigo.Replace(" ","");

        while (estudiante.Codigo.Length > 15 || !int.TryParse(estudiante.Codigo, out int codigo) || codigo <= 0)
        {
            Console.Clear();
            Console.WriteLine("¡Error! Código Inválido. Ingrese Código Numérico (máximo 15 caracteres):");
            estudiante.Codigo = Console.ReadLine();
            estudiante.Codigo=estudiante.Codigo.Replace(" ","");
        }
        Console.Clear();
        Console.WriteLine("Ingrese Nombre (máximo 40 caracteres):");
        estudiante.Nombre = Console.ReadLine();
        estudiante.Nombre=estudiante.Nombre.Replace(" ","");
        while(Regex.IsMatch(estudiante.Nombre, @"^\s*$") || !Regex.IsMatch(estudiante.Nombre, @"[a-zA-Z0-9]") || (estudiante.Nombre.Length > 40))
        {
            Console.Clear();
            Console.WriteLine("¡Error! Nombre Inválido. Ingrese Nombre (máximo 40 caracteres):");                    
            estudiante.Nombre = Console.ReadLine();
            estudiante.Nombre=estudiante.Nombre.Replace(" ","");
        }
        Console.Clear();
        Console.WriteLine("Ingrese Email (máximo 40 caracteres):");
        estudiante.Email = Console.ReadLine();
        estudiante.Email=estudiante.Email.Replace(" ","");
        while(Regex.IsMatch(estudiante.Email, @"^\s*$") || !Regex.IsMatch(estudiante.Email, @"[a-zA-Z0-9]") || (estudiante.Email.Length > 40))
        {
            Console.Clear();
            Console.WriteLine("¡Error! Email Inválido. Ingrese Email (máximo 40 caracteres):");
            estudiante.Email = Console.ReadLine();
            estudiante.Email=estudiante.Email.Replace(" ","");
        }
        Console.Clear();
        while (true)
        {
            try
            {
                
                Console.WriteLine("Ingrese Edad:");
                estudiante.Edad = int.Parse(Console.ReadLine());

                if (estudiante.Edad > 100 || estudiante.Edad <= 0)
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
        Console.WriteLine("Ingrese Direccion (máximo 35 caracteres):");
        estudiante.Direccion = Console.ReadLine();
        estudiante.Direccion=estudiante.Direccion.Replace(" ","");
        while(Regex.IsMatch(estudiante.Direccion, @"^\s*$") || !Regex.IsMatch(estudiante.Direccion, @"[a-zA-Z0-9]") || (estudiante.Direccion.Length > 35))
        {
            Console.Clear();
            Console.WriteLine("¡Error! Direccion Inválida. Ingrese Direccion (máximo 35 caracteres):");
            estudiante.Direccion = Console.ReadLine();
            estudiante.Direccion=estudiante.Direccion.Replace(" ","");
        }  
        return estudiante;
    }
    static void AgregarNotas()
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
                            Console.Clear();
                            Console.WriteLine("1. Agregar Notas Quizzes.");
                            VerificarEstudiante(listEstudiantes,notasQuizz);
                            Quizz quizz = AgregarQuizzes();
                            notasQuizz.Add(quizz);
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
        
        
        static Quizz AgregarQuizzes()
        {
            Console.Clear();
            Console.WriteLine("------------ Agregar Quizzes -------------");
            Console.WriteLine("----------------------------------------------");
            quizz = new Quizz();
            while (true)
            {
                try
                {
                    
                    Console.WriteLine("Ingrese Nota Quizz 1:");
                    quizz.quizz_1 = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Ingrese Nota Quizz 2:");
                    quizz.quizz_2 = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Ingrese Nota Quizz 3:");
                    quizz.quizz_3 = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Ingrese Nota Quizz 4:");
                    quizz.quizz_4 = int.Parse(Console.ReadLine());

                    if ((quizz.quizz_1 > 100 || quizz.quizz_1 < 0) || (quizz.quizz_2 > 100 || quizz.quizz_2 < 0) || (quizz.quizz_3 > 100 || quizz.quizz_3 < 0) || (quizz.quizz_4 > 100 || quizz.quizz_4 < 0))
                    {
                        Console.Clear();
                        Console.WriteLine("¡Error! Nota Quizzes Inválidas.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("¡Error! Notas Quizzes Inválidas.");
                }
            }
            return quizz;
        }
    }
    static string VerificarEstudiante(List<Estudiante> estudiantes, List<Quizz> notasQuizz)
    {
        Console.WriteLine("Ingrese el Codigo del Estudiante para verificarlo (máximo 15 caracteres): ");
        string codigo = Console.ReadLine();
        codigo=codigo.Replace(" ","");
        while (codigo.Length > 15 || !int.TryParse(codigo, out int code) || code <= 0)
        {
            Console.Clear();
            Console.WriteLine("¡Error! Código Inválido. Ingrese Código del Estudiante para verificarlo (máximo 15 caracteres):");
            codigo = Console.ReadLine();
            codigo=codigo.Replace(" ","");
        }
        foreach (Estudiante estudiante in estudiantes)
        {
            if(codigo == estudiante.Codigo){
                Console.WriteLine($"Codigo {codigo} satisfactoriamente encontrado.");
                return codigo; 
            }
        }
        return null;
    }

    static void MostrarEstudiantes(List<Estudiante> estudiantes)
    {
        Console.WriteLine("---------------------------- Mostrar Estudiantes -----------------------------");
        Console.WriteLine("{0,-15} {1,-35} {2,-35} {3,-35} {4, -5}", "Código", "Nombre", "Email", "Edad", "Direccion");
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine("{0,-15} {1,-35} {2,-35} {3,-35} {4, -5}", estudiante.Codigo, estudiante.Nombre, estudiante.Email, estudiante.Edad, estudiante.Direccion);
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadLine();
        Console.WriteLine("-----------------------------------------------");    
    }
    internal class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }
    internal class Quizz
    {
        public string Codigo { get; set; }
        public int Quizz_1 { get; set; }
        public int Quizz_2 { get; set; }
        public int Quizz_3 { get; set; }
        public int Quizz_4 { get; set; }
    }
}

    


/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */
