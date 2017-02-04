using System;
using System.Collections.Generic;
using System.Collections.Concurrent; 

namespace IVDStudiosPlayerApi.Models
{
    public class PlayerAction : IPlayerAction
    {
        private static ConcurrentDictionary<string, Player> _players =
            new ConcurrentDictionary<string, Player>(); 

        public PlayerAction()
        {
            Add(new Player { Name = "Default", Email = "deafult@test.com", Age = 100});
        }

        public void Add(Player player)
        {
            player.Key = Guid.NewGuid().ToString();
            _players[player.Key] = player; 
        }

        public IEnumerable<Player> GetAll()
        {
            return _players.Values; 
        }

        public Player Find(string key)
        {
            Player player;
            _players.TryGetValue(key, out player);
            return player; 
        }

        public Player Remove(string key)
        {
            Player player; 
            _players.TryRemove(key, out player); 
            return player; 
        }

        public void Update(Player player)
        {
            _players[player.Key] = player; 
        }
    }
}