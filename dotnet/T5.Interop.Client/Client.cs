using T5.Interop.Shared;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;

internal class Client
{
    public string ClientId = Guid.NewGuid().ToString();
    readonly IMqttClient _client;
    readonly MqttClientOptions _clientOptions;
    readonly string _topic;


    public Client(string server, string topic)
    {
        //Cria a factory e o client do mqtt
        var mqttFactory = new MqttFactory();
        _client = mqttFactory.CreateMqttClient();

        _client.ConnectedAsync += Client_ConnectedAsync;
        _client.DisconnectedAsync += Client_DisconnectedAsync;

        _clientOptions = new MqttClientOptionsBuilder()
                        .WithClientId(ClientId)
                        .WithTcpServer(server, 1883)
                        .WithCleanSession()
                        .Build();
        _topic = topic;
    }

    private Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
    {
        Print.Text($"Disconnected from broker");
        return Task.CompletedTask;
    }

    private Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
    {
        Print.Text($"Connected to broker in topic {_topic}");
        return Task.CompletedTask;
    }

    public async Task ConnectAsync()
    {
        await _client.ConnectAsync(_clientOptions);
    }
    public async Task DisconnectAsync()
    {
        await _client.DisconnectAsync();
    }

    public async Task PublishMessageAsync(Message message)
    {
        string json = JsonConvert.SerializeObject(message);
        var mqttMessage = new MqttApplicationMessageBuilder().WithTopic(_topic).WithPayload(json).Build();


        Print.MessageSent(message);

        if (_client.IsConnected)
        {
            var result = await _client.PublishAsync(mqttMessage);
            if (result.IsSuccess)
            {
                Print.PublishSuccess();
            }
        }

    }

}
