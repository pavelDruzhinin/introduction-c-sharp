using System;
using System.Collections.Generic;
using QuerySpecification.Models;
using QuerySpecification.Specifications;
using QuerySpecification.Specifications.Contracts;
using Type = QuerySpecification.Models.Type;

namespace QuerySpecification
{
    class Program
    {
        static void Main()
        {
            var mobiles = new List<Mobile> { 
                new Mobile(BrandName.Samsung, Type.Smart, 700), 
                new Mobile(BrandName.Apple, Type.Smart), 
                new Mobile(BrandName.Htc, Type.Basic), 
                new Mobile(BrandName.Samsung, Type.Basic) 
            };

            ISpecification<Mobile> samsungExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Samsung);

            ISpecification<Mobile> htcExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Htc);

            ISpecification<Mobile> SamsungHtcExpSpec = samsungExpSpec.Or(htcExpSpec);

            ISpecification<Mobile> NoSamsungExpSpec =
              new ExpressionSpecification<Mobile>(o => o.BrandName != BrandName.Samsung);

            var samsungMobiles = mobiles.FindAll(samsungExpSpec.IsSatisfiedBy);
            var htcMobiles = mobiles.FindAll(htcExpSpec.IsSatisfiedBy);
            var samsungHtcMobiles = mobiles.FindAll(SamsungHtcExpSpec.IsSatisfiedBy);
            var noSamsungMobiles = mobiles.FindAll(NoSamsungExpSpec.IsSatisfiedBy);


            //samsungHtcMobiles.ForEach(o => Console.WriteLine(o.ToString()));
            //samsungMobiles.ForEach(o => Console.WriteLine(o.ToString()));
            //htcMobiles.ForEach(o => Console.WriteLine(o.ToString()));
            noSamsungMobiles.ForEach(o => Console.WriteLine(o.ToString()));

        }
    }
}
