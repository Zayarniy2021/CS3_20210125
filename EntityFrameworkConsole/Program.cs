using System;
using MusicDB;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkConsole
{
    class Program
    {
        static private MusicDB.TracksDB _dbContainter;

        static void Print()
        {
            foreach (Track track in _dbContainter.Tracks)
            {
                Console.WriteLine($"{track.TrackID} {track.TrackName} {track.ArtistName}");
            }
        }

        static void Add(Track track)
        {
            _dbContainter.Tracks.Add(track);
            _dbContainter.SaveChanges();
        }

        static void Remove(int id)
        {
            Track track = _dbContainter.Tracks.Where(o => o.TrackID == id).FirstOrDefault();
            if (track==null) return;
            _dbContainter.Tracks.Remove(track);
            _dbContainter.SaveChanges();
        }
        static void Main(string[] args)
        {
            _dbContainter = new TracksDB();
            _dbContainter.Tracks.Load();
            //_dbContainter.Tracks.Add(new Track() {TrackID = 0, ArtistName = "DM", TrackName = "Stripped"});
            Add(new Track() {  ArtistName = "DM", TrackName = "Stripped" });
            Print();
            Remove(1);
            Console.WriteLine();
            Print();
        }
    }
}
