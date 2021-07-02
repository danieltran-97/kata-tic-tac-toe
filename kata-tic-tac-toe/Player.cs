namespace kata_tic_tac_toe
{
    public class Player
    {
        public string Name { get; set; }

        public char Marker { get; set; }

        public Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}