using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class NameGenerator : INameGenerating
    {
        public readonly ThreadSafeRandom ThreadRandom;

        public NameGenerator(ThreadSafeRandom threadRandom)
        {
            ThreadRandom = threadRandom;
        }

        public string GenerateFsmEnsembleName()
        {
            return RandomNameGenerator.GenerateName(ThreadRandom, 5, 5) + " " + RandomNameGenerator.PickStringFromList(ThreadRandom, StringListEnum.Verb);
        }

        public string GenerateFsmName()
        {
            return RandomNameGenerator.GenerateName(ThreadRandom, 5, 5) + " " + RandomNameGenerator.PickStringFromList(ThreadRandom, StringListEnum.Adjective);
        }

        public string GenerateFsmNetworkName()
        {
            return RandomNameGenerator.GenerateName(ThreadRandom, 5, 5) + " " + RandomNameGenerator.PickStringFromList(ThreadRandom, StringListEnum.Color);
        }

        public string GenerateStateName()
        {
            return RandomNameGenerator.GenerateName(ThreadRandom, 5, 5) + " " + RandomNameGenerator.PickStringFromList(ThreadRandom, StringListEnum.Animal);
        }
    }
}
