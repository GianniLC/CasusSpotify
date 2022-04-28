using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Home : IMenu
{
    // all the options for the current menu
    public string[] options = { "Exit", "Play song", "Stop stong", "Playlist", "Friends", "Settings WIP" };

    public Home()
    {

    }

    public string[] GetOptions()
    {
        return options;
    }

    public void Run(string menu, User user)
    {
        bool _active = true;

        while (_active)
        {
            Console.Write(menu);

            // ask for user input
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                Clear();

                if (x == 0) return;
                if (x == 1) __MenuManager.Update(__MenuManager.menuHome);
                if (x == 2) __MenuManager.song = null;
                if (x == 3) __MenuManager.Load(__MenuManager.menuPlaylist);
                if (x == 4) __MenuManager.Load(__MenuManager.menuFriend);
            }
            catch (FormatException e)
            {
                Clear();
                Console.WriteLine($"{e.Message} \n");
            }
        }
    }

    public void Clear()
    {
        Console.Clear();
    }
}