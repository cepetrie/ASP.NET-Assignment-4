using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewShowService" in code, svc and config file together.
public class NewShowService : INewShowService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
   
  

    public List<Show> GetShows()
    {
        var shs = from s in db.Shows
                  orderby s.ShowName
                  select s;

        List<Show> shows = new List<Show>();
        foreach (Show s in shs)
        {

            Show sh = new Show();
            sh.ShowName = s.ShowName;
            sh.ShowDate = s.ShowDate;
            sh.ShowTime = s.ShowTime;

            shows.Add(sh);

        }

        return shows;
    }

    public List<Artist> GetArtists()
    {
        var arts = from a in db.Artists
                   orderby a.ArtistKey
                   select a;

        List<Artist> artists = new List<Artist>();
        foreach (Artist a in arts)
        {

            Artist art = new Artist();
            art.ArtistKey = a.ArtistKey;
            art.ArtistName = a.ArtistName;

            artists.Add(art);

        }

        return artists;
    }

 
    public bool addShow(Show s, ShowDetail sd)
    {
        bool result = true;
        try
        { 

            ShowTrackerEntities db = new ShowTrackerEntities();
        
            Show show = new Show();
            ShowDetail details = new ShowDetail();

            show.ShowName = s.ShowName;
            show.ShowDate = s.ShowDate;
            show.ShowTicketInfo = s.ShowTicketInfo;
            show.ShowDateEntered = DateTime.Now;
            show.ShowTime = s.ShowTime;
            show.VenueKey = s.VenueKey;

            db.Shows.Add(show);

            details.ShowDetailAdditional = sd.ShowDetailAdditional;
            details.ArtistKey = sd.ArtistKey;
            details.ShowDetailArtistStartTime = sd.ShowDetailArtistStartTime;
            details.Show = show;

            db.ShowDetails.Add(details);
            db.SaveChanges();

        }

        catch
        {
            result = false;
        }

        return result;
    }

    public bool addArtist(Artist a)
    {
        bool result = true;
        try
        { 

            ShowTrackerEntities db = new ShowTrackerEntities();

            Artist artist = new Artist();

            artist.ArtistName = a.ArtistName;
            artist.ArtistEmail = a.ArtistEmail;
            artist.ArtistWebPage = a.ArtistWebPage;
            artist.ArtistDateEntered = DateTime.Now;

            db.Artists.Add(artist);

            db.SaveChanges();

        }

        catch
        {
            result = false;
        }

        return result;
    } 
        
}