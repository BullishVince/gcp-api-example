using Microsoft.AspNetCore.Mvc;
using Api.Services;
using FirestoreApiExample.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FirestoreController : ControllerBase
    {

        private readonly ILogger<FirestoreController> _logger;
        private readonly IFirestoreService _firestoreService;

        public FirestoreController(
            ILogger<FirestoreController> logger,
            IFirestoreService firestoreService
            )
        {
            _logger = logger;
            _firestoreService = firestoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetData() 
        {
            var result = await _firestoreService.GetData();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] CryptoOverview cryptoOverview) 
        {
            var result = await _firestoreService.PostData(cryptoOverview);
            return Ok(result);
        }    
    }
}
