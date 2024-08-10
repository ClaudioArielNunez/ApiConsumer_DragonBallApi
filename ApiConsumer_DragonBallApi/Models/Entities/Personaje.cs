namespace ApiConsumer_DragonBallApi.Models.Entities
{
    public class Personaje
    {
        public int id { get; set; }
        public string image { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string? ki { get; set; }
        public string? maxki { get; set; }
        public string race { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
