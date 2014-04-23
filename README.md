RxBus
=====

I find myself writing this bit of code over and over, so I decided to throw it on GitHub.

RxBus is basically a message bus based on [RX](http://msdn.microsoft.com/nl-be/data/gg577609.aspx "Reactive Extensions on MSDN"). It centralizes publishing and subscribing into one IObservable<object>. I tend to use this only as an internal mechanism to wire up command handlers and event publishers.
