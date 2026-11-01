using AwesomeAssertions;
using Ledger.Tests.E2E.Infrastructure;

namespace Ledger.Tests.E2E.Tests;

/// <summary>
/// Garantit que la suite E2E travaille sur sa base temporaire et non sur la base partagée du dossier de sortie.
/// </summary>
[Collection(E2ETestCollection.Name)]
public sealed class TestDatabaseIsolationTests(AppWebTestFixture webFixture)
{
    [Fact]
    public void Fixture_WhenServerStarted_CreatesTemporaryDatabaseFile()
    {
        // Arrange
        webFixture.EnsureServerStarted();

        // Act
        var exists = File.Exists(webFixture.DatabasePath);

        // Assert
        exists.Should().BeTrue("la chaîne de connexion du fixture doit atteindre l'application");
    }
}
