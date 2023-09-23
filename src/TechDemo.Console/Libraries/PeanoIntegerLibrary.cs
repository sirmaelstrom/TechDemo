namespace TechDemo.Console.Libraries;

/// <summary>
/// Peano integers are a way to represent natural numbers using a recursive data structure.
/// Each Peano integer is either 0 (Z) or the successor of another Peano integer (S).
/// </summary>
public class PeanoIntegerLibrary
{
    /// <summary>
    /// Abstract class representing Peano integers, with basic methods for addition, subtraction and conversions
    /// </summary>
    public abstract class PeanoInteger
    {
        public abstract bool IsZero();
        public abstract PeanoInteger Predecessor();
        public abstract PeanoInteger Successor();
        public abstract PeanoInteger Add(PeanoInteger other);
        public abstract PeanoInteger Subtract(PeanoInteger other);
        public abstract int ToInt();
    }

    /// <summary>
    /// Concrete class representing the Peano integer 0 (Z)
    /// </summary>
    public class Zero : PeanoInteger
    {
        public override bool IsZero() => true;
        public override PeanoInteger Predecessor() => throw new InvalidOperationException("Zero has no predecessor.");
        public override PeanoInteger Successor() => new Succ(this);
        public override PeanoInteger Add(PeanoInteger other) => other;
        public override PeanoInteger Subtract(PeanoInteger other)
        {
            if (other.IsZero())
                return this;
            throw new InvalidOperationException("Subtraction would result in a negative number.");
        }
        public override int ToInt() => 0;
        public override string ToString() => "Zero";
    }

    /// <summary>
    /// Concrete class representing the successor of a Peano integer (S)
    /// </summary>
    public class Succ : PeanoInteger
    {
        private readonly PeanoInteger predecessor;
        public Succ(PeanoInteger predecessor) => this.predecessor = predecessor;
        public override bool IsZero() => false;
        public override PeanoInteger Predecessor() => predecessor;
        public override PeanoInteger Successor() => new Succ(this);
        public override PeanoInteger Add(PeanoInteger other)
        {
            PeanoInteger result = this;
    
            while (!other.IsZero())
            {
                result = result.Successor();
                other = other.Predecessor();
            }

            return result;
        }

        public override PeanoInteger Subtract(PeanoInteger other)
        {
            if (other.IsZero())
                return this;
            return predecessor.Subtract(other.Predecessor());
        }
        public override int ToInt() => 1 + predecessor.ToInt();
        public override string ToString() => $"Succ({predecessor})";
    }
}