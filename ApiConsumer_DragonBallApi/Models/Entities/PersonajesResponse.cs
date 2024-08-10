namespace ApiConsumer_DragonBallApi.Models.Entities
{
    public class PersonajesResponse
    {
        public Personaje[] items { get; set; }

        //Debe ser items, ya que asi esta en el objeto json que nos devuelve la API
    }
}
