namespace BorderControl.Contracts
{
    public interface IRebel : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

    }
}
