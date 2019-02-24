namespace QuerySpecification.Models
{
    public class Mobile
    {
        public string BrandName { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }

        public Mobile(string brandName, string type)
        {
            BrandName = brandName;
            Type = type;
        }

        public Mobile(string brandName, string type, int count)
        {
            BrandName = brandName;
            Type = type;
            Count = count;
        }

        public override string ToString()
        {
            return "Model = " + BrandName + ", Type = " + Type;
        }
    }
}