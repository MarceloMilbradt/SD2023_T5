using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using T5.Interop.Shared;

internal class Listener
{
    public string ClientId = Guid.NewGuid().ToString();
    private HttpClient _httpClient;
    readonly IMqttClient _client;
    readonly MqttClientOptions _clientOptions;
    readonly string _topic;
    public Listener(string server, string topic)
    {
        _httpClient = new HttpClient();

        var mqttFactory = new MqttFactory();
        _client = mqttFactory.CreateMqttClient();

        _client.ConnectedAsync += Client_ConnectedAsync;
        _client.DisconnectedAsync += Client_DisconnectedAsync;
        _client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;

        _clientOptions = new MqttClientOptionsBuilder()
                        .WithClientId(ClientId)
                        .WithTcpServer(server, 1883)
                        .WithCleanSession()
                        .Build();
        _topic = topic;
    }
   
    private async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
    {
        var payloadString = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
        var message = JsonConvert.DeserializeObject<Message>(payloadString)!;
        Print.MessageRecieved(message);
        await PublishToDatabase(message);
        return Task.CompletedTask;
    }

    private Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
    {
        Print.Text($"Disconnected from broker");
        return Task.CompletedTask;
    }

    private async Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
    {
        Print.Text($"Connected to broker in topic {_topic}");

        var topicFilter = new MqttTopicFilterBuilder().WithTopic(_topic).Build();
        await _client.SubscribeAsync(topicFilter);
        Print.Text($"Waiting for message on topic {_topic}");
    }

    private async Task PublishToDatabase(Message message)
    {
        var response = await _httpClient.PostAsJsonAsync("https://projetosd-d46bb-default-rtdb.firebaseio.com/t5.json", message);
        await Print.DatabaseResponse(response);
    }
    public async Task ConnectAsync()
    {
        await _client.ConnectAsync(_clientOptions);
    }
    public async Task DisconnectAsync()
    {
        await _client.DisconnectAsync();
    }

}