using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

// test var google = new WebClient().DownloadString("https://google.com");
//Console.WriteLine(google);
//jsonSummer = JsonConvert.SerializeObject(jsonSummer);                 para serializar
//jsonSummer = JsonConvert.DeserializeObject<Character?>(jsonSummer); //para deserializar

var jsonSummer = Persistencia.GetCharacter(3);
Console.WriteLine(jsonSummer);
Character Summer = JsonConvert.DeserializeObject<Character>(jsonSummer)!;
Console.WriteLine(Persistencia.JsonCharacterToObject(3).image); //test (pasado)

/**
 * Lugar donde se encuentra el personaje
 */
public class Location
{
    public string name { get; set; }
    public string url { get; set; }
}
/**
 * Lugar de origen del personaje 
 */
public class Origin
{
    public string name { get; set; }
    public string url { get; set; }
}
/**
 * Personaje deserializado del json
 */
public class Character
{
    public int id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string species { get; set; }
    public string type { get; set; }
    public string gender { get; set; }
    public Origin origin { get; set; }
    public Location location { get; set; }
    public string image { get; set; }
    public List<string> episode { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
}

/**
 * Gestiona las conexiones con la API
 */
class Persistencia
{
    public static String GetCharacter(int id)
    {
        return new WebClient().DownloadString("https://rickandmortyapi.com/api/character/" + id);
    }

    public static String GetEpisode(int id)
    {
        return new WebClient().DownloadString("https://rickandmortyapi.com/api/episode/" + id);
    }

    public static String GetLocation(int id)
    {
        return new WebClient().DownloadString("https://rickandmortyapi.com/api/location/" + id);
    }

    public static Character JsonCharacterToObject(int id)
    {
        return JsonConvert.DeserializeObject<Character>(GetCharacter(id))!;
    }
}