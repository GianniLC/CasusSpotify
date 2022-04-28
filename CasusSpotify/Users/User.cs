using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public  class User
{
    public string name;
    public List<Playlist> userPlaylists;
    public List<User> friendList;

    public string Name { get; set; }

    public User(string name)
    {
        this.Name = name;
        userPlaylists = new List<Playlist>();
        friendList = new List<User>();
    }

    public User(string user, bool debug = false)
    {
        this.Name = user;
        userPlaylists = new List<Playlist>();
        friendList = new List<User>();

        if (debug)
        {
            userPlaylists.Add(new Playlist());
            userPlaylists.Add(new Playlist());

            for(int i = 0; i < userPlaylists.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 0) userPlaylists[i].songList.Add(new Song("Avenged sevenfold", "Hail to the king", 0));
                    if (j == 1) userPlaylists[i].songList.Add(new Song("Five finger death punch", "Wrong side of heaven", 0));
                    if (j == 2) userPlaylists[i].songList.Add(new Song("Mariah Carey", "Christmas", 0));
                    if (j == 3) userPlaylists[i].songList.Add(new Song("Britney Spears", "Toxic", 0));
                    if (j == 4) userPlaylists[i].songList.Add(new Song("Dutch melrose", "Sleepless nights", 0));
                }
            }
        }
    }

    public int Input()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        if (x == 0) return 0;
        return x;
    }

    public string Textinput()
    {
        string y = Console.ReadLine();
        return y;
    }

    public override string ToString()
    {
        string[] fname = this.Name.Split(" ");

        return $"{fname[0]}";
    }
}