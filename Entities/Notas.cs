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

        // Constructor predeterminado
        public Entities()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas
        }

        // Constructor con parámetros
        public Entities(string codigo, int quizz_1, int quizz_2, int quizz_3, int quizz_4, int trabajo_1, int trabajo_2, int trabajo_3, int parcial_1, int parcial_2, int parcial_3)
        {
            Codigo = codigo;
            Quizz_1 = quizz_1; 
            Quizz_2 = quizz_2; 
            Quizz_3 = quizz_3; 
            Quizz_4 = quizz_4;
            Trabajo_1 = trabajo_1;        
            Trabajo_2 = trabajo_2; 
            Trabajo_3 = trabajo_3;
            Parcial_1 = parcial_1; 
            Parcial_2 = parcial_2; 
            Parcial_3 = parcial_3; 
        }
    }
}

