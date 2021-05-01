using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Identity.Data.Models;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Notes.Data
{
    public sealed class Seeder
    {
        private readonly NoteWorxDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private static readonly Random _random = new(1);

        private IReadOnlyList<AppUser> _users = Enumerable.Empty<AppUser>().ToList();
        private IReadOnlyList<Note> _notes = Enumerable.Empty<Note>().ToList();


        public Seeder(NoteWorxDbContext context, UserManager<AppUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context.Database.Migrate();
        }

        public IReadOnlyList<Note> Notes => _notes;
        public IReadOnlyList<AppUser> Users => _users;

        public void Seed()
        {
            SeedUsers();
            SeedNotes();
            _context.SaveChanges();
        }

        public Seeder IncludeNotes(string notesFilePath)
        {
            if (_context.Notes.Any())
                return this;

            _notes = GetData<Note>(notesFilePath);

            return this;
        }

        public Seeder IncludeUsers(string usersFilePath)
        {
            if (_context.Users.Any())
                return this;

            _users = GetData<AppUser>(usersFilePath);

            return this;
        }

        private void SeedUsers()
        {
            if (_context.Users.Any() || !_users.Any())
                return;

            foreach (var user in _users)
            {
                var result = _userManager.CreateAsync(user, "P@ssword123!").Result;

                if (!result.Succeeded)
                {
                    var reasons = string.Join("", result.Errors.Select(e => e.Description).ToList());
                    throw new InvalidOperationException($"Create user failed. {reasons}.");
                }
            }
        }

        private void SeedNotes()
        {
            var hasRequiredDataToCreateNotes =
               _context.Users.Any() && _notes.Any();

            if (_context.Notes.Any() || !hasRequiredDataToCreateNotes)
                return;

            var usersFromDb = _context.Users.ToList();

            foreach (var note in _notes)
            {
                var userIndex = _random.Next(0, usersFromDb.Count - 1);
                note.UserId = usersFromDb.ElementAt(userIndex).Id;
            }

            _context.Notes.AddRange(_notes);
            _context.SaveChanges();
        }

        private static IReadOnlyList<T> GetData<T>(string entityFilePath)
        {
            if (string.IsNullOrWhiteSpace(entityFilePath))
            {
                var message = $"The specified parameter '{entityFilePath}'" +
                  " may not be null, empty, or whitespace.";

                throw new ArgumentException(message, nameof(entityFilePath));
            }

            if (!File.Exists(entityFilePath))
            {
                throw new FileNotFoundException(
                   $"The path '{entityFilePath}' could not be found.",
                   entityFilePath);
            }

            var content = File.ReadAllText(entityFilePath);

            if (string.IsNullOrWhiteSpace(content))
            {
                var message = $"The specified file '{entityFilePath}'" +
                   " contains no data.";

                throw new InvalidDataException(message);
            }

            var entities = JsonSerializer.Deserialize<T[]>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (entities == null || !entities.Any())
            {
                var message = $"Expected list of {typeof(T).Name}'s but" +
                   $" received none for specified file '{entityFilePath}'";

                throw new InvalidDataException(message);
            }

            return entities;
        }
    }
}
