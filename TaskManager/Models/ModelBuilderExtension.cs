using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed-Daten für TodoTask
            modelBuilder.Entity<TodoTask>().HasData(
                new TodoTask
                {
                    Id = 1,
                    Title = "Projektbericht fertigstellen",
                    Description = "Den vierteljährlichen Projektbericht abschließen und an das Management senden.",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(5),
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = null,
                    Priority = 1
                },
                new TodoTask
                {
                    Id = 2,
                    Title = "Meeting mit Kunden",
                    Description = "Vorbereitungen für das Kundengespräch treffen und Präsentation erstellen.",
                    IsCompleted = true,
                    DueDate = DateTime.Now.AddDays(-2),
                    CreatedAt = DateTime.Now.AddDays(-15),
                    UpdatedAt = DateTime.Now.AddDays(-3),
                    Priority = 2
                },
                new TodoTask
                {
                    Id = 3,
                    Title = "Neue Funktionen implementieren",
                    Description = "Die neuen Features für das nächste Release programmieren.",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(10),
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = null,
                    Priority = 3
                }
            );

            // Seed-Daten für Note
            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = 1,
                    Title = "Meeting-Notizen",
                    Content = "Wichtige Punkte aus dem letzten Team-Meeting zur Projektplanung.",
                    Category = "Arbeit",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    UpdatedAt = null
                },
                new Note
                {
                    Id = 2,
                    Title = "Ideen für neues Projekt",
                    Content = "Brainstorming-Notizen für das kommende Projekt.",
                    Category = "Ideen",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new Note
                {
                    Id = 3,
                    Title = "Einkaufsliste",
                    Content = "Milch, Brot, Eier, Käse, Obst",
                    Category = "Persönlich",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = null
                }
            );
        }
    }
}