using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class FsmNetwork
    {
        private readonly List<FsmEnsemble> _fsmEnsembleList;
        public readonly INameGenerating NameGenerator;
        public readonly string Name;
        private volatile int _currentPositionZ;
        public FsmNetwork(INameGenerating nameGenerator, string name = "")
        {
            NameGenerator = nameGenerator;
            if (name == "")
                name = NameGenerator.GenerateFsmNetworkName();
            Name = name;
            _fsmEnsembleList = new List<FsmEnsemble>();
            _currentPositionZ = 0;
        }
        public FsmEnsemble AddFsmEnsemble(string name = "")
        {
            if (name == "")
                name = NameGenerator.GenerateFsmEnsembleName();
            FsmEnsemble fsmEnsemble = new FsmEnsemble(this, name, _currentPositionZ++);
            _fsmEnsembleList.Add(fsmEnsemble);
            return fsmEnsemble;
        }
        public void EvaluateNextState()
        {
            foreach (FsmEnsemble fsmEnsemble in _fsmEnsembleList)
            {
                fsmEnsemble.EvaluateNextState();
            }
        }
        public void ExecuteTriggers()
        {
            foreach (FsmEnsemble fsmEnsemble in _fsmEnsembleList)
            {
                fsmEnsemble.ExecuteTriggers();
            }
        }
        public void BalanceWeightings()
        {
            foreach (FsmEnsemble fsmEnsemble in _fsmEnsembleList)
            {
                fsmEnsemble.BalanceWeightings();
            }
        }
        public void ResetStatisticsForBalance()
        {
            foreach (FsmEnsemble fsmEnsemble in _fsmEnsembleList)
            {
                fsmEnsemble.ResetStatisticsForBalance();
            }
        }
    }
}
