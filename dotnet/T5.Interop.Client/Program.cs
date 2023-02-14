using T5.Interop.Shared;


CancellationTokenSource cancelationToken = new CancellationTokenSource();


Console.CancelKeyPress += (sender, eventArgs) =>
{
    cancelationToken.Cancel();
    eventArgs.Cancel = true;
};

var token = cancelationToken.Token;

Message mensagem;
var client = new Client(MQTTConnectionSettings.SERVER, MQTTConnectionSettings.TOPIC);
//Le o console por argumentos do executavel

// conecta ao mqtt
await client.ConnectAsync();

while (!token.IsCancellationRequested)
{
    Print.Text("Type new message to Broker:");


    var line = Console.ReadLine();

    if (string.IsNullOrEmpty(line))
    {
        if (line == null) break;
        else continue;
    }

    mensagem = new Message(DateTime.Now, line, Guid.NewGuid());

    // publica no mqtt
    await client.PublishMessageAsync(mensagem);
    Console.WriteLine();
    Console.WriteLine();

}

await client.DisconnectAsync();
