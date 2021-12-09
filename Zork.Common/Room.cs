using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Zork
{
    public class Room : IEquatable<Room>//, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(Order = 1)]
        public string Name { get; private set; }

        [JsonProperty(Order = 2)]
        public string Description { get; private set; }

        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        private Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }

        [JsonProperty(PropertyName = "Items", Order = 4)]
        public List<string> ItemNames { get; set; }

        [JsonIgnore]
        public Dictionary<string, Item> Items { get; private set; } = new Dictionary<string, Item>();

        public static bool operator ==(Room lhs, Room rhs)
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

        public static bool operator !=(Room lhs, Room rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Room room ? this == room : false;

        public bool Equals(Room other) => this == other;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();

        public void UpdateNeighbors(World world) => Neighbors = (from entry in NeighborNames
                                                                 let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                                                                 where room != null
                                                                 select (Direction: entry.Key, Room: room))
                                                                 .ToDictionary(pair => pair.Direction, pair => pair.Room);

        public void UpdateItems(World world)
        {
            foreach (var entry in ItemNames)
            {
                for (int itemEntry = 0; itemEntry < world.Items.Count; itemEntry++)
                {
                    if (entry == world.Items[itemEntry].Name.ToString())
                    {
                        Items.Add(entry, world.Items[itemEntry]);
                        break;
                    }
                }
            }
        }
    }
}