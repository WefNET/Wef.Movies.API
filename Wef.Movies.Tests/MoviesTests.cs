using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wef.Movies.API.Data;

namespace Wef.Movies.Tests
{
    public class MoviesTests
    {
        private DataContext? _context;

        [Fact]
        public async Task TestMoviesDb_Seeder()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("MovieDB_Test")
                .Options;

            _context = new DataContext(options);

            // When
            await new Seeder().SeedData(_context);

            // Then
            Assert.True(await _context.Movies.FirstOrDefaultAsync() != null);
        }

        [Fact]
        public async Task TestMoviesDb_Search()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("MovieDB_Test2")
                .Options;

            _context = new DataContext(options);

            // When
            await new Seeder().SeedData(_context);

            var partial = "MaId";

            var movies = await _context.Movies
                .Where(s => s.Title.ToLowerInvariant().Contains(partial.ToLowerInvariant()))
                .Include(s => s.Actors)
                .ToListAsync();

            // Then
            Assert.True(movies != null);
        }
    }
}
