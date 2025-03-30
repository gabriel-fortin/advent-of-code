using System.Diagnostics;

namespace Advent_of_Code_2024.day24.circuit;

public partial class Circuit
{
    private abstract class AbstractCircuitElement
    {
        public delegate void ValueReceiver(int value);
        
        public virtual int? OutputValue { get; protected set; }

        protected List<ValueReceiver> OutputObservers { get; } = [];

        public virtual AbstractCircuitElement AddOutputObserver(ValueReceiver observer)
        {
            OutputObservers.Add(observer);
            if (OutputValue != null)
            {
                Notify(observer);
            }

            return this;
        }

        protected virtual void Notify(params List<ValueReceiver> observers)
        {
            Debug.Assert(OutputValue != null);
            foreach (ValueReceiver observer in observers)
            {
                observer((int)OutputValue);
            }
        }
    }
}