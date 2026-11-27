using AwesomeAssertions;
using Ledger.Tests.E2E.Infrastructure;
using Ledger.Tests.E2E.Pages;
using Microsoft.AspNetCore.Http;
using static Microsoft.Playwright.Assertions;

namespace Ledger.Tests.E2E.Tests;

/// <summary>
/// Tests E2E de la page Imports.
/// </summary>
[Collection(E2ETestCollection.Name)]
public sealed class ImportsPageTests(AppWebTestFixture webFixture, PlaywrightFixture playwrightFixture)
    : AuthenticatedE2ETestBase(webFixture, playwrightFixture)
{
    [Fact]
    public async Task ImportsPage_WhenLoaded_DisplaysMainContent()
    {
        // Arrange
        await RegisterAndSignInAsync();
        var page = new ImportsPage(Page);

        // Act
        var response = await page.NavigateAsync(BaseUrl);

        // Assert
        response.Should().NotBeNull();
        response.Status.Should().Be(StatusCodes.Status200OK);
        await Expect(page.MainHeading).ToBeVisibleAsync();
    }

    [Fact]
    public async Task ConfirmDuplicates_WhenAccountChosenAfterUpload_ImportsCheckedOperation()
    {
        // Arrange : deux opérations identiques à FITID distincts, la seconde est un doublon suspecté
        var (page, accountId) = await OpenImportsWithAccountAsync();
        await page.UploadOfxAsync("releve.ofx", BuildOfx("FIT0001", "FIT0002"));
        await page.ImportPendingFileIntoAsync(accountId);

        // Act
        await page.ConfirmFirstDuplicateAsync();

        // Assert
        await Expect(page.StatusNotification).ToBeVisibleAsync();
        await Expect(page.BatchTotals).ToHaveTextAsync(["+2"]);
    }

    [Fact]
    public async Task ConfirmDuplicates_WhenAccountMatchedByOfxId_ImportsCheckedOperation()
    {
        // Arrange : le premier import mémorise l'ACCTID, le second est rattaché sans sélection de compte
        var (page, accountId) = await OpenImportsWithAccountAsync();
        await page.UploadOfxAsync("releve.ofx", BuildOfx("FIT0001"));
        await page.ImportPendingFileIntoAsync(accountId);
        await Expect(page.BatchTotals).ToHaveTextAsync(["+1"]);
        await page.UploadOfxAsync("releve-suivant.ofx", BuildOfx("FIT0002"));

        // Act
        await page.ConfirmFirstDuplicateAsync();

        // Assert
        await Expect(page.StatusNotification).ToBeVisibleAsync();
        await Expect(page.BatchTotals).ToHaveTextAsync(["+1", "+1"]);
    }

    private async Task<(ImportsPage Page, Guid AccountId)> OpenImportsWithAccountAsync()
    {
        await RegisterAndSignInAsync();
        var accountId = await CreateAccountAndGetIdAsync();
        var page = new ImportsPage(Page);
        await page.NavigateAsync(BaseUrl);
        return (page, accountId);
    }

    private static string BuildOfx(params string[] references)
    {
        var operations = string.Concat(references.Select(reference =>
            $"<STMTTRN>\r\n<DTPOSTED>20260110\r\n<TRNAMT>-12.50\r\n<FITID>{reference}\r\n<NAME>BOULANGERIE DU CENTRE\r\n</STMTTRN>\r\n"));
        return $"OFXHEADER:100\r\n<OFX>\r\n<BANKACCTFROM>\r\n<ACCTID>00000000001\r\n</BANKACCTFROM>\r\n<BANKTRANLIST>\r\n{operations}</BANKTRANLIST>\r\n</OFX>\r\n";
    }
}
