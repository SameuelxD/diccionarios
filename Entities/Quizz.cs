namespace Estudiantes.Quizz
{
    public class Entities
    {
        // Propiedades
        public string Codigo { get; set; }
        public int Quizz_1 { get; set; }
        public int Quizz_2 { get; set; }
        public int Quizz_3 { get; set; }
        public int Quizz_4 { get; set; }

        // Constructor predeterminado
        public Entities()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas
        }

        // Constructor con parámetros
        public Entities(string codigo, int quizz_1, int quizz_2, int quizz_3, int quizz_4)
        {
            Codigo = codigo;
            Quizz_1 = quizz_1; 
            Quizz_2 = quizz_2; 
            Quizz_3 = quizz_3; 
            Quizz_4 = quizz_4;
        }
    }
}

