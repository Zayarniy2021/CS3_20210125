//Code first
using System;
using System.Data.Entity;

namespace MusicDB
{
    public class Track
    {
        
        public int TrackID { get; set; }

        public string TrackName { get; set; }

        public string ArtistName { get; set; }
    }

    public class TracksDB : DbContext
    {
        public TracksDB()
        {
            
        }

        public DbSet<Track> Tracks { get; set; }

    }


}
