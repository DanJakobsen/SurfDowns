namespace SurfsDownsBlazor.Models
{
    public class Board
    {
        public Board() 
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            IsAvailable = randomNumber == 0? false : true;
        }

        public int BoardId { get; set; }
        public bool IsAvailable { get; set; }
        public string? Name { get; set; }
    }
}
