using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SignalRTest.Controllers.Hubs;
using SignalRTest.Models;

namespace SignalRTest.Repository
{
    public class JobInfoRepository 
    {
        public IEnumerable<JobInfo> GetData()
        {
            const string lineCommand = @"SELECT [JobID],[Name],[LastExecutionDate],[Status] FROM [dbo].[JobInfo]";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(lineCommand, connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new JobInfo()
                            {
                                JobID = x.GetInt32(0),
                                Name = x.IsDBNull(1) ? "" : x.GetString(1),
                                LastExecutionDate = x.IsDBNull(2) ? new DateTime() : x.GetDateTime(2),
                                Status = x.IsDBNull(3) ? "" : x.GetString(3)
                            }).ToList().OrderByDescending(x=>x.JobID).Take(5);
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        } 
    }
}