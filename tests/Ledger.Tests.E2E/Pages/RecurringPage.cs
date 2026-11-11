using Microsoft.Playwright;

namespace Ledger.Tests.E2E.Pages;

/// <summary>
/// Page Object de la page /Recurring.
/// </summary>
public sealed class RecurringPage(IPage page) : BasePage(page)
{
    /// <summary>
    /// Titre principal de la page.
    /// </summary>
    public ILocator MainHeading => Page.GetByRole(AriaRole.Heading, new() { Level = 1 });

    /// <summary>
    /// Navigue vers la page et renvoie la réponse HTTP du serveur.
    /// </summary>
    public Task<IResponse?> NavigateAsync(string baseUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseUrl);
        return Page.GotoAsync(new Uri(new Uri(baseUrl), "/Recurring").ToString());
    }

    private ILocator EditModal => Page.Locator("#editModal");

    /// <summary>
    /// Crée une charge récurrente par la modale d'ajout.
    /// </summary>
    public async Task CreateAsync(string name, string pattern, string amount)
    {
        await Page.Locator("button[onclick='openCreateModal()']").First.ClickAsync();
        await EditModal.GetByLabel("Nom", new() { Exact = false }).First.FillAsync(name);
        await Page.Locator("#expensePattern").FillAsync(pattern);
        await Page.Locator("#expenseAmount").FillAsync(amount);
        await EditModal.Locator("button[type='submit']").ClickAsync();
        await Page.WaitForURLAsync(url => !url.Contains("handler=Save", StringComparison.Ordinal));
    }

    /// <summary>
    /// Remplace le motif de rapprochement de la première charge via la modale de modification.
    /// </summary>
    public async Task EditFirstPatternAsync(string newPattern)
    {
        await Page.Locator("button[onclick^='openEditModal(']").First.ClickAsync();
        await Page.Locator("#expensePattern").FillAsync(newPattern);
        await EditModal.Locator("button[type='submit']").ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    /// <summary>
    /// Motif affiché pour la première charge du tableau.
    /// </summary>
    public ILocator FirstRowPattern => Page.Locator("tr.recurring-item-row code").First;
}
