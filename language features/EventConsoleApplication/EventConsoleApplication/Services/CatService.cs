using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EventConsoleApplication.Classes;

namespace EventConsoleApplication.Services
{
    public class CatService
    {
        private readonly List<Cat> cats;
        public List<Cat> Cats { get { return cats; } }

        public CatService(params string[] catNames)
        {
            cats = (from catName in catNames
                    select new Cat(catName)).ToList();

            cats.ForEach(x => x.CrapEvent += c_Reached);
            cats.ForEach(x => x.EatEvent += c_Reached);
            cats.ForEach(x => x.PissEvent += c_Reached);
        }

        public void Run()
        {
            cats.ForEach(x => x.Crap());

            Thread.Sleep(5000);
            cats.ForEach(x => x.Eat());

            Thread.Sleep(5000);
            cats.ForEach(x => x.Piss());
        }

        protected void c_Reached(object sender, CatArgs e)
        {
            Console.WriteLine("[{0}]: {1}", e.Date.ToString("dd.MM.yyyy HH:mm"), e.Message);
        }
    }
}