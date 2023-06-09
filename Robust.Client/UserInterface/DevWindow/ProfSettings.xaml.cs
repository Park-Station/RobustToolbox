﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using Robust.Shared;
using Robust.Shared.Configuration;
using Robust.Shared.IoC;
using Robust.Shared.Profiling;
using Robust.Shared.Utility;

namespace Robust.Client.UserInterface;

[GenerateTypedNameReferences]
internal sealed partial class ProfSettings : Control
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public ProfSettings()
    {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);
    }

    protected override void EnteredTree()
    {
        _cfg.OnValueChanged(CVars.ProfEnabled, CfgEnabledChanged, true);
        _cfg.OnValueChanged(CVars.ProfBufferSize, CfgBufferSizeChanged, true);
        _cfg.OnValueChanged(CVars.ProfIndexSize, CfgIndexSizeChanged, true);
    }

    protected override void ExitedTree()
    {
        _cfg.UnsubValueChanged(CVars.ProfEnabled, CfgEnabledChanged);
        _cfg.UnsubValueChanged(CVars.ProfBufferSize, CfgBufferSizeChanged);
        _cfg.UnsubValueChanged(CVars.ProfIndexSize, CfgIndexSizeChanged);
    }

    private void CfgEnabledChanged(bool obj)
    {
        SettingEnabled.Pressed = obj;
    }

    private unsafe void CfgBufferSizeChanged(int obj)
    {
        var bytes = BufferHelpers.FittingPowerOfTwo(obj) * sizeof(ProfLog);
        SettingBufferSize.Text = $"{obj} ({ByteHelpers.FormatBytes(bytes)})";
    }

    private unsafe void CfgIndexSizeChanged(int obj)
    {
        var bytes = BufferHelpers.FittingPowerOfTwo(obj) * sizeof(ProfIndex);
        SettingIndexSize.Text = $"{obj} ({ByteHelpers.FormatBytes(bytes)})";
    }
}
