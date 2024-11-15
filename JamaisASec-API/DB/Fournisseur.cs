namespace JamaisASec.DB;

public record Fournisseur {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Mail { get; set; }
    public string Telephone { get; set; }
    public string SIRET { get; set; }
}

