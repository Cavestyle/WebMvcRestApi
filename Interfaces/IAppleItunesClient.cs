using WebMvcRestApi.Models;
using System.Threading.Tasks;

namespace WebMvcRestApi.Interfaces
{
    public interface IAppleItunesClient
    {
        Task<AlbumModel> LoadAlbums(string url);
    }
}