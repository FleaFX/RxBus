using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationBus.UnitTests {
  [TestClass]
  public class InMemoryBusUnitTests {
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddPublisherRequiresObservable() {
      using (var bus = new InMemoryBus()) {
        bus.AddPublisher(null);
      }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SubscribingRequiresObserver() {
      using (var bus = new InMemoryBus()) {
        bus.Subscribe(null);
      }
    }

    [TestMethod]
    public void WhenAddedPublisherPublishesMessageThenMessageIsPublishedOnBus() {
      using (var bus = new InMemoryBus()) {
        var publisher = new Subject<object>();
        bus.AddPublisher(publisher);

        var messagesPublishedByBus = new List<object>();
        bus.Subscribe(messagesPublishedByBus.Add);

        var message = new object();
        publisher.OnNext(message);

        Assert.IsTrue(messagesPublishedByBus.Contains(message));
      }
    }
  }
}