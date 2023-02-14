using T5.Interop.Shared;

CancellationTokenSource cancelationToken = new CancellationTokenSource();


Console.CancelKeyPress += (sender, eventArgs) =>
{
    cancelationToken.Cancel();
    eventArgs.Cancel = true;
};

var token = cancelationToken.Token;

var listener = new Listener(MQTTConnectionSettings.SERVER, MQTTConnectionSettings.TOPIC);


// conecta ao mqtt
await listener.ConnectAsync();

//Roda infinitamente até o programa ser cancelado
while (!token.IsCancellationRequested)
{
    await Task.Delay(10);
}

await listener.DisconnectAsync();