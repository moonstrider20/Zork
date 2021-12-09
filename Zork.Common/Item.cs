using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Zork
{
    public class Item : IEquatable<Item>
    {
        [JsonProperty(Order = 1)]
        public string Name { get; private set; }

        [JsonProperty(Order = 2)]
        public string Description { get; private set; }

        [JsonProperty(Order = 3)]
        public int Points { get; private set; }

        [JsonProperty(Order = 4)]
        public int Weight { get; private set; }

        public static bool operator ==(Item lhs, Item rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Item lhs, Item rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Item item ? this == item : false;

        public bool Equals(Item other) => this == other;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();
    }
}