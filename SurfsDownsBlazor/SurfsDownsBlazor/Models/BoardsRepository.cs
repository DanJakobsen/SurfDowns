namespace SurfsDownsBlazor.Models
{
    public static class BoardsRepository
    {
        private static List<Board> _boards = new List<Board>()
        {
          new Board { BoardId = 1, Name = "FastBoard" },
          new Board { BoardId = 2, Name = "SlowBoard" },
          new Board { BoardId = 3, Name = "FloatBoard" },
          new Board { BoardId = 4, Name = "PrimeBoard" },
          new Board { BoardId = 5, Name = "FiskeBoard" }
        };

        public static void AddBoard(Board board)
        {
            var maxId = _boards.Max(b  => b.BoardId);
            board.BoardId = maxId + 1;
            _boards.Add(board);
        }

        public static List<Board> GetBoards() => _boards;

        public static Board? GetBoardById(int id)
        {
            var board = _boards.Find(b => b.BoardId == id);
            if (board != null)
            {
                return new Board
                {
                    BoardId = board.BoardId,
                    Name = board.Name,
                    IsAvailable = board.IsAvailable
                };
            }
            return null;
        }

        public static void UpdateBoard(int boardId, Board board)
        {
            if (boardId != board.BoardId) return;

            var boardToUpdate = _boards.Find(b => b.BoardId == boardId);
            if (boardToUpdate != null)
            {
                boardToUpdate.Name = board.Name;
                boardToUpdate.IsAvailable = board.IsAvailable;
            }
        }

        public static void DeleteBoard(int boardId)
        {
            var board = _boards.Find(board => board.BoardId == boardId);
            if (board != null)
            {
                _boards.Remove(board);
            }
        }

        public static List<Board> SearchBoards(string boardSearch)
        {
            return _boards.Where(b => b.Name.Contains(boardSearch, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
