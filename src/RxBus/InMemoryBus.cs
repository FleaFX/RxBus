using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace RxBus {
  /// <summary>
  /// Implementation of <see cref="IBus"/> that keeps publishers and subscriptions in memory.
  /// </summary>
  public sealed class InMemoryBus : IBus {
    readonly Subject<object> _subject;
    readonly List<IDisposable> _publisherSubscriptions;

    /// <summary>
    /// Creates a new instance of <see cref="InMemoryBus"/>.
    /// </summary>
    public InMemoryBus() {
      _subject = new Subject<object>();
      _publisherSubscriptions = new List<IDisposable>();
    }


    /// <summary>
    /// Adds the given <see cref="IObservable{T}"/> as a message source.
    /// </summary>
    /// <param name="observable">The publisher</param>
    public void AddPublisher(IObservable<object> observable) {
      if (observable == null) throw new ArgumentNullException("observable");
      _publisherSubscriptions.Add(observable.Subscribe(msg => _subject.OnNext(msg)));
    }

    /// <summary>
    /// Notifies the provider that an observer is to receive notifications.
    /// </summary>
    /// <returns>
    /// A reference to an interface that allows observers to stop receiving notifications before the provider has finished sending them.
    /// </returns>
    /// <param name="observer">The object that is to receive notifications.</param>
    public IDisposable Subscribe(IObserver<object> observer) {
      return _subject.Subscribe(observer);
    }

    bool _disposed;
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public void Dispose() {
      if (!_disposed) {
        _publisherSubscriptions.ForEach(d => d.Dispose());
        _subject.Dispose();
      }
      _disposed = true;
    }
  }
}