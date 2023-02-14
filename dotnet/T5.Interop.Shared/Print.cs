namespace T5.Interop.Shared;

//Classe para printar no console as mensagems
public static class Print
{
    public static void Text(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
    public static void MessageSent(Message mensagem)
    {
        Console.WriteLine("Publishing message on MQTT server!");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }
    public static void PublishSuccess()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Message published on MQTT server!");
        Console.ResetColor();

    }
    public static void MessageRecieved(Message response)
    {
        Console.WriteLine("Recieving message from MQTT server!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(response);
        Console.ResetColor();
    }

    public static async Task DatabaseResponse(HttpResponseMessage response)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(response);
        Console.WriteLine();

        var responseData = await response.Content.ReadAsStringAsync();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(responseData);
        Console.ResetColor();
    }
}