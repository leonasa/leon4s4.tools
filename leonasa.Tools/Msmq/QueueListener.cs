using System;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using Experimental.System.Messaging;
using log4net;

namespace leon4s4.tools.Msmq
{
    public class QueueListener<T> : IDisposable where T : class
    {
        private readonly QueueBuilder _queueBuilder;
        private MessageQueue _queue;

        private readonly ILog _logger;

        private readonly Subject<T> _subject = new Subject<T>();
        private string _queueName;

        public QueueListener(QueueBuilder queueBuilder, ILog logger)
        {
            _queueBuilder = queueBuilder;
            _logger = logger;
        }

        public Subject<T> Start(string queueName)
        {
            try
            {
                _queueName = queueName;

                _logger.Info($"Starting QueueListener: {queueName}");

                _queue = _queueBuilder.CreateQueue(queueName);

                _queue.Formatter = new XmlMessageFormatter(new[] { typeof(T) });

                _queue.BeginReceive(MessageQueue.InfiniteTimeout, null, OnReceive);

                return _subject;
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message}{queueName}{Environment.NewLine} See https://www.codeproject.com/Questions/675765/Access-to-message-queuing-system-is-denied-MSMQ");
                throw new Exception($"{exception.Message}{queueName}{Environment.NewLine} See https://www.codeproject.com/Questions/675765/Access-to-message-queuing-system-is-denied-MSMQ", exception);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                _logger.Info($"Starting OnReceive for queue: {_queueName}");
                var message = _queue.EndReceive(ar);

                if (message != null)
                {
                    try
                    {
                        var body = Deserializer(message);

                        _logger.Debug($"Message Received on queue: {_queueName}, with body: {body}");

                        _subject.OnNext(body);
                    }
                    catch (DecoderFallbackException e)
                    {
                        _logger.Error($"OnReceive error (DecoderFallbackException) on queue {_queueName}", e);
                    }
                    catch (Exception e)
                    {
                        _logger.Error($"OnReceive error (Exception) on queue {_queueName}", e);
                    }
                }

                _queue.BeginReceive(MessageQueue.InfiniteTimeout, null, OnReceive);

                Thread.Yield();
            }
            catch (Exception e)
            {
                _logger.Debug($"Exception OnReceive queue: {_queueName}, e: {e}");
                throw;
            }
        }

        protected virtual T Deserializer(Message message)
        {
            return message.Body as T;
        }

        public void Dispose()
        {
            _subject.OnCompleted();
            _queue.Dispose();
        }
    }
}