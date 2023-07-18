using Quiz_V2.Data;

namespace Quiz_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new QuizDataContext();
        }
    }
}

// Quando for criar as perguntas, olhar o método do vídeo 11 do mapeamento, minuto 02:40
// Testar LastOrDefault