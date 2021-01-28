using OpendorseWebMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpendorseWebMvc.Interfaces
{
    public interface IAlbumProcessor
    {
        Task<List<Album>> ProcessAlbums(string url);
    }
}