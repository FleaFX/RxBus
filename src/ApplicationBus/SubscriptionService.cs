using System;
using System.Reactive.Linq;

namespace ApplicationBus {
  /// <summary>
  /// Default implementation of <see cref="ISubscriptionService"/>.
  /// </summary>
  public sealed class SubscriptionService : ISubscriptionService {
    readonly IObservable<object> _observable;

    /// <summary>
    /// Creates a new instance of <see cref="SubscriptionService"/>.
    /// </summary>
    /// <param name="observable">The message bus to subscribe to.</param>
    public SubscriptionService(IObservable<object> observable) {
      if (observable == null) throw new ArgumentNullException("observable");
      _observable = observable;
    }

    /// <summary>
    /// Subscribes the given handler to the message bus. Only messages for which the given predicate resolves to true will be passed to the handler.
    /// </summary>
    /// <typeparam name="TMessage">The type of message to handle.</typeparam>
    /// <param name="canHandle">Determines if a message can be handled.</param>
    /// <param name="handle">The handler function.</param>
    /// <returns>An <see cref="IDisposable"/>.</returns>
    public IDisposable Subscribe<TMessage>(Predicate<TMessage> canHandle, Action<TMessage> handle) {
      if (canHandle == null) throw new ArgumentNullException("canHandle");
      if (handle == null) throw new ArgumentNullException("handle");
      // TODO: figure out how to unit test this
      return _observable.OfType<TMessage>().Where(msg => canHandle(msg)).Subscribe(handle);
    }
  }
}