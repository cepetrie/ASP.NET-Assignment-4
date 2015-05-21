using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueRegistrationService" in code, svc and config file together.
public class VenueRegistrationService : IVenueRegistrationService
{
    ShowTrackerEntities1 db = new ShowTrackerEntities1();
    public bool RegisterVenue(Venue v, VenueLogin vl)
    {
        bool result = true;
        try
        {

                //1. Instantiate PasswordHash()
                //2. Instantiate Keycode()
                //3. Pass the password and keycode to PasswordHash to get the hashed password
                //4. instantiate a new instance of the Venue class from the data entities
                //5. map the fields from Venue to RegisterVenue
                //6. assign the new hash and the seed to the venue fields
                //7. add this instance of review to the collection Venues
                //8. save all the changes to the database
            
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetKeyCode();
            byte[] dbhash = ph.HashIt(vl.VenueLoginPasswordPlain, code.ToString());

            Venue ven = new Venue();
            ven.VenueName = v.VenueName;
            ven.VenueAddress = v.VenueAddress;
            ven.VenueCity = v.VenueCity;
            ven.VenueState = v.VenueState;
            ven.VenueZipCode = v.VenueZipCode ;
            ven.VenuePhone = v.VenuePhone;
            ven.VenueEmail = v.VenueEmail;
            ven.VenueWebPage = v.VenueWebPage;
            ven.VenueAgeRestriction = v.VenueAgeRestriction;
            ven.VenueDateAdded = DateTime.Now;

            db.Venues.Add(ven);
            db.SaveChanges();

            
            VenueLogin login = new VenueLogin();
            login.VenueLoginUserName = vl.VenueLoginUserName;
            login.VenueLoginPasswordPlain = vl.VenueLoginPasswordPlain;
            login.VenueLoginRandom = code;
            login.VenueLoginHashed = dbhash;
            login.Venue = ven;               
            login.VenueLoginDateAdded = DateTime.Now;

            db.VenueLogins.Add(login);
            db.SaveChanges();

        }
        catch
        {
            result = false;
        }

        return result;
    }

    public int VenueLogin(string userName, string Password)
    {
        LoginClass lc = new LoginClass(userName, Password);
        return lc.ValidateLogin();
    }
}
