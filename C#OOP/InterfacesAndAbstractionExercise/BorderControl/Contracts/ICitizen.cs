namespace BorderControl.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
