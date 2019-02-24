using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using SignalRTest.Models;

namespace SignalRTest.Controllers.Common
{
    public class TestController : AsyncController
    {
        [AsyncTimeout(90000)]
        public void GetMessagesAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            SqlConnection conn = null;
            try
            {
                var connString = ConfigurationManager.ConnectionStrings["PetrocryptConnection"].ConnectionString;
                conn = new SqlConnection(connString);
                conn.Open(); // open new connection and create command to notify about all new Chat-Messages in -ROOM_NUMBER- const
                using (var sqlCommand = new SqlCommand(@"GetTransfers", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    //sqlCommand.Parameters.AddWithValue("room", Configuration.ROOM_NUMBER);
                    var sqlDependency = new SqlDependency(sqlCommand);

                    //handle onChange event - this will be fired whenever there is a change in database that affacts our query
                    sqlDependency.OnChange += (sender, e) =>
                    {

                        //change detected - get all messages...
                        IEnumerable<Call> entities;
                        try
                        {
                            entities = new List<Call>();
                            var query = from c in entities.ChatRoom
                                        where c.RoomNumber == Configuration.ROOM_NUMBER
                                        select c;
                            AsyncManager.Parameters["callModel"] = query.ToArray();
                        }
                        finally
                        {
                            //...and complete async operation
                            AsyncManager.OutstandingOperations.Decrement();
                        }

                    };
                    //execute query with associated SqlDependency to subscribe for notifications
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                //make sure that if something goes wrong we are still have proper AsyncManager operations count
                AsyncManager.OutstandingOperations.Decrement();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        public ActionResult GetMessagesCompleted(IEnumerable<Call> callModel)
        {
            return PartialView("Chat", callModel);
        }

        public PartialViewResult Chat()
        {
            return PartialView();
        }

    }
}
