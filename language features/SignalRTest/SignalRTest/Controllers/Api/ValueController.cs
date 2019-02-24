using System.Collections.Generic;
using System.Web.Http;
using SignalRTest.Models;
using SignalRTest.Repository;

namespace SignalRTest.Controllers.Api
{
    public class ValueController : ApiController
    {
        //
        // GET: /Value/

        readonly JobInfoRepository objRepo = new JobInfoRepository();
        readonly CallRepository callRepository = new CallRepository();

        // GET api/values
        public IEnumerable<JobInfo> GetJobs()
        {
            return objRepo.GetData();
        }

        public IEnumerable<Call> GetCalls()
        {
            return callRepository.GetData();
        }

    }
}
