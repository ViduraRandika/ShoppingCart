namespace LogicLayer.AuthLogic
{
    public class JWTAuthOptions
    {
        public const string SectionName = "JWTAuth";

        public string Secret { get; set; }
    }
}