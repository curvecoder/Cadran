using System.Data.Common;
using AwesomeAssertions;
using Ledger.Domain.Entities;
using Ledger.Features.Categories.Services;
using Ledger.Features.Security.Context;
using Ledger.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Ledger.Tests.Features.Categories;

public sealed class CategorySeedServiceTranslationQueryTests : IDisposable
{
    private const string UserId = "user-query-1";

    private readonly SqliteConnection _connection = new("DataSource=:memory:");
    private readonly CommandCapture _capture = new();
    private readonly AppDbContext _context;

    public CategorySeedServiceTranslationQueryTests()
    {
        _connection.Open();
        var currentUser = new Mock<ICurrentUserService>();
        currentUser.SetupGet(u => u.UserId).Returns(UserId);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .AddInterceptors(_capture)
            .Options;
        _context = new AppDbContext(options, currentUser.Object);
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task EnsureDefaultCategoriesForUserAsync_WhenCategoryTranslationsAreLoaded_FiltersByCategoryIdInSql()
    {
        await new CategorySeedService(_context, NullLogger<CategorySeedService>.Instance, TimeProvider.System)
            .EnsureDefaultCategoriesForUserAsync(UserId);
        _capture.Commands.Clear();

        await new CategorySeedService(_context, NullLogger<CategorySeedService>.Instance, TimeProvider.System)
            .EnsureDefaultCategoriesForUserAsync(UserId);

        var translationQueries = _capture.Commands
            .Where(c => c.Contains("FROM \"EntityTranslations\"", StringComparison.Ordinal))
            .ToList();
        translationQueries.Should().NotBeEmpty();
        translationQueries.Should().OnlyContain(c => c.Contains("\"EntityId\" IN", StringComparison.Ordinal));
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    private sealed class CommandCapture : DbCommandInterceptor
    {
        public List<string> Commands { get; } = [];

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            Commands.Add(command.CommandText);
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            Commands.Add(command.CommandText);
            return ValueTask.FromResult(result);
        }
    }
}
