using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using System.Text;

namespace miguelestradam.Data
{
    public class CacheModel
    {
        private readonly IDistributedCache _cache;

        public CacheModel(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string? CachedTimeUTC { get; set; }
        public string? ASP_Environment { get; set; }

        public async Task OnGetAsync()
        {
            CachedTimeUTC = "Cached Time Expired";
            var encodedCachedTimeUTC = await _cache.GetAsync("cachedTimeUTC");

            if (encodedCachedTimeUTC != null)
            {
                CachedTimeUTC = Encoding.UTF8.GetString(encodedCachedTimeUTC);
            }

            ASP_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(ASP_Environment))
            {
                ASP_Environment = "Null, so Production";
            }
        }
    }
}