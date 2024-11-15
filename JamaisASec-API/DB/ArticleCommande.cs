namespace JamaisASec.DB;

public record ArticleCommandes {
    public int ID { get; set; }
    public int ArticleID { get; set; }
    public int CommandeID { get; set; }
    
}

