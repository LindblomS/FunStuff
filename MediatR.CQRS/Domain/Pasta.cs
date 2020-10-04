namespace MediatR.CQRS.Domain
{
    public class Pasta
    {
        public Pasta(string name, string info)
        {
            Name = name;
            Info = info;
        }

        public string Name { get; set; }
        public string Info { get; set; }
    }
}
