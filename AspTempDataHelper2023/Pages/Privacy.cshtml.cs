using AspTempDataHelper2023.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspTempDataHelper2023.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Stránka načtena");
        }

        public IActionResult OnGetMessage(string txt)
        {
            TempData.AddMessage(Constants.Messages.MESSAGE_ID, new TempMessage(MessageType.Success, "Úspěch"));
            TempData.AddMessage(Constants.Messages.MESSAGE_ID, new TempMessage(MessageType.Warning, "Varování"));
            TempData.AddMessage(Constants.Messages.MESSAGE_ID, new TempMessage(MessageType.Danger, txt));
            
            _logger.LogError("Chyba");
            _logger.LogWarning("Varování");
            _logger.LogDebug("{txt}", txt);
            
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetMessage2(string txt)
        {
            TempData.AddMessage(Constants.Messages.MESSAGE_ID, new TempMessage(MessageType.Info, txt));
            return RedirectToPage("/Index");
        }
    }
}