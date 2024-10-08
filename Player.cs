namespace ChessLibrary
{
    public enum Player//класс для определений параметров игрока
    {
        None,
        White,
        Black
    }
    public static class PlayerExtenstions
    {
        public static Player Opponent(this  Player player)
        {
            switch(player) 
            {
                case Player.White: return Player.Black;
                case Player.Black: return Player.White;
                default: return Player.None;
            }
        }
    }
}
