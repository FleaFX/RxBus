using System;

namespace RxBus {
  /// <summary>
  /// Subscribes an action to the message bus.
  /// </summary>
  public interface ISubscriptionService {
    /// <summary>
    /// Subscribes the given handler to the message bus. Only messages for which the given predicate resolves to true will be passed to the handler.
    /// </summary>
    /// <typeparam name="TMessage">The type of message to handle.</typeparam>
    /// <param name="canHandle">Determines if a message can be handled.</param>
    /// <param name="handle">The handler function.</param>
    /// <returns>An <see cref="IDisposable"/>.</returns>
    IDisposable Subscribe<TMessage>(Predicate<TMessage> canHandle, Action<TMessage> handle);
  }
}