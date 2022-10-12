using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class AlbumInventoryService
    {
        private List<Album> _albumList = new List<Album>();
        private readonly string _albumsFilePath;

        public AlbumInventoryService(string albumsFilePath)
        {
            _albumsFilePath = albumsFilePath;

            string contents = File.ReadAllText(_albumsFilePath);

            _albumList = JsonSerializer.Deserialize<List<Album>>(contents);
        }

        public void Add(Album album)
        {
            _albumList.Add(album);
        }

        public void AddRange(IEnumerable<Album> albums)
        {
            _albumList.AddRange(albums);
        }

        public void ListAlbums()
        {
            for (int i = 0; i < _albumList.Count; i++)
            {
                var album = _albumList[i].GetDetails();
                Console.WriteLine($"{i + 1}. {album}");
            }
        }

        public IAlbum SelectAlbumByIndex(int index)
        {
            return _albumList[index - 1];
        }

        public void Save()
        {
            var serializedAlbums = JsonSerializer.Serialize<List<Album>>(_albumList);

            File.WriteAllText(_albumsFilePath, serializedAlbums);
        }

    }
}
