using System.ComponentModel.DataAnnotations;

namespace ReproDistinct.Enums;

public enum StatutAffaire
{
    [Display(Name = "Inconnu", Description = AtlasStatusLabels.Unknown)]
    Unknown = 0,

    [Display(Name = "Devis à créer", Description = AtlasStatusLabels.ToBeCreated)]
    ToBeCreated = 1,

    [Display(Name = "Devis en cours de modification", Description = AtlasStatusLabels.Modification)]
    ModificationInProgress = 2,

    [Display(Name = "Devis créé", Description = AtlasStatusLabels.Created)]
    Created = 3,

    [Display(Name = "Commandée (gagnée)", Description = AtlasStatusLabels.Won)]
    Won = 4,

    [Display(Name = "Devis en erreur", Description = AtlasStatusLabels.Error)]
    Error = 5,

    [Display(Name = "Devis orphelin", Description = AtlasStatusLabels.Orphan)]
    Orphan = 99,

    [Display(Name = "Devis à renvoyer", Description = AtlasStatusLabels.Resendable)]
    Resendable = 999,
}

public class AtlasStatusLabels
{
    // ATTENTION : ces labels proviennent d'Atlas et ne doivent pas changer
    public const string ToBeCreated = "Devis à créer";

    public const string Modification = "Devis en cours de modification";
    public const string Created = "Devis créé";
    public const string Won = "Commandée (gagnée)";
    public const string Error = "Devis en erreur";
    public const string Unknown = "Inconnu";

    // Exceptés ceux ci-dessous qui correspondent à des affaires qui ne sont plus traquées
    public const string Orphan = "Orphelin";

    public const string Resendable = "Devis à retransmettre";

    public static StatutAffaire Map(string status) => status switch
    {
        AtlasStatusLabels.ToBeCreated => StatutAffaire.ToBeCreated,
        AtlasStatusLabels.Modification => StatutAffaire.ModificationInProgress,
        AtlasStatusLabels.Created => StatutAffaire.Created,
        AtlasStatusLabels.Won => StatutAffaire.Won,
        AtlasStatusLabels.Error => StatutAffaire.Error,
        _ => StatutAffaire.Unknown,
    };

    public static string Map(StatutAffaire? status)
    {
        if (status is null) return "à envoyer";

        var result = status switch
        {
            StatutAffaire.ToBeCreated => AtlasStatusLabels.ToBeCreated,
            StatutAffaire.ModificationInProgress => AtlasStatusLabels.Modification,
            StatutAffaire.Created => AtlasStatusLabels.Created,
            StatutAffaire.Won => AtlasStatusLabels.Won,
            StatutAffaire.Error => AtlasStatusLabels.Error,
            StatutAffaire.Orphan => AtlasStatusLabels.Orphan,
            StatutAffaire.Resendable => AtlasStatusLabels.Resendable,
            _ => AtlasStatusLabels.Unknown,
        };
        return result;
    }
}