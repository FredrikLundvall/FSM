using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class FsmEnsemble
    {
        private readonly List<FsmBase> _fsmList;
        public readonly FsmNetwork Parent;
        public readonly string Name;
        public readonly int PositionZ;
        private volatile int _currentPositionX;
        public FsmEnsemble(FsmNetwork parent, string name, int positionZ)
        {
            Parent = parent;
            Name = name;
            PositionZ = positionZ;
            _fsmList = new List<FsmBase>();
            _currentPositionX = 0;
        }
        protected FsmBase AddFsmBase(FsmBase fsm)
        {
            _fsmList.Add(fsm);
            return fsm;
        }
        public FsmInput AddFsmInput()
        {
            var fsm = new FsmInput(this, Parent.NameGenerator.GenerateFsmName(), _currentPositionX++);
            AddFsmBase(fsm);
            return fsm;
        }
        public FsmOutput AddFsmOutput()
        {
            var fsm = new FsmOutput(this, Parent.NameGenerator.GenerateFsmName(), _currentPositionX++);
            AddFsmBase(fsm);
            return fsm;
        }
        public Fsm AddFsm()
        {
            var fsm = new Fsm(this, Parent.NameGenerator.GenerateFsmName(), _currentPositionX++);
            AddFsmBase(fsm);
            return fsm;
        }
        //public FsmBase AddFsm(string name, int positionX, bool addIdleState = false, bool removable = true, SignalDirectionEnum signalDirection = SignalDirectionEnum.InputOutput, bool fixedNumberOfStates = false, bool selfRegulated = true)
        //{
        //    Fsm fsm = new Fsm(this, name, positionX, addIdleState, removable, signalDirection, fixedNumberOfStates, selfRegulated);
        //    _fsmList.Add(fsm);
        //    return fsm;
        //}
        //public FsmBase AddFsm(int positionX, bool addIdleState = false, bool removable = true, SignalDirectionEnum signalDirection = SignalDirectionEnum.InputOutput, bool fixedNumberOfStates = false, bool selfRegulated = true)
        //{
        //    return AddFsm(Parent.NameGenerator.GenerateFsmName(), positionX, addIdleState, removable, signalDirection, fixedNumberOfStates, selfRegulated);
        //}
        //public FsmBase AddFsm(bool addIdleState = false, bool removable = true, SignalDirectionEnum signalDirection = SignalDirectionEnum.InputOutput, bool fixedNumberOfStates = false, bool selfRegulated = true)
        //{
        //    return AddFsm(_fsmList.Count, addIdleState, removable, signalDirection, fixedNumberOfStates, selfRegulated);
        //}
        public void EvaluateNextState()
        {
            foreach (FsmBase fsm in _fsmList)
            {
                fsm.EvaluateNextState();
            }
        }
        public void ExecuteTriggers()
        {
            foreach (FsmBase fsm in _fsmList)
            {
                fsm.ExecuteTriggers();
            }
        }
        public void BalanceWeightings()
        {
            foreach (FsmBase fsm in _fsmList)
            {
                fsm.BalanceWeightings();
            }
        }
        public void ResetStatisticsForBalance()
        {
            foreach (FsmBase fsm in _fsmList)
            {
                fsm.ResetStatisticsForBalance();
            }
        }
    }
}
