using Microsoft.Playwright;

namespace Ledger.Tests.E2E.Pages;

/// <summary>
/// Page Object de la page /Imports.
/// </summary>
public sealed class ImportsPage(IPage page) : BasePage(page)
{
    /// <summary>
    /// Titre principal de la page.
    /// </summary>
    public ILocator MainHeading => Page.GetByRole(AriaRole.Heading, new() { Level = 1 });

    /// <summary>
    /// Bandeau de notification affiché après une action.
    /// </summary>
    public ILocator StatusNotification => Page.GetByTestId("import-status");

    /// <summary>
    /// Nombre d'opérations ajoutées par chaque lot de l'historique, du plus récent au plus ancien.
    /// </summary>
    public ILocator BatchTotals => Page.GetByTestId("import-batch-total");

    /// <summary>
    /// Dépose un fichier OFX et lance l'import sans sélectionner de compte.
    /// </summary>
    public async Task UploadOfxAsync(string fileName, string content)
    {
        await Page.GetByTestId("import-file").SetInputFilesAsync(new FilePayload
        {
            Name = fileName,
            MimeType = "application/x-ofx",
            Buffer = System.Text.Encoding.ASCII.GetBytes(content)
        });
        await Page.GetByTestId("import-submit").ClickAsync();
    }

    /// <summary>
    /// Affecte le fichier en attente à un compte existant.
    /// </summary>
    public async Task ImportPendingFileIntoAsync(Guid accountId)
    {
        await Page.GetByTestId("import-pending-account").SelectOptionAsync(accountId.ToString());
        await Page.GetByTestId("import-pending-submit").ClickAsync();
    }

    /// <summary>
    /// Coche le premier doublon suspecté et confirme son import.
    /// </summary>
    public async Task ConfirmFirstDuplicateAsync()
    {
        await Page.GetByTestId("import-duplicate-checkbox").First.CheckAsync();
        await Page.GetByTestId("import-duplicates-submit").ClickAsync();
    }

    /// <summary>
    /// Navigue vers la page et renvoie la réponse HTTP du serveur.
    /// </summary>
    public Task<IResponse?> NavigateAsync(string baseUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseUrl);
        return Page.GotoAsync(new Uri(new Uri(baseUrl), "/Imports").ToString());
    }
}
