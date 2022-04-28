using System;
using System.Collections.Generic;
using System.Drawing;

public static class __MenuManager
{
    static private string[] options;
    private static int currentpl, currentSong;

    public static User currentuser; 

    public static Home menuHome = new Home();
    public static Friends menuFriend = new Friends();
    public static Playlists menuPlaylist = new Playlists();

    public static Song song;

    public static void StartApplication(User user)
    {
        // assign the user to the application
        currentuser = user;

        // show the first menu upon application start
        Load(menuHome);
    }

    public static void Load(IMenu obj)
    {
        /* show the options from each class */
        options = obj.GetOptions();

        /* assemble the menu */
        string fullmenu = __Construct(obj.GetOptions());

        /* start class menu navigation and logic */
        obj.Run(fullmenu, currentuser);
    }

    public static void Update(IMenu obj)
    {
        Random rand = new Random();
        currentpl = rand.Next(currentuser.userPlaylists.Count);
        currentSong = rand.Next(currentuser.userPlaylists[currentpl].songList.Count);

        song = currentuser.userPlaylists[currentpl].songList[currentSong];
        Load(obj);
    }

    #region Menu loader
    public static string __Construct(string[] options)
    {
        // add the song if the song is present
        if (song != null) Console.WriteLine($"{song.ToString()}");

        // top half of the menu
        string top =
            $"\n::::::::::::::::::::::::::\n" +
            $"::                      ::\n";

        // options || middle half of the menu
        string middle = "";
        for (int i = 0; i < options.Length; i++)
        {
            /* WARNING :: Potential bug fixing needed with options above the limit putting this in a loop */

            while (options[i].Length != 16) options[i] += " ";

            // add the strings together based on option amount
            middle += $":: {i} - {options[i]} ::\n";
        }
        //bottom half of the menu
        string bottom =
            $"::                      ::\n" +
            $"::::::::::::::::::::::::::\n\n";

        string select = $"Selected: ";

        return $"{top}{middle}{bottom}{select}";
    }
    #endregion
}