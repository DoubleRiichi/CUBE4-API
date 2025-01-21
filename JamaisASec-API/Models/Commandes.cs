namespace JamaisASec.Models;

public class Commandes {
    public int ID { get; set; }
    public string Reference { get; set; }
    public DateOnly Date { get; set; }
    public string Status  { get; set; }
   
    // ? signifie peut-être null
    public int? Clients_ID { get; set; }
    public int? Fournisseurs_id { get; set; }

}

