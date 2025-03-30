using Advent_of_Code_2024.day24.gate;

namespace Advent_of_Code_2024.day24.circuit;

public partial class Circuit
{
    private class Gate(GateLogic gateLogic) : AbstractCircuitElement
    {
        private int? _input1Value;
        private int? _input2Value;

        private bool _isInput1Connected;
        private bool _isInput2Connected;

        public Gate ConnectInput1To(Wire wire)
        {
            return ConnectInputTo(wire,
                isInputConnected: ref _isInput1Connected,
                onNewValue: val => _input1Value = val);
        }

        public Gate ConnectInput2To(Wire wire)
        {
            return ConnectInputTo(wire,
                isInputConnected: ref _isInput2Connected,
                onNewValue: val => _input2Value = val);
        }

        private Gate ConnectInputTo(Wire wire, ref bool isInputConnected, Action<int> onNewValue)
        {
            if (isInputConnected)
            {
                throw new InvalidOperationException("Input already connected");
            }

            isInputConnected = true;

            wire.AddOutputObserver(newValue =>
            {
                onNewValue(newValue);
                TryActivateSelf();
            });

            return this;
        }

        private void TryActivateSelf()
        {
            if (_input1Value == null || _input2Value == null) return;

            OutputValue = gateLogic.Compute((int)_input1Value, (int)_input2Value);
            Notify(OutputObservers);
        }
    }
}