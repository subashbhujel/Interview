namespace InterviewPreparation
{
    /// <summary>
    /// Stores the color of an object in the card. 
    /// </summary>
    public enum Colors
    {
        Purple,
        Red,
        Green
    }

    /// <summary>
    /// Shape of the object in the card
    /// </summary>
    public enum Shapes
    {
        Oval,
        Round,
        Diamond
    }

    /// <summary>
    /// Stores the shade of the object in the card
    /// </summary>
    public enum Shades
    {
        None,
        Solid,
        Hatch
    }

    /// <summary>
    /// Stores the number of objects in the card.
    /// </summary>
    public enum ObjCounts
    {
        One,
        Two,
        Three
    }

    /// <summary>
    /// Card object
    /// </summary>
    public class Card
    {
        public Colors Color { get; set; }

        public Shapes Shape { get; set; }

        public Shades Shade { get; set; }

        public ObjCounts Count { get; set; }
    }
}