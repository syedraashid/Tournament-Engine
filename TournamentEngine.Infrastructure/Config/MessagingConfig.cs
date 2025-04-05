﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentEngine.Infrastructure.Config
{
    public class MessagingConfig
    {
        public const string SECTION = "MessagingConfig";
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
    }
}
