namespace Estudiantes.Estudiante
{
    public class Entities
    {
        // Propiedades
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        // Constructor predeterminado
        public Entities()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas
        }

        // Constructor con parámetros
        public Entities(string codigo, string nombre, string email, int edad, string direccion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Email = email;
            Edad = edad;
            Direccion = direccion;
        }
    }
}

