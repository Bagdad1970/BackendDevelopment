using RabbitMQ.Client;

namespace WebApplication1.Config;

public class RabbitMqSettings
{
    public string HostName { get; set; }

    public int Port { get; set; }
    
    public IRecordedQueue OrderCreatedQueue { get; set; }
}