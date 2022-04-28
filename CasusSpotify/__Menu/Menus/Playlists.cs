using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Playlists : IMenu
{

    public string[] options = { "Go Home", "Create new", "Show playlist", "Edit playlist", "Delete playlist"};
    public string[] options2 = { "Go back", "Show all songs", "Add a song", "Delete a song", "Rename playlist" };

    private bool __NoSwitch = true;
    private User __user;

    public void Clear()
    {
        Console.Clear();
    }

    public string[] GetOptions()
    {
        return options;
    }

    public void Run(string menu, User user)
    {
        __user = user;
        while (__NoSwitch)
        {
            Console.Write($"{menu}");

            // ask for user input
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                Clear();

                if (x == 0) __MenuManager.Load(__MenuManager.menuHome);
                if (x == 1) PlaylistCreate();
                if (x == 2) Console.Write(PlaylistShow());
                if (x == 3) PlaylistEdit();
                if (x == 4) PlaylistDelete();
            }
            catch (FormatException e)
            {
                Clear();
                Console.WriteLine($"{e.Message}");
            }
        }

        #region submenu
        void PlaylistEdit()
        {
            Console.WriteLine(PlaylistShow());

            Console.Write($"Which playlist would you like to edit\n\nSelected: ");
            int pl = user.Input() - 1;

            if (pl < 0 || pl > __user.userPlaylists.Count) { Clear();  Console.WriteLine($"Index out of range."); PlaylistEdit(); }

            Clear();
            while (true)
            {
                Console.Write(__MenuManager.__Construct(options2));
                int choice = __user.Input();

                if (choice == 0) { Clear(); return; }
                if (choice == 1) Show(pl);
                if (choice == 2) Add(pl);
                if (choice == 3) Delete(pl);
                if (choice == 4) Rename(pl);
            }
        }
        #endregion

        #region playlist specific functions
        /* PLAYLIST SPECIFIC FUNCTIONS */
        void Rename(int choice)
        {
            Clear();
            Console.Write($"Current playlist name is: {__user.userPlaylists[choice].ToString()}\n" +
                $"What would you like to change it to?\n\nNew playlist name: ");

            string newname = __user.Textinput();

            // playlist can't have an empty name
            if (newname == "") { Clear();  Console.WriteLine($"New name cant be empty"); return;}

            Clear();
            __user.userPlaylists[choice].Name = newname;
            Console.WriteLine($"Playlist renamed to {newname}");
        }

        void Show(int choice)
        {
            Clear();
            if (__user.userPlaylists[choice].songList.Count == 0) { Console.WriteLine($"Playlist is empty"); return; }

            for (int i = 0; i < __user.userPlaylists[choice].songList.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {__user.userPlaylists[choice].songList[i].ToString()}");
            }
        }

        void Delete(int choice)
        {
            Clear();
            Show(choice);
            do
            {
                Console.Write($"\nSelect a song: ");
                try
                {
                    __user.userPlaylists[choice].songList.RemoveAt(user.Input() - 1);
                    Clear();
                    Console.WriteLine($"Song removed");
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message.Substring(0,24)}");
                }
            } 
            while (true);
        }

        void Add(int choice)
        {
            string[] op = { "Artist name: ", "Song name: ", "duration of the song: " };

            string artistName = "";
            string songname = "";
            int duration = 0;

            for(int i = 0; i < op.Length; i++)
            {
                Console.Write($"{op[i]}");

                if (i == 0) artistName = __user.Textinput(); 
                if (i == 1) songname = __user.Textinput();
                if (i == 2) duration = __user.Input();
            }

            __user.userPlaylists[choice].songList.Add(new Song(artistName, songname, duration));
            Clear();
            Console.WriteLine($"{__user.userPlaylists[choice].songList.Last().Artist} added to {__user.userPlaylists[choice].ToString()}");
        }
        #endregion

        #region general playlist functions
        /* GENERAL PLAYLIST FUNCTIONS */
        void PlaylistDelete()
        {
            Clear();
            Console.WriteLine($"0) Exit.\n{PlaylistShow()}");

            Console.Write($"Which playlist would you like to delete? \n\nSelected: ");
            int x = __user.Input();

            if (x == 0) { return; }

            try
            {
                Clear();
                Console.Write($"You are about to delete {__user.userPlaylists[x - 1].ToString()}\n" +
                    $"Are you sure you want to delete this?\n1) No.\n2) Yes.\n\nSelected: ");

                if (__user.Input() == 1) { Clear(); return; }
                Clear();
                Console.WriteLine($"{__user.userPlaylists[x - 1].ToString()} has been deleted");
                __user.userPlaylists.RemoveAt(x - 1);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message.Substring(0, 24)}");
            }
        }

        void PlaylistCreate()
        {
            Clear();
            Console.WriteLine($"Playlist name? || Pressing enter will make it default");

            string choice = user.Textinput();

            if(choice == "")
            {
                user.userPlaylists.Add(new Playlist());
                return;
            }

            user.userPlaylists.Add(new Playlist(choice));
        }

        string PlaylistShow()
        {
            string list = "";

            if (__user.userPlaylists.Count == 0) return "There are no playlists to show yet try making one.";

            for(int i = 0; i < __user.userPlaylists.Count; i++)
            {
                list += $"{i + 1}) {__user.userPlaylists[i].ToString()}\n";
            }
            return list;
        }
        #endregion
    }
}