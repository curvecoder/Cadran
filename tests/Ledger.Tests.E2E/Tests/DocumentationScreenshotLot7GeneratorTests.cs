using AwesomeAssertions;
using Ledger.Features.Accounts.Entities;
using Ledger.Features.Accounts.Services;
using Ledger.Features.Categories.Services;
using Ledger.Features.Security.Context;
using Ledger.Features.Security.Models;
using Ledger.Infrastructure.Data;
using Ledger.Tests.E2E.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace Ledger.Tests.E2E.Tests;

/// <summary>
/// Generates the annotated screenshot of the manual entry reconciliation screen (guide 25), in English.
/// </summary>
[Collection(E2ETestCollection.Name)]
public sealed class DocumentationScreenshotLot7GeneratorTests(AppWebTestFixture webFixture, PlaywrightFixture playwrightFixture)
    : E2ETestBase(webFixture, playwrightFixture)
{
    private const string Email = "sarah.connor@cadran.local";
    private const string Password = "Password123";

    private static readonly string ArtifactsDirectory = Path.Combine(Path.GetTempPath(), "cadran-doc-screenshots");

    [Fact]
    public async Task GenerateLot7Screenshots_WhenExecuted_CapturesReconcileScreenInEnglish()
    {
        Directory.CreateDirectory(ArtifactsDirectory);

        var keyHolder = WebFixture.KestrelServices.GetRequiredService<IDatabaseKeyHolder>();
        keyHolder.SetKey(null, isEncrypted: false);

        await SeedManualAndImportedPairAsync();
        await LoginAndSetEnglishAsync();
        await CaptureReconcileScreenAsync();
    }

    private async Task SeedManualAndImportedPairAsync()
    {
        using var scope = WebFixture.KestrelServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var categorySeedService = scope.ServiceProvider.GetRequiredService<ICategorySeedService>();
        var accountTypeService = scope.ServiceProvider.GetRequiredService<IAccountTypeService>();

        var user = await userManager.FindByEmailAsync(Email);
        if (user == null)
        {
            user = new ApplicationUser { UserName = Email, Email = Email, FullName = "Sarah Connor", EmailConfirmed = true };
            (await userManager.CreateAsync(user, Password)).Succeeded.Should().BeTrue();
        }

        await categorySeedService.EnsureDefaultCategoriesForUserAsync(user.Id);
        await accountTypeService.EnsureDefaultAccountTypesForUserAsync(user.Id);

        var bank = new Bank { UserId = user.Id, Name = "BoursoBank", ColorHex = "#0284c7" };
        db.Banks.Add(bank);
        await db.SaveChangesAsync();

        var checkingType = await db.CustomAccountTypes.IgnoreQueryFilters()
            .FirstOrDefaultAsync(t => t.UserId == user.Id && t.Code == "Checking");

        var account = new BankAccount
        {
            UserId = user.Id,
            BankId = bank.Id,
            CustomAccountTypeId = checkingType?.Id,
            Name = "Main Checking Account",
            Type = AccountType.Checking,
            Currency = "EUR",
            InitialBalance = 2845.50m
        };
        db.BankAccounts.Add(account);
        await db.SaveChangesAsync();

        // Les deux dates restent dans le mois courant, même un 1er ou un 2 du mois.
        var today = DateTime.Today;
        db.Transactions.AddRange(
            new Transaction
            {
                UserId = user.Id,
                BankAccountId = account.Id,
                Date = today,
                Label = "Bakery",
                Amount = 12.50m,
                Type = TransactionType.Debit,
                Origin = TransactionOrigin.Manual,
            },
            new Transaction
            {
                UserId = user.Id,
                BankAccountId = account.Id,
                Date = today,
                Label = "CARD PAYMENT LA BOULANGERIE PARIS",
                Amount = 12.50m,
                Type = TransactionType.Debit,
                Origin = TransactionOrigin.Import,
            });
        await db.SaveChangesAsync();
    }

    private async Task LoginAndSetEnglishAsync()
    {
        await Page.GotoAsync($"{BaseUrl}/Security/Login", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        await Page.FillAsync("input[name='Input.Email']", Email);
        await Page.FillAsync("input[name='Input.Password']", Password);
        await Page.ClickAsync("button[type='submit']");
        await Page.WaitForURLAsync("**/Accounts*");
        await Page.GotoAsync($"{BaseUrl}/SetLanguage?culture=en&returnUrl=%2FAccounts%2FReconcile", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
    }

    private async Task CaptureReconcileScreenAsync()
    {
        await Page.SetViewportSizeAsync(1440, 950);
        await Page.GotoAsync($"{BaseUrl}/Accounts/Reconcile", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

        (await Page.Locator("[data-testid='reconcile-table']").IsVisibleAsync()).Should().BeTrue();

        var cleanPath = Path.Combine(ArtifactsDirectory, "25-manual-reconciliation-screen.png");
        var annotatedPath = Path.Combine(ArtifactsDirectory, "25-manual-reconciliation-screen-annotated.png");

        await Page.ScreenshotAsync(new PageScreenshotOptions { Path = cleanPath, FullPage = false });

        await Page.EvaluateAsync(@"() => {
            const items = [
                { targetSelector: ""[data-testid^='reconcile-row-'] td:nth-child(1)"", number: '1', actionColor: '#0284c7' },
                { targetSelector: ""[data-testid^='reconcile-row-'] td:nth-child(2)"", number: '2', actionColor: '#ca8a04' },
                { targetSelector: ""[data-testid^='reconcile-merge-']"", number: '3', actionColor: '#16a34a' }
            ];

            const container = document.createElement('div');
            container.style.position = 'absolute';
            container.style.top = '0';
            container.style.left = '0';
            container.style.width = '100%';
            container.style.height = '100%';
            container.style.pointerEvents = 'none';
            container.style.zIndex = '999999';
            document.body.appendChild(container);

            items.forEach((item) => {
                const target = document.querySelector(item.targetSelector);
                if (!target) return;

                const tRect = target.getBoundingClientRect();

                const ring = document.createElement('div');
                ring.style.position = 'absolute';
                ring.style.left = `${tRect.left - 3}px`;
                ring.style.top = `${tRect.top - 3}px`;
                ring.style.width = `${tRect.width + 6}px`;
                ring.style.height = `${tRect.height + 6}px`;
                ring.style.border = `2px solid ${item.actionColor}`;
                ring.style.borderRadius = '6px';
                ring.style.boxShadow = `0 0 0 3px ${item.actionColor}25`;
                container.appendChild(ring);

                const pin = document.createElement('div');
                pin.textContent = item.number;
                pin.style.position = 'absolute';
                pin.style.left = `${tRect.left - 10}px`;
                pin.style.top = `${tRect.top - 10}px`;
                pin.style.width = '24px';
                pin.style.height = '24px';
                pin.style.borderRadius = '50%';
                pin.style.backgroundColor = item.actionColor;
                pin.style.color = '#fff';
                pin.style.fontSize = '12px';
                pin.style.fontWeight = '700';
                pin.style.display = 'flex';
                pin.style.alignItems = 'center';
                pin.style.justifyContent = 'center';
                pin.style.border = '2px solid #fff';
                pin.style.boxShadow = '0 2px 6px rgba(0,0,0,0.35)';
                pin.style.zIndex = '100002';
                container.appendChild(pin);
            });
        }");

        await Page.ScreenshotAsync(new PageScreenshotOptions { Path = annotatedPath, FullPage = false });
    }
}
