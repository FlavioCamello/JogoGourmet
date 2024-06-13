namespace JogoGourmet.Model
{
    public class Plate : IComparable<Plate>
    {
        public Plate(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Plate other)
        {
            int comp = 0;
            if (Name.Equals(other.Name))
                comp = 1;
            return comp;
        }
    }
}
