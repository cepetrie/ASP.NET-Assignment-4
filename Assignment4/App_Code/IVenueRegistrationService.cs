using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenueRegistrationService" in both code and config file together.
[ServiceContract]
public interface IVenueRegistrationService
{
	[OperationContract]
    
    //Venue and VenueLogin are the tables
	bool RegisterVenue(Venue v, VenueLogin vl);

    [OperationContract]
    int VenueLogin(string userName, string Password);
}

