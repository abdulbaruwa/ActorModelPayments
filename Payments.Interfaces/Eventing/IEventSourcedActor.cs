using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Payments.Interfaces.Eventing
{
    public interface IEventSourcedActor<TEvent, TActorState> : IActor
        where TActorState : ICanApplyEvent<TEvent, TActorState>
    {
        Task<TActorState> GetState();
        Task<List<TimestampedValue<TEvent>>> GetEvents(DateTime? startTime = null, DateTime? endTime = null);
    }
}