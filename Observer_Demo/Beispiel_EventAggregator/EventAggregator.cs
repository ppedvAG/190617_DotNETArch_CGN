using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel_EventAggregator
{
    public static class EventAggregator
    {
        // 2 Methoden:
        // Subscribe(object subscriber, string message, Action callback); // ich interessiere mich für die Meldung "zuHeiß"
        // Publish(string "message",data...)

        // System.ValueTuple => ab .NET 4.7
        private static List<(object subscriber, string message, Action<object> callback)> subscriberList = new List<(object subscriber, string message, Action<object> callback)>();

        public static void Subscribe(object subscriber, string message, Action<object> callback)
        {
            subscriberList.Add((subscriber, message, callback));
        }
        public static void UnSubscribe(object subscriber, string message)
        {
            subscriberList.RemoveAll(x => x.subscriber == subscriber && x.message == message);
        }

        public static void Publish(string message,object data)
        {
            foreach (var item in subscriberList.Where(x => x.message == message))
            {
                item.callback?.Invoke(data);
            }
        }
    }
}
