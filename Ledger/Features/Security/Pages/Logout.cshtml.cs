using Ledger.Features.Security.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ledger.Features.Security.Pages;

public class LogoutModel(IAuthService authService, IDatabaseEncryptionService encryptionService) : PageModel
{
    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken = default)
    {
        await authService.SignOutAsync(cancellationToken);
        await encryptionService.LockUnlessRememberedAsync();
        return Redirect("/Security/Login");
    }

    // Un GET ne doit pas changer d'état : n'importe quelle page pourrait sinon déconnecter l'utilisateur
    // et reverrouiller la base par une simple image ou un lien. Seul le POST antiforgery déconnecte.
    public Task<IActionResult> OnGetAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IActionResult>(Redirect("/Security/Login"));
    }
}
