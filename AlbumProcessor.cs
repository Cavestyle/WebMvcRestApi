using OpendorseWebMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpendorseWebMvc.Interfaces

{
    public class AlbumProcessor : IAlbumProcessor
    {
        private IAlbumLoader _albumLoader;

        public AlbumProcessor(IAlbumLoader albumLoader)
        {
            _albumLoader = albumLoader;
        }
        public async Task<List<Album>> ProcessAlbums(string url)
        {           
            return await _albumLoader.LoadAlbums(url);
        }
    }
}