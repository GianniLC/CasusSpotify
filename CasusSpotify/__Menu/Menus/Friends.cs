using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Friends : IMenu
{
    public string[] options = { "Go back ","Add friends", "Show friends", "Delete friends", "Friend playlists" };
    private User __user;

    public string[] GetOptions()
    {
        return options;
    }

    public void Run(string menu, User user)
    {
        __user = user;

        do
        {
            // show the menu
            Console.Write(menu);

            // ask for user input
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                Clear();

                if (x == 0) return;
                if (x == 1) Add();
                if (x == 2) Console.Write(Show());
                if (x == 3) Delete();
                if (x == 4) Ask();

                if (x < 0 || x > options.Length) Console.WriteLine($"Input chosen is out of bounds");
            }
            catch (FormatException e)
            {
                Clear();
                Console.WriteLine($"{e.Message.Substring(0, 24)}");
            }
        } while (true);
    }

    void Ask()
    {
        Clear();
        Console.WriteLine($"Which friend would you like to check out?\n" +
            $"{Show()}");

        User friend = __user.friendList[__user.Input() - 1];

        Console.WriteLine(Show(friend));

        /* would they like to see all the songs in them as well?*/
        Console.Write($"Would you like to see all the songs in the playlists as well?\n1 - Yes.\n2 - No.\nSelected: ");

        if (__user.Input() != 1) return;

        /* Show all the songs */
        Console.WriteLine($"{Show(friend, true)}");
    }
    #region functions
    void Add()
    {
        Console.WriteLine($"What is the name of your friend?");

        string x = __user.Textinput();

        // check if x is empty
        if(x == "") { Console.WriteLine($"Friend name cant be empty"); return; }

        // else add the friend
        __user.friendList.Add(new User(x));
        Clear();
        Console.WriteLine("Friend has been added");
    }

    string Show()
    {
        if (__user.friendList.Count == 0) return "No friends unlucky...";

        string friends = "";

        for (int i = 0; i < __user.friendList.Count; i++) 
        {
            friends += $"{i + 1}) {__user.friendList[i].Name}\n";
        }
        return friends;
    }

    /* Display all the users playlists */
    string Show(User user, bool songs = false)
    {
        Clear();
        string friendpl = "";

        // retrieve their playlists 
        for (int i = 0; i < user.userPlaylists.Count; i++)
        {
            friendpl += $"x) {user.userPlaylists[i].ToString()}\n";
            if (songs)
            {
                for(int j = 0; j < user.userPlaylists[i].songList.Count; j++)
                {
                    friendpl += $"{j + 1}) {user.userPlaylists[i].songList[j].ToString()}\n";
                }
                friendpl += "\n";
            }

        }
        return friendpl;
    }

    /* Display all the users songs in all the playlists */

    void Delete()
    {
        Console.WriteLine($"{Show()}");
        Console.Write($"What friend would you like to delete? \n\nSelected: ");
        int x = __user.Input();
        if (x == 0) return;
        Console.Write($"Are you sure about this?\n\n1- Yes\n2- No\nSelected: ");
        if (__user.Input() != 1) return;
        __user.friendList.RemoveAt(x - 1);
        Clear();
        Console.WriteLine($"Friend deleted");
    }

    #endregion

    public void Clear()
    {
        Console.Clear();
    }
}