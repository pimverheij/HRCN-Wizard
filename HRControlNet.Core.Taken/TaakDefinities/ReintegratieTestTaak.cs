using HRControlNet.Core.Data;
using HRControlNet.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRControlNet.Core.Taken.TaakDefinities
{
    public class ReintegratieTestTaak : ITaakDefinitie
    {
        public TaakType Type => TaakType.ReintegratieTestTaak;

        public string Toelichting => "Dit is een re-integratie test";

        public string WizardStartUrl => "/ReintegratieTestTaak/StapStart";

        public bool MagAfwijzen => throw new NotImplementedException();
    }
}
