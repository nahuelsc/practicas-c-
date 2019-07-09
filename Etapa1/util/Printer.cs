using static System.Console;

namespace CorEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }
        public static void PrecioneENTER()
        {
            WriteLine("Presione ENTER para continuar");
        }
        public static void WriteTitle(string title)
        {
            var tamaño = title.Length + 4;
            Printer.DrawLine(tamaño);
            WriteLine($"| {title} | ");
            Printer.DrawLine(tamaño);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }
    }
}