using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Abstractions.RabbitMQ
{
    public interface IRabbitMQService
    {
        Task<string> SendMessage(string queueName, string message);
    }
}
