using System;
using System.Collections.Generic;
using Estudiantes.Estudiante; // Asegúrate de importar el espacio de nombres correcto

internal class Program
{
    private static void Main(string[] args)
    {
        List<Entities> listClass = new List<Entities>();

        for (int i = 0; i < 2; i++)
        {
            Entities estudiante = new Entities();
            Console.WriteLine("Ingrese Codigo Numerico");
            estudiante.Codigo = Console.ReadLine();
            while (estudiante.Codigo.Length > 15 || !int.TryParse(estudiante.Codigo, out _)){
                Console.WriteLine("¡Error! Codigo Invalido");
                Console.WriteLine("Ingrese Codigo Numerico");
                estudiante.Codigo = Console.ReadLine();
            }

            Console.WriteLine("Ingrese Nombre");
            estudiante.Nombre = Console.ReadLine();
            while(estudiante.Nombre.Length > 40){
                Console.WriteLine("¡Error! Nombre Invalido");
                Console.WriteLine("Ingrese Nombre");
                estudiante.Nombre = Console.ReadLine();
            }
            Console.WriteLine("Ingrese Email");
            estudiante.Email = Console.ReadLine();
            while(estudiante.Email.Length > 40){
                Console.WriteLine("¡Error! Email Invalido");
                Console.WriteLine("Ingrese Email");
                estudiante.Email = Console.ReadLine();
            }
            while(true){
                try{
                    Console.WriteLine("Ingrese Edad");
                    estudiante.Edad = int.Parse(Console.ReadLine());
                    if(estudiante.Edad>100 || estudiante.Edad<=0){
                        Console.WriteLine("¡Error! Edad Invalida");
                    }
                    else{
                        break;
                    }
                }
                catch(FormatException){
                    Console.WriteLine("¡Error! Edad Invalida");
                }   
            }
            listClass.Add(estudiante);
            Console.Clear();
        }
        
        Console.WriteLine("{0,-36} {1,-30} {2,-30}", "Codigo", "Nombre", "Email");
        
        foreach (Entities estudiante in listClass)
        {
            Console.WriteLine("{0,-36} {1,-30} {2,-30}", estudiante.Codigo, estudiante.Nombre, estudiante.Email);
        }
        
        // Ahora, puedes usar listClass para trabajar con los estudiantes creados
    }
}



/* El profesor del area de mate necesirta registrar los estudiantes que se encuentran matriculados , la informacion que el docente posee de cada estudiante es la siguiente: 
 - Cod Estudiante longitu maxima 15 caracteres , Nombre estudiante longitud maxima 40 caracteres , Email longitud 40 caracteres , edad y direccion logitud de 35 caracteres , no se conoce la catidad de estudiantes que se registraton en la asignatura , la uni tiene como norma que cada estudiante debe presentar  4 quizz , 3 trabajos y 3 parciales , las notas de los quizz equivalen al 25% . trabajos al 15% y los parciales al 60% , el programa debe permitir al profesor generar los siguientes reportes: 
 - Listado gneral de notas , paginado 10 estudiantes , es deicir divida en grupos de a 10 estudiantes , el programa debe permitir al docente realizar todo el proceso de quizzess , trabajos y parciales por medio del id de cada estudiante */