using Content.Shared.GreyStation.Hailer;
using Robust.Client.GameObjects;
using Robust.Client.Player;
using Robust.Client.UserInterface;
using System.Numerics;

namespace Content.Client.GreyStation.Hailer.UI;

public sealed class HailerBoundUserInterface : BoundUserInterface
{
    [Dependency] private readonly IPlayerManager _player = default!;
    private readonly SharedHailerSystem _hailer = default!;
    private readonly SpriteSystem _sprite = default!;

    private HailerRadialMenu? _menu;

    public HailerBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
        _hailer = EntMan.System<SharedHailerSystem>();
        _sprite = EntMan.System<SpriteSystem>();
    }

    protected override void Open()
    {
        base.Open();

        if (_menu == null)
        {
            _menu = new(Owner, EntMan, _player, _hailer, _sprite);

            _menu.OnLinePicked += index =>
            {
                SendPredictedMessage(new HailerPlayLineMessage(index));
                Close();
            };

            _menu.OnClose += () => Close();
        }

        _menu.OpenCentered();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing)
            return;

        _menu?.Close();
        _menu?.Dispose();
    }
}
