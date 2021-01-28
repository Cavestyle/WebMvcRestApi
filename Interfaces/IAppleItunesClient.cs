using OpendorseWebMvc.Models;
using System.Threading.Tasks;

namespace OpendorseWebMvc.Interfaces
{
    public interface IAppleItunesClient
    {
        Task<AlbumModel> LoadAlbums(string url);
    }
}