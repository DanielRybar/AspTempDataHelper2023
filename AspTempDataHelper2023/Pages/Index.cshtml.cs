using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspTempDataHelper2023.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _conf;
        public string? LastAccess { get; set; }
        public string AppName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
            AppName = _conf["Application:Name"] ?? "Moje aplikace";
        }

        public void OnGet()
        {
            LastAccess = Request.Cookies["last-access"] ?? DateTime.Now.ToString();
            _logger.LogInformation("Poslední návštěva: {LastAccess}", LastAccess);

            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(365),
                Secure = false,
                HttpOnly = false
            };
            Response.Cookies.Append("last-access",
                DateTime.Now.ToString(),
                options);
        }
    }
}