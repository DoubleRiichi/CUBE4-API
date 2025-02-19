using System.Text.Json.Serialization;

namespace JamaisASec.Models;
public class Clients {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Mail { get; set; }
    public string Mot_De_Passe { get; set; }

    public string Telephone { get; set; }
    
}

