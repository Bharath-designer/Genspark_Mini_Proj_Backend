using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EventManagementTest
{
    public class InMemoryConfiguration
    {
        public IConfiguration Configuration;

        public InMemoryConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "TokenKey:JWT", "9667cb52368dc29f17b2dbdfcaeebc3afeeea4bfb7c3ca665f1cf5da770286319e39f212c203bc5bd33785dac4da6bed7861eb1cfd022796361dfc190f2b2748" },
                {"PaymentCredentials:PAYMENT_URL", "http://localhost:3000/session" },
                {"PaymentCredentials:API_KEY", "njk3-cs343-ccdscd" },
                {"WebhookCredentials:KEY", "8a3a6e0967f0184db8a317910239ac2521a329783e2d88a1edeb3e" }

            };

            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

    }

}
