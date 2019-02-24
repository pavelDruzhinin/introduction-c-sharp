using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using SignalRTest.Controllers.Hubs;
using SignalRTest.Models;

namespace SignalRTest.Repository
{
    public class CallRepository
    {
        public IEnumerable<Call> GetData()
        {
            const string query = @"select [ID],[UID],[SubjectTo],[SubjectFrom],[ActionType] from [dbo].[Transfers]";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PetrocryptConnection"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var result = reader.Cast<IDataRecord>()
                           .Select(x => new Call
                           {
                               ID = x.IsDBNull(0) ? 0 : x.GetInt32(0),
                               UID = x.IsDBNull(1) ? "" : x.GetString(1),
                               SubjectTo = x.IsDBNull(2) ? "" : x.GetString(2),
                               SubjectFrom = x.IsDBNull(3) ? "" : x.GetString(3),
                               ActionType = x.IsDBNull(4) ? 0 : x.GetInt32(4)
                           }).ToList().Where(x => x.SubjectTo.StartsWith("31")).OrderByDescending(x => x.ID).Take(20);

                        UnionCallsCompany(result);

                        return result;
                    }
                }
            }
        }

        private void UnionCallsCompany(IEnumerable<Call> calls)
        {
            foreach (var call in calls)
            {
                call.Companies = GetCompanies(call.SubjectFrom);
            }

        }

        private IEnumerable<Company> GetCompanies(string phoneNumber)
        {
            phoneNumber = ParsePhone(phoneNumber);

            if (phoneNumber == "")
                return null;
            //78142767065
            var query = @"select com.Name, com.Inn, com.Kpp from Phones as p
                                   inner join Contacts as c on p.Id = c.PhoneId
                                   inner join Companies as com on com.Id = c.CompanyId
                                   where p.Code = '" + phoneNumber.Substring(0, 4) + "' and p.Number = '" + phoneNumber.Substring(4) + "'";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PetrocryptConnection"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Cast<IDataRecord>()
                            .Select(x => new Company
                            {
                                Name = x.IsDBNull(0) ? "" : x.GetString(0),
                                Inn = x.IsDBNull(1) ? "" : x.GetString(1),
                                Kpp = x.IsDBNull(2) ? "" : x.GetString(2)
                            }).ToList();
                    }
                }
            }
        }


        private static string ParsePhone(string value, string phoneCode = "")
        {
            var phone = FindAllDigitals(value);

            if (phone.Length == 6 && phoneCode != "" || phone.Length == 7 && phoneCode == "7812")
                return phoneCode + phone;

            if (phone.Length == 10 && (phone[0] == '8' || phone[0] == '9'))
                return "7" + phone;

            if (phone.Length == 11 && (Regex.IsMatch(phone, @"89[\d]") || Regex.IsMatch(phone, @"88[\d]")))
                phone = "7" + phone.Substring(1);

            return phone.Length == 11 ? phone : "";
        }

        private static string FindAllDigitals(string value)
        {
            const string pattern = @"[\D]";
            return Regex.Replace(value, pattern, String.Empty);
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            CallHub.Show();
        }
    }
}