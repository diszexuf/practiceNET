using System;
using System.Collections.Generic;
using practiceNET;

class Program
{
    static void Main()
    {
        Genre rockGenre = new Genre("Rock", "Rock music genre");
        Genre popGenre = new Genre("Pop", "Pop music genre");

        Composition song1 = new Composition { Title = "Song 1", Duration = 240, ReleaseYear = 2022, Genre = rockGenre };
        Composition song2 = new Composition { Title = "Song 2", Duration = 180, ReleaseYear = 2021, Genre = rockGenre };

        Author author1 = new Author { Name = "Author 1", Biography = "Biography of Author 1" };
        Author author2 = new Author { Name = "Author 2", Biography = "Biography of Author 2" };
        Performer performer1 = new Performer { Name = "Performer 1", Biography = "Biography of Performer 1" };

        Album album1 = new Album { Title = "Album 1", ReleaseYear = 2021, Compositions = new List<Composition> { song1, song2 } };
        Album album2 = new Album { Title = "Album 2", ReleaseYear = 2022, Compositions = new List<Composition> { song1 } };

        Library userLibrary = new Library
        {
            Compositions = new List<Composition> { song1, song2 },
            Albums = new List<Album> { album1, album2 },
            Genres = new List<Genre> { rockGenre, popGenre }
        };

        NewsSource newsSource1 = new NewsSource { Name = "Music News" };
        NewsSource newsSource2 = new NewsSource { Name = "Entertainment Updates" };
        News news1 = new News
        {
            Headline = "New Album Release",
            Text = "Artist XYZ releases a new album.",
            PublicationDate = DateTime.Now
        };
        News news2 = new News
        {
            Headline = "Concert Announcement",
            Text = "Performer ABC announces a concert tour.",
            PublicationDate = DateTime.Now
        };

        newsSource1.AddNews(news1);
        newsSource2.AddNews(news2);

        User user = new User
        {
            Name = "User",
            PersonalLibrary = userLibrary,
            Subscriptions = new List<NewsSource> { newsSource1, newsSource2 }
        };

        while (true)
        {
            Console.WriteLine("Welcome, " + user.Name);
            Console.WriteLine("1. Manage Music Library");
            Console.WriteLine("2. View Subscribed News");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    user.ManageLibrary();
                    break;
                case 2:
                    user.ViewNews();
                    break;
                case 3:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
