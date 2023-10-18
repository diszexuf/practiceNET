using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceNET
{
    class Composition
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Composition: {Title}, Duration: {Duration} seconds, Release Year: {ReleaseYear}, Genre: {Genre.Name}");
        }
    }

    class MusicArtist
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Music Artist: {Name}");
        }
    }

    class Author : MusicArtist
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Author: {Name}");
        }
    }

    class Performer : MusicArtist
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Performer: {Name}");
        }
    }

    class Album
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public List<Composition> Compositions { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Album: {Title}, Release Year: {ReleaseYear}");
        }
    }

    class Genre
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<Genre> AllGenres { get; } = new List<Genre>();

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
            AllGenres.Add(this);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Genre: {Name}");
        }
    }

    class Library
    {
        public List<Composition> Compositions { get; set; }
        public List<Album> Albums { get; set; }
        public List<Genre> Genres { get; set; }

        public void AddComposition(Composition composition)
        {
            Compositions.Add(composition);
        }

        public void RemoveComposition(Composition composition)
        {
            Compositions.Remove(composition);
        }

        public List<Composition> SearchCompositionsByGenre(Genre genre)
        {
            return Compositions.FindAll(c => genre.Name == c.Genre.Name);
        }
    }

    class News
    {
        public string Headline { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"News: {Headline}, Publication Date: {PublicationDate}");
        }
    }

    class NewsSource
    {
        public string Name { get; set; }
        public List<News> NewsItems { get; set; } = new List<News>();

        public void AddNews(News news)
        {
            NewsItems.Add(news);
        }

        public void RemoveNews(News news)
        {
            NewsItems.Remove(news);
        }
    }

    class User
    {
        public string Name { get; set; }
        public Library PersonalLibrary { get; set; }
        public List<NewsSource> Subscriptions { get; set; }

        public void ManageLibrary()
        {
            Console.Clear();
            Console.WriteLine("Manage Your Music Library");
            Console.WriteLine("1. Add a New Composition to Library");
            Console.WriteLine("2. Remove Composition from Library");
            Console.WriteLine("3. View Library Contents");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Add a New Composition to Your Library");

                    Console.Write("Enter the title of the composition: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter the duration of the composition (in seconds): ");
                    int duration = int.Parse(Console.ReadLine());

                    Console.Write("Enter the release year of the composition: ");
                    int releaseYear = int.Parse(Console.ReadLine());

                    Console.Write("Enter the genre of the composition: ");
                    string genreName = Console.ReadLine();

                    // Check if the genre exists in the library's list of genres
                    Genre genre = PersonalLibrary.Genres.Find(g => g.Name == genreName);
                    if (genre == null)
                    {
                        // If the genre doesn't exist, you can create a new one and add it to the library
                        genre = new Genre(genreName, "Description of " + genreName);
                        PersonalLibrary.Genres.Add(genre);
                    }

                    Composition newComposition = new Composition
                    {
                        Title = title,
                        Duration = duration,
                        ReleaseYear = releaseYear,
                        Genre = genre
                    };

                    PersonalLibrary.Compositions.Add(newComposition);
                    Console.WriteLine("Composition added to your library.");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter the title of the composition to remove: ");
                    string titleToRemove = Console.ReadLine();
                    Composition compositionToRemove = PersonalLibrary.Compositions.Find(c => c.Title == titleToRemove);
                    if (compositionToRemove != null)
                    {
                        PersonalLibrary.Compositions.Remove(compositionToRemove);
                        Console.WriteLine("Composition removed from your library.");
                    }
                    else
                    {
                        Console.WriteLine("The composition was not found in your library.");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Your Music Library Contents:");
                    foreach (Composition composition in PersonalLibrary.Compositions)
                    {
                        composition.DisplayInfo();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void ViewNews()
        {
            Console.Clear();
            Console.WriteLine("View Your Subscribed News");

            if (Subscriptions.Count == 0)
            {
                Console.WriteLine("You are not subscribed to any news sources.");
            }
            else
            {
                Console.WriteLine("Select a news source to view:");
                for (int i = 0; i < Subscriptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Subscriptions[i].Name}");
                }

                Console.Write("Enter the number of the news source: ");
                int sourceNumber = int.Parse(Console.ReadLine());

                if (sourceNumber >= 1 && sourceNumber <= Subscriptions.Count)
                {
                    Console.Clear();
                    NewsSource selectedSource = Subscriptions[sourceNumber - 1];
                    Console.WriteLine($"News from {selectedSource.Name}:");

                    foreach (News news in selectedSource.NewsItems)
                    {
                        news.DisplayInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }

}
