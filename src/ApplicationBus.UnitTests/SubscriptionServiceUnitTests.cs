using System;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationBus.UnitTests {
  [TestClass]
  public class SubscriptionServiceUnitTests {
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RequiresMessageBus() {
      new SubscriptionService(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void HandleRequiresPredicate() {
      var subscriptionService = new SubscriptionService(A.Dummy<IBus>());
      subscriptionService.Subscribe(null, A.Dummy<Action<object>>());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void HandleRequiresAction() {
      var subscriptionService = new SubscriptionService(A.Dummy<IBus>());
      subscriptionService.Subscribe(A.Dummy<Predicate<object>>(), null);
    }
  }
}