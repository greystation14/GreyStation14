using Robust.Shared.GameStates;

namespace Content.Shared.GreyStation.Cuffs;

/// <summary>
/// Clothing that lets you cuff people faster when they are not standing (stunned, sleeping, lying down wyci)
/// </summary>
[RegisterComponent, NetworkedComponent, Access(typeof(FastCuffingSystem))]
public sealed partial class FastCuffingComponent : Component
{
    /// <summary>
    /// How much faster cuffing will be.
    /// Keep in mind this stacks with the handcuff's existing reduction when stunned.
    /// </summary>
    [DataField]
    public TimeSpan Reduction = TimeSpan.FromSeconds(0.2);
}
