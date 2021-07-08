namespace BorderControl.Contracts
{
    public interface IRobot : IIdentifiable
    {
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
