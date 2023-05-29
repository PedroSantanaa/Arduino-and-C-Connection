using System.IO.Ports;
using Arduino_DB.data;
using Arduino_DB.modules;
internal class Program
{
    static SerialPort SerialPort;
    private static void Main(string[] args)
    {
        SerialPort = new SerialPort("COM3", 9600);
        SerialPort.Open();
        int cont = 0;
        List<string> lines = new List<string>();        

        while (true) {
            Console.WriteLine("Deseja continuar medindo??(s/n)");
            string message= Console.ReadLine();
            if(message == "s")
            {
                lines.Clear();
                cont = 0;
                while (cont < 3)
                {

                    string data = ReadingLines();
                    lines.Add(data);

                    cont++;
                }
                Arduino arduino = new Arduino(lines);
                using (var context = new AppDbContext())
                {
                    context.ArduinoData.Add(arduino);
                    context.SaveChanges();
                }
            }
            else
            {
                break;
            }

        }
        

    }

    private static string ReadingLines()
    {
        try
        {
            string message = SerialPort.ReadLine();

            return message;
        }
        catch (TimeoutException)
        {
            throw new Exception();
        }

    }
    
}
