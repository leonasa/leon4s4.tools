using System;
using Experimental.System.Messaging;
using log4net;

namespace leon4s4.tools.Msmq
{
    public class QueueBuilder
    {
        private readonly ILog _logger;

        public QueueBuilder(ILog logger)
        {
            _logger = logger;
        }

        public MessageQueue CreateQueue(string queueName)
        {
            try
            {
                _logger.Debug($"CreateQueueToListen, queueName: {queueName}, QueueAccessMode: {QueueAccessMode.SendAndReceive}");
                return new MessageQueue(queueName, QueueAccessMode.SendAndReceive);
            }
            catch (Exception e)
            {
                _logger.Error($"Error creating queueName: {queueName}, exception: {e}, StackTrace: {e.StackTrace}");
                throw;
            }
        }
    }
}