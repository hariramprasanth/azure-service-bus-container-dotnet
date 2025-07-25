namespace func_container;

public class sbtsreceiver
{
    private readonly ILogger<sbtsreceiver> _logger;

    public sbtsreceiver(ILogger<sbtsreceiver> logger)
    {
        _logger = logger;
    }

    [Function(nameof(sbtsreceiver))]
    public async Task Run(
        [ServiceBusTrigger("my-topic", "my-sub", Connection = "mysbnsconnectionprefix")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}