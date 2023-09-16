using System.Collections.Generic; 

namespace Estudiantes.Notas
{
    public class Entities
    {
        // Propiedades
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Codigo { get; set; }
        public List<int> Quizzes { get; set; } = new List<int>(); 
        public List<int> Trabajos { get; set; } = new List<int>();
        public List<int> Parciales { get; set; } = new List<int>();

        // Constructor predeterminado
        public Entities()
        {
            
        }

        // Constructor con parámetros
        public Entities(string codigo)
        {
            Codigo = codigo;      
        }
    }
}
