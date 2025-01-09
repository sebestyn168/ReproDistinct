using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public abstract class Pass<P, PM> : IIdentifiableEntity<Guid>
    where P : Pass<P, PM>
    where PM : Link_Pass_Mission<P, PM>
{
    /// <summary>
    /// Identifiant du PASS
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Missions Sélectionnées et Proposées (cf. montant associé)
    /// </summary>
    public virtual IList<PM>? ProjectMissions { get; set; }

    /// <summary>
    /// Types de travaux
    /// </summary>
    public virtual IList<Link_Pass_WrkTyp<P, PM>>? WorkTypes { get; set; }

    /// <summary>
    /// Typologies projets
    /// </summary>
    public virtual IList<Link_Pass_PrjTypo<P, PM>>? ProjectTypologies { get; set; }

    /// <summary>
    /// Catégories projets
    /// </summary>
    public virtual IList<Link_Pass_PrjCat<P, PM>>? ProjectCategories { get; set; }

    /// <summary>
    /// Catégories projets
    /// </summary>
    public virtual IList<Link_Pass_EnvCert<P, PM>>? EnvironmentalCertifications { get; set; }

    /// <summary>
    /// Affaires Atlas associées au Pass
    /// </summary>
    public virtual IList<Link_Pass_Affaire<P, PM>>? AtlasAffaires { get; set; }

    /// <summary>
    /// Catégorie de l'ERP
    /// </summary>
    public int? ErpCategory { get; set; }

    /// <summary>
    /// Identifiant de l'agence
    /// </summary>
    public int? AgencyId { get; set; }

    /// <summary>
    /// Adresse de l'agence
    /// </summary>
    [MaxLength(150)]
    public string? AgencyAddress { get; set; }

    /// <summary>
    /// Code Postal de l'agence
    /// </summary>
    [MaxLength(5)]
    public string? AgencyPostCode { get; set; }

    /// <summary>
    /// Ville de l'agence
    /// </summary>
    [MaxLength(50)]
    public string? AgencyTown { get; set; }

    /// <summary>
    /// Nom du client
    /// </summary>
    [MaxLength(100)]
    public string? ClientName { get; set; }

    /// <summary>
    /// Adresse du client - [n°] [type voie] [nom voie]
    /// </summary>
    [MaxLength(150)]
    public string? ClientAddress { get; set; }

    /// <summary>
    /// complément d'adresse
    /// </summary>
    [MaxLength(50)]
    public string? ClientAddressComplement { get; set; }

    /// <summary>
    /// Adresse du client - Cedex
    /// </summary>
    [MaxLength(50)]
    public string? ClientAddressCedex { get; set; }

    /// <summary>
    /// Adresse du client - Code Postal
    /// </summary>
    [MaxLength(5)]
    public string? ClientAddressPostCode { get; set; }

    /// <summary>
    /// Adresse du client - Cedex
    /// </summary>
    [MaxLength(50)]
    public string? ClientAddressTown { get; set; }

    /// <summary>
    /// Siret du client
    /// </summary>
    [MaxLength(20)]
    public string? ClientSiret { get; set; }

    /// <summary>
    /// Prénom de l'interlocuteur chez le client
    /// </summary>
    [MaxLength(50)]
    public string? ClientContactFirstname { get; set; }

    /// <summary>
    /// Nom de l'interlocuteur chez le client
    /// </summary>
    [MaxLength(50)]
    public string? ClientContactLastname { get; set; }

    /// <summary>
    /// Fonction de l'interlocuteur chez le client
    /// </summary>
    [MaxLength(100)]
    public string? ClientContactFunction { get; set; }

    /// <summary>
    /// E-mail de l'interlocuteur chez le client
    /// </summary>
    [MaxLength(150)]
    public string? ClientContactMail { get; set; }

    /// <summary>
    /// Téléphone de l'interlocuteur chez le client
    /// </summary>
    [MaxLength(40)]
    public string? ClientContactPhone { get; set; }

    /// <summary>
    /// Identifiant du marché
    /// </summary>
    public Guid? MarketId { get; set; }

    /// <summary>
    /// Nom de l'opération
    /// </summary>
    [MaxLength(150)]
    public string? ProjectName { get; set; }

    /// <summary>
    /// Adresse du projet
    /// </summary>
    [MaxLength(150)]
    public string? ProjectAddress { get; set; }

    /// <summary>
    /// Complément d'adresse du projet
    /// </summary>
    [MaxLength(50)]
    public string? ProjectAddressComplement { get; set; }

    /// <summary>
    /// Cedex adresse du projet
    /// </summary>
    [MaxLength(50)]
    public string? ProjectAddressCedex { get; set; }

    /// <summary>
    /// Code Postal du projet
    /// </summary>
    [MaxLength(5)]
    public string? ProjectPostCode { get; set; }

    [MaxLength(50)]
    public string? ProjectTown { get; set; }

    /// <summary>
    /// Surface de construction
    /// </summary>
    public int? ProjectSurface { get; set; }

    /// <summary>
    /// Identifiant du stade d'avancement
    /// </summary>
    public Guid? ProjectAdvancementId { get; set; }

    /// <summary>
    /// Description du projet et points particuliers
    /// </summary>
    public Pass_ProjectDescription? _ProjectDescription { get; set; }

    [NotMapped]
    public string? ProjectDescription
    {
        get => _ProjectDescription?.ProjectDescription;
        set
        {
            if (value is null && _ProjectDescription is null) return;
            if (value is not null && _ProjectDescription is null) _ProjectDescription = new() { Id = Id };
            _ProjectDescription.ProjectDescription = value;
        }
    }

    /// <summary>
    /// Date prévisionnelle de démarrage des travaux
    /// </summary>
    public DateTime? EstimatedStartDate { get; set; }

    /// <summary>
    /// Durée prévisionnelle des travaux
    /// en mois
    /// </summary>
    public decimal? EstimatedTermInMonths { get; set; }

    /// <summary>
    /// Montant prévisionnel des travaux
    /// en € HT
    /// </summary>
    public int? EstimatedCost { get; set; }

    /// <summary>
    /// Montant Voiries et Réseaux Divers
    /// </summary>
    public int? AmountVRD { get; set; }

    /// <summary>
    /// Montant simulation, équipements, etc...
    /// </summary>
    public int? AmountProcess { get; set; }

    /// <summary>
    /// Permis de construire délvré (ou en attente)
    /// </summary>
    public bool IsConstrutPermitDeliverd { get; set; }

    /// <summary>
    /// Date d'obtention du permis de construire
    /// </summary>
    public DateTime? ConstrucPermitDeliveryDate { get; set; }

    /// <summary>
    /// Numéro du permis de construire
    /// </summary>
    [MaxLength(50)]
    public string? ConstrucPermitNumber { get; set; }

    /// <summary>
    /// Certification environnementale recherchée ?
    /// </summary>
    public bool EnvironmentalCertificateSought { get; set; }

    /// <summary>
    /// Accompagnement souhaité
    /// </summary>
    public bool EnvironmentalCertificateSupportSought { get; set; }

    /// <summary>
    /// Existe-t-il un bâtiment à démolir ?
    /// </summary>
    public bool BuildingToPullDown { get; set; }

    /// <summary>
    /// Année de construction du bâtiment à démolir
    /// </summary>
    public int? BuildingToPullConstructionYear { get; set; }

    /// <summary>
    /// Surface à démolir
    /// </summary>
    public int? BuildingToPullDownSurface { get; set; }

    /// <summary>
    /// Nombre de bâtiments
    /// </summary>
    public int? NbBuilding { get; set; }

    /// <summary>
    /// Nombre d'appartements
    /// </summary>
    public int? NbApartments { get; set; }

    /// <summary>
    /// Nombre de maisons
    /// </summary>
    public int? NbHouses { get; set; }

    /// <summary>
    /// Nombre de cages d'escalier
    /// </summary>
    public int? NbStairwells { get; set; }

    [MaxLength(100)]
    public string? ContactName { get; set; }

    [MaxLength(8)]
    public string? ContactMatricule { get; set; }

    [MaxLength(100)]
    public string? ContactFunction { get; set; }

    [MaxLength(40)]
    public string? ContactPhone { get; set; }

    [MaxLength(150)]
    public string? ContactMail { get; set; }

    [MaxLength(100)]
    public string? SignatoryName { get; set; }

    [MaxLength(8)]
    public string? SignatoryMatricule { get; set; }

    [MaxLength(100)]
    public string? SignatoryFunction { get; set; }

    public DateTime RedactionDate { get; set; }

    [MaxLength(50)]
    public string? AtlasClientId { get; set; }

    public int? LogoId { get; set; }

    /// <summary>
    /// Remise commerciale présente sur l'offre
    /// </summary>
    public bool DiscountProposed { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Identifiant de l'utilisateur ayanyt enregistré le PASS
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    [MaxLength(100)]
    public string? UserName { get; set; }

    [MaxLength(8)]
    public string? UserMatricule { get; set; }

    /// <summary>
    /// Date d'enregistrement du PASS en base de données
    /// </summary>
    [Required]
    public DateTime ModificationDate { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    public Pass_PaymentPlan? _PaymentPlan { get; set; }

    [NotMapped]
    public string? PaymentPlan
    {
        get => _PaymentPlan?.PaymentPlan;
        set
        {
            if (value is null && _PaymentPlan is null) return;
            if (value is not null && _PaymentPlan is null) _PaymentPlan = new() { Id = Id };
            _PaymentPlan!.PaymentPlan = value;
        }
    }

    public int? PdfId { get; set; }

    public DateTime? PdfDate { get; set; }

    /// <summary>
    /// In order to track if annexe should be re-generated
    /// </summary>
    public bool AnnexeUpdated { get; set; }

    public int PaymentCondition { get; set; }

    public Pass_PaymentDetail? _PaymentDetail { get; set; }

    [NotMapped]
    public string? PaymentDetail
    {
        get => _PaymentDetail?.PaymentDetail;
        set
        {
            if (value is null && _PaymentDetail is null) return;
            if (value is not null && _PaymentDetail is null) _PaymentDetail = new() { Id = Id };
            _PaymentDetail.PaymentDetail = value;
        }
    }

    public bool IsPaymentPlanReviseable { get; set; }

    public bool UseInstallments { get; set; }

    //public ICollection<Installment>? Installments { get; set; }

    /// <summary>
    /// n° de version du dernier envoi Atlas
    /// on incrémente de 1 pour n'importe qu'elle envoi (groupé) de création / modification / suppression
    /// </summary>
    public int AtlasVersion { get; set; }

    /// <summary>
    /// numéro de version Atlas lors de la génération du PDF
    /// </summary>
    public int PdfAtlasVersion { get; set; }

    public bool PricingRequired { get; set; }

    public bool PricingRequested { get; set; }

    public Pass_PricingProjectDescription? _PricingProjectDescription { get; set; }

    public int NbInstallments { get; set; }

    public int NbConstructionPermits { get; set; }

    [NotMapped]
    public string? PricingProjectDescription
    {
        get => _PricingProjectDescription?.PricingProjectDescription;
        set
        {
            if (value is null && _PricingProjectDescription is null) return;
            if (value is not null && _PricingProjectDescription is null) _PricingProjectDescription = new() { Id = Id };
            _PricingProjectDescription.PricingProjectDescription = value;
        }
    }

    [Timestamp]
    public byte[]? ConcurrencyToken { get; set; }

    public string? CurseursJson { get; set; }

    public decimal? EstimatedPreparationDelayInMonths { get; set; }
}