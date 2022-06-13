namespace RobotSimulator.Toy
{
    public interface IToy
    {
        public Coordinate Position { get; set; }
        public Direction Facing { get; set; }
        public string Report();

    }
}
