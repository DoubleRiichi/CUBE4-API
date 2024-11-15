namespace JamaisASec.DB;

public record Commande {
    public int ID { get; set; }
    public string Reference { get; set; }
    public DateOnly Date { get; set; }
    public string Status  { get; set; }
   
    public int ArticleCommandeID { get; set; }

    // ? signifie peut-être null
    public int? ClientID { get; set; }
    public int? FournisseurID { get; set; }

}

