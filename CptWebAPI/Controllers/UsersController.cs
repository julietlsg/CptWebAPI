using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;

namespace CptWebAPI.Controllers
{
    public class UsersController : ApiController
    {
      public IEnumerable<AspNetUser> Get()
        {
            //create an instance of the user data model 
            using (CptUserDBEntities entities = new CptUserDBEntities())
            {

                // this returns the list of users in the database table 
                return entities.AspNetUsers.ToList();
            }
        }
        public AspNetUser Get(string id)
        {
            //create an instance of the user data model 
            using (CptUserDBEntities entities = new CptUserDBEntities())
            {

                // this returns only one user from the database table 
                return entities.AspNetUsers.FirstOrDefault(u => u.Id == id);
            }
        }


        public void Post([FromUri] AspNetUser users)
        {
            // create a new user 

            using (CptUserDBEntities entities = new CptUserDBEntities())
            {
                entities.AspNetUsers.Add(users);
                entities.SaveChanges();
            }

        }

    }
}
