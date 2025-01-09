using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReproDistinct.DAL;

public abstract class ReproDbContextBase<P, PM> : DbContext
    where P : Pass<P, PM>
    where PM : Link_Pass_Mission<P, PM>
{
    public DbSet<P> Pass { get; set; }

    public DbSet<Link_Pass_Affaire<P, PM>> Affaires { get; set; }

    public ReproDbContextBase(DbContextOptions<ReproDbContextBase<P, PM>> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public ReproDbContextBase(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected virtual void OnModelCreating<M, W, T, C, E, A>(
        EntityTypeBuilder<P> builder_Entity_Pass,
        EntityTypeBuilder<M> builder_Link_Mission,
        EntityTypeBuilder<W> builder_Link_WrkTyp,
        EntityTypeBuilder<T> builder_Link_Typo,
        EntityTypeBuilder<C> builder_Link_Cat,
        EntityTypeBuilder<E> builder_Link_EnvCert,
        EntityTypeBuilder<A> builder_Link_Affaire)
        where M : PM
        where W : Link_Pass_WrkTyp<P, PM>
        where T : Link_Pass_PrjTypo<P, PM>
        where C : Link_Pass_PrjCat<P, PM>
        where E : Link_Pass_EnvCert<P, PM>
        where A : Link_Pass_Affaire<P, PM>
    {
        //===============================================================
        // PASS
        builder_Entity_Pass
            .ToTable("Pass")
            .HasKey(nameof(Pass<P, PM>.Id));

        builder_Entity_Pass
            .Property(nameof(Models.Pass<P, PM>.IsPaymentPlanReviseable))
            .HasDefaultValue(true);

        builder_Entity_Pass
            .HasMany<Link_Pass_WrkTyp<P, PM>>(pass => pass.WorkTypes)
            .WithOne(link => link.Entity)
            .OnDelete(DeleteBehavior.Cascade);

        builder_Entity_Pass
            .HasMany<Link_Pass_PrjTypo<P, PM>>(pass => pass.ProjectTypologies)
            .WithOne(link => link.Entity)
            .OnDelete(DeleteBehavior.Cascade);

        builder_Entity_Pass
            .HasMany<Link_Pass_PrjCat<P, PM>>(pass => pass.ProjectCategories)
            .WithOne(link => link.Entity)
            .OnDelete(DeleteBehavior.Cascade);

        builder_Entity_Pass
            .HasMany<Link_Pass_EnvCert<P, PM>>(pass => pass.EnvironmentalCertifications)
            .WithOne(link => link.Entity)
            .OnDelete(DeleteBehavior.Cascade);

        builder_Entity_Pass
            .HasMany<Link_Pass_Affaire<P, PM>>(pass => pass.AtlasAffaires)
            .WithOne(link => link.Entity)
            .OnDelete(DeleteBehavior.Cascade);

        builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.ModificationDate));
        builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.UserName));
        builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.AgencyId));
        builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.ClientName));
        //builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.ContactName));
        //builder_Entity_Pass.HasIndex(nameof(Models.Pass<P, PM>.LogoId));

        builder_Entity_Pass
            .Property(nameof(Models.Pass<P, PM>.PricingRequired))
            .HasDefaultValue(true);

        builder_Entity_Pass
            .OwnsOne(pass => pass._PaymentDetail)
            .ToTable("Pass_PaymentDetails")
            .HasKey(owned => owned.Id);

        builder_Entity_Pass
            .OwnsOne(pass => pass._PaymentPlan)
            .ToTable("Pass_PaymentPlans")
            .HasKey(owned => owned.Id);

        builder_Entity_Pass
            .OwnsOne(pass => pass._PricingProjectDescription)
            .ToTable("Pass_PricingProjectDescriptions")
            .HasKey(owned => owned.Id);

        builder_Entity_Pass
            .OwnsOne(pass => pass._ProjectDescription)
            .ToTable("Pass_ProjectDescriptions")
            .HasKey(owned => owned.Id);

        //===============================================================
        // PASS => PassMissions
        builder_Link_Mission
            .ToTable("Link_Pass_Mission")
            .HasKey(fg => fg.Id);
        ;

        //===============================================================
        // PASS => WorkType
        builder_Link_WrkTyp
            .ToTable("Link_Pass_WrkTyp")
            .HasKey(fg => fg.Id)
            ;

        //===============================================================
        // PASS => ProjectTypology
        builder_Link_Typo
            .ToTable("Link_Pass_PrjTypo")
            .HasKey(fg => fg.Id)
            ;

        //===============================================================
        // PASS => ProjectCategory
        builder_Link_Cat
            .ToTable("Link_Pass_PrjCat")
            .HasKey(fg => fg.Id)
            ;

        //====================================7===========================
        // PASS => EnvironmentalCertification
        builder_Link_EnvCert
            .ToTable("Link_Pass_EnvCert")
            .HasKey(fg => fg.Id)
            ;

        //===============================================================
        // PASS => AtlasAffaire
        builder_Link_Affaire
            .ToTable("Link_Pass_AtlasAffaire")
            .HasKey(fg => fg.Id)
            ;

        builder_Link_Affaire
            .HasIndex(nameof(Link_Pass_Affaire<P, PM>.AtlasId));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //===============================================================
        // Set default precision to decimal property
        var decimalProperties = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

        foreach (var property in decimalProperties)
        {
            property.SetColumnType("decimal(18, 2)");
        }

        //===============================================================
        // Echeancier => Mission
        modelBuilder.Entity<Link_Echeancier_Mission>()
            .ToTable("Link_Echeancier_Mission")
            ;

        //===============================================================
        // LogAffaires
        var logAffaireBuilder = modelBuilder.Entity<LogAffaire>();
        logAffaireBuilder.HasIndex(fg => fg.TimeStamp);
        logAffaireBuilder.HasIndex(fg => fg.PassId);

        //===============================================================
        // EcheancierModel
        //modelBuilder.Entity<EcheancierModel>();
    }
}

public class ReproPass : Pass<ReproPass, ReproPassMission>;

public class ReproPassMission : Link_Pass_Mission<ReproPass, ReproPassMission>;

public class ReproDbContext : ReproDbContextBase<ReproPass, ReproPassMission>
{
    public ReproDbContext(DbContextOptions<ReproDbContext> options) : base(options)
    { }
}