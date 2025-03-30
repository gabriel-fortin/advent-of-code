namespace Advent_of_Code_2024.day24.circuit;

public partial class Circuit
{
    private class Wire : AbstractCircuitElement
    {
        private bool _isInputConnected;
        private bool _isInputSet;

        public Wire SetValue(int value)
        {
            if (_isInputConnected)
            {
                throw new InvalidOperationException("Input is connected; cannot set value when a connection exists");
            }

            _isInputSet = true;

            OutputValue = value;
            TryActivateSelf();

            return this;
        }

        public Wire ConnectInputTo(Gate gate)
        {
            if (_isInputSet)
            {
                throw new InvalidOperationException("Input's value is set; cannot connect if value is set manually");
            }

            if (_isInputConnected)
            {
                throw new InvalidOperationException("Input is already connected; cannot be connected again");
            }

            _isInputConnected = true;

            gate.AddOutputObserver(newValue =>
            {
                OutputValue = newValue;
                TryActivateSelf();
            });

            return this;
        }

        private void TryActivateSelf()
        {
            if (OutputValue == null) return;
            Notify(OutputObservers);
        }
    }
}