namespace JamaisASec.DB;

// c'est un peu une découverte, sujet à changer
public record Article {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Quantite { get; set; }
    public string Image  { get; set; }
    public string Colisage { get; set; }
    public string QuantiteMin { get; set; }
    public string Annee { get; set; }
    public string Description { get; set; }

    public int FamillesID { get; set; }
    public int MaisonsID { get; set; }

}

