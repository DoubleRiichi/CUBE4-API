namespace JamaisASec.Models;

public class Articles
{
    public int ID { get; set; }
    public string Nom { get; set; }
    public int Quantite { get; set; }
    public string Image { get; set; }
    public int Prix_unitaire { get; set; }
    public int Colisage { get; set; }
    public int Quantite_Min { get; set; }
    public int Annee { get; set; }
    public string Description { get; set; }

    public int Familles_ID { get; set; }
    public int Maisons_ID { get; set; }

}