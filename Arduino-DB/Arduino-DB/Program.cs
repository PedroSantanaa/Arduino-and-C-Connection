using System.IO.Ports;
using Arduino_DB.data;
using Arduino_DB.modules;
internal class Program
{
    static SerialPort? SerialPort;
    private static void Main(string[] args)
    {
        SerialPort = new SerialPort("COM5", 9600);
        SerialPort.Open();
        List<string> lines = new List<string>();

        while (true)
        {
            Console.WriteLine("Deseja continuar medindo??(s/n)");
            string? message = Console.ReadLine();
            if (message == "s")
            {
                lines.Clear();
                int cont = 0;
                while (cont < 4)
                {

                    string data = ReadingLines(SerialPort);
                    Console.WriteLine(data);
                    if (!string.IsNullOrEmpty(data))
                    {
                        lines.Add(data);
                        cont++;
                    }
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

    private static string ReadingLines(SerialPort? serialPort)
    {
        try
        {
            string? msg = serialPort?.ReadLine();

            return msg;
        }
        catch (TimeoutException)
        {
            throw new Exception();
        }

    }

}
