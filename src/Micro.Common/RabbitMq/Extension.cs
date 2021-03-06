﻿using System;
using System.Threading.Tasks;
using Micro.Common.Commands;
using Micro.Common.Events;
using RabbitMQ;
using RabbitMQ.Client.MessagePatterns;
using RawRabbit;

namespace Micro.Common.RabbitMq
{
    public static class Extension
    {

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg =>
                   cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>))));




        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
    IEventHandler<TEvent> handler) where TEvent : IEvent
         => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
        ctx => ctx.UseSubscribeConfiguration(cfg =>
           cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>))));



        private static string GetQueueName<T>()
            => "{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


    }
}
