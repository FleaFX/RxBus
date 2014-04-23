ApplicationBus
==============

I find myself writing this bit of code over and over, so I decided to throw it on GitHub.

The ApplicationBus is basically a message bus based on [RX](http://msdn.microsoft.com/nl-be/data/gg577609.aspx "Reactive Extensions on MSDN"). It centralizes publishing and subscribing into one IObservable<object>. I tend to use this only as an internal mechanism to wire up command handlers and event publishers (e.g. IHandle<TCommand>, IPublish<TEvent>).

An example of how I use it:


    // messages produced by someObservable will be published to all subscribers that are interested in it
    bus.AddPublisher(someObservable);
    
    // SomeApplicationService.Handle will be invoked whenever an ExecuteSomeCommandMessage is published on the bus
    bus.OfType<ExecuteSomeCommandMessage>().
      Subscribe(message => SomeApplicationService.Handle(someSingleInstanceDependency,
          new InstanceDependency(),
          new SubscriptionService(bus),
          message));
