using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public  class Song
{
    string artist;
    string title;
    int duration;

    public string Artist { get { return artist; } set { artist = value; } }
    public string Title { get { return title; } set { title = value; } }

    public int Duration { get { return duration; } set { duration = value; } }

    public Song()
    {
        this.Artist = "test songname";
        this.Title = "test title";
    }

    public Song(string name, string title, int duration)
    {
        this.Artist = name;
        this.Title = title;
        this.Duration = duration;
    }

    public override string ToString()
    {
        while (this.Artist.Length < 25) this.Artist += " ";

        return $"{this.artist}: {this.title}";
    }
}