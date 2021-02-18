using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMvcRestApi.Interfaces;
using WebMvcRestApi.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebMvcRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAppleItunesClient _appleItunesClient;
        private readonly IConfiguration _configuration;

        public AlbumsController(IAppleItunesClient appleItunesClient, IConfiguration configuration)
        {
            _appleItunesClient = appleItunesClient;
            _configuration = configuration;
        }

        // GET api/albums?artistName={artistName}        
        public async Task<ActionResult<AlbumModel>> Get([RequiredFromQuery] string artistName)
        {
            if (artistName == null)
                return NotFound();

            // replace spaces with + and make lowercase, as stated in iTunes API documentation
            artistName = Regex.Replace(artistName, @"\s+", "+").ToLower();
            string url = _configuration["Urls:SearchAlbumsByArtist"].Replace("{artistName}", artistName);

            AlbumModel albums = await _appleItunesClient.LoadAlbums(url);

            if (albums == null)
                return NotFound();

            return albums;
        }
    }
}