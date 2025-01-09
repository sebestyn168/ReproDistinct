namespace ReproDistinct.Models;

public partial class Echeance
{
    public string Code { get; set; }
    public string Label { get; set; }
    public decimal Percent { get; set; }
    public decimal[] Range { get; set; }
    public bool? IsAdjust { get; set; }
    public int? Delai { get; set; }
}

public class Echeancier
{
    public int? DureeMin { get; set; }
    public int? DureeMax { get; set; }
    public IList<Echeance> Echeances { get; set; }
}

public partial class EcheancierModel : ConfigurationEntity<Guid>
{
    public IList<Link_Echeancier_Mission> Missions { get; set; }

    public bool ModeAtlasAuto { get; set; }

    public decimal? CoeffAgressivite { get; set; }

    public string ConfigJson { get; set; }
}