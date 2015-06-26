using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Events
{
    public class EventSerialiser
    {
        readonly static Lazy<EventSerialiser> instance = new Lazy<EventSerialiser>(() => new EventSerialiser(), true);

        public static EventSerialiser Instance
        {
            get { return instance.Value; }
        }

        public EventSerialiser(bool isPretty = false)
        {
            this.isPretty = isPretty;
        }

        readonly bool isPretty;

        public T Deserialize<T>(string serialization)
        {
            return JsonConvert.DeserializeObject<T>(serialization);
        }

        public object Deserialize(string serialization, Type type)
        {
            return JsonConvert.DeserializeObject(serialization, type);
        }

        public string Serialize(IDomainEvent domainEvent)
        {
            return JsonConvert.SerializeObject(domainEvent, this.isPretty ? Formatting.Indented : Formatting.None);
        }
    }
}
