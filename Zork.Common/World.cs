using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Zork
{
    public class World
    {
        public List<Room> Rooms { get; set; }

        public List<Item> Items { get; set; }

        [JsonIgnore]
        public ReadOnlyDictionary<string, Room> RoomsByName => new ReadOnlyDictionary<string, Room>(mRoomsByName);

        [JsonIgnore]
        public Dictionary<string, Item> ItemsByName => mItemsByName;

        public Player SpawnPlayer() => new Player(this, StartingLocation);

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mItemsByName = Items.ToDictionary(item => item.Name, room => room);

            mRoomsByName = Rooms.ToDictionary(room => room.Name, room => room);

            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
                room.UpdateItems(this);
            }
        }

        [JsonProperty]
        private string StartingLocation { get; set; }
        [JsonProperty]
        public int MaxInventory { get; set; }

        private Dictionary<string, Room> mRoomsByName;
        private Dictionary<string, Item> mItemsByName;
    }
}