using System;

namespace ApplicationBus {
  /// <summary>
  /// Message bus used to distribute messages.
  /// </summary>
  public interface IBus : IObservable<object>, IDisposable {
    /// <summary>
    /// Adds the given <see cref="IObservable{T}"/> as a message source.
    /// </summary>
    /// <param name="observable">The publisher</param>
    void AddPublisher(IObservable<object> observable);
  }
}