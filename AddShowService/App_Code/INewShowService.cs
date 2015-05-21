using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewShowService" in both code and config file together.
[ServiceContract]
public interface INewShowService
{
    [OperationContract]
    List<Show> GetShows();

    [OperationContract]
    List<Artist> GetArtists();

    [OperationContract]
    bool addShow(Show s, ShowDetail sd);

    [OperationContract]
    bool addArtist(Artist a);

}


