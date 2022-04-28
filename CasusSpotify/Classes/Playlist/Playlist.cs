using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Playlist
{
    string name;

    public List<Song> songList;

    public string Name { get { return name; } set { name = value; } }

    public Playlist()
    {
        this.name = "new playlist";
        songList = new List<Song>();
    }

    public Playlist(string name)
    {
        this.name = name;
        songList = new List<Song>();
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }

}