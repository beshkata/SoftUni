namespace BorderControl.Contracts
{
    public interface ICitizen : IIdentifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
