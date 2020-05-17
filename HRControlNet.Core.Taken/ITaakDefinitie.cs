using HRControlNet.Core.Data.Enums;
using System;

namespace HRControlNet.Core.Taken
{
    public interface ITaakDefinitie
    {
        TaakType Type { get; }
        string Toelichting { get; }
        string WizardStartUrl { get; }
        bool MagAfwijzen { get; }
    }
}
