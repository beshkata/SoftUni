namespace SMS.Data
{
    public class DatabaseConfiguration
    {
        // ReSharper disable once InconsistentNaming
        public const string ConnectionString =
            @"Server=RAPTOR\SQLEXPRESS;Database=SMS;Trusted_Connection=True;Integrated Security=True;";
        //@"Server=.;Database=SMS;Trusted_Connection=True;Integrated Security=True;";
    }
}
