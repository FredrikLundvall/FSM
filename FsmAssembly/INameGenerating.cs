using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public interface INameGenerating
    {
        string GenerateFsmNetworkName();
        string GenerateFsmEnsembleName();
        string GenerateFsmName();
        string GenerateStateName();
    }
}
