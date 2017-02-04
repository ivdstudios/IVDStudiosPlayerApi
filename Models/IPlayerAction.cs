using System.Collections.Generic;

namespace IVDStudiosPlayerApi.Models
{
    public interface IPlayerAction
    {
        void Add(Player player); 
        IEnumerable<Player> GetAll(); 
        Player Find(string key); 
        Player Remove(string key); 
        void Update(Player player); 
    }
}