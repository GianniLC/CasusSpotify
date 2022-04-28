using System;

public class Program
{
    /* The most empty main program i'll ever make im pretty sure */
    private static User gianni;
    private static User kyara;
    private static User rick;

    /* Make this true if you want to be able to login and switch between accounts */ 
    private static bool login = false;

    static void Main(string[] args)
    {
        __Init();

        if (login) { __MenuManager.StartApplication(Login()); }

        if (!login) { __MenuManager.StartApplication(gianni); }
    }

    private static void __Init()
    {
        /* define some users || true for debugging mode || Debug mode is basically adding a preset of songs */
        gianni = new User("Gianni", true);
        kyara = new User("Kyara de Winter", true);
        rick = new User("Rick de Jong");

        /* Create some unique playlists for each */
        kyara.userPlaylists[0].Name = "First playlist";
        kyara.userPlaylists[1].Name = "Second playlist";
        kyara.userPlaylists.Add(new Playlist("Bunny hops"));
        kyara.userPlaylists.Add(new Playlist("Feels"));

        rick.userPlaylists.Add(new Playlist("Metal"));
        rick.userPlaylists.Add(new Playlist("Happy hardcore"));

        /* Add a friend to the user */
        gianni.friendList.Add(kyara);
        gianni.friendList.Add(rick);

        kyara.friendList.Add(gianni);
        kyara.friendList.Add(rick);

        rick.friendList.Add(kyara);
        rick.friendList.Add(gianni);
    }

    private static User Login()
    {
        Console.Write("What account would you like to login with?\n1 - Gianni\n2 - Kyara\n3 - Rick\n\nSelected: ");

        try
        {
            int x = Convert.ToInt32(Console.ReadLine());

            if (x == 1) return gianni;
            if (x == 2) return kyara;
            if (x == 3) return rick;

        } catch (Exception e)
        {
            Console.WriteLine(e.Message.Substring(0, 24));
        }

        return gianni;
    }
}