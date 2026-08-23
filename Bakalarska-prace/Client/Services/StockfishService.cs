using Stockfish.NET;

namespace Bakalarska_prace.Services
{
    internal class StockfishService
    {
        private readonly IStockfish _stockfish;

        public StockfishService(string stockfishExecutablePath)
        {          
            _stockfish = new Stockfish.NET.Stockfish(stockfishExecutablePath);
            _stockfish.Depth = 5; 
        }

        public async Task<string> GetBestMoveAsync(string fen)
        {
            return await Task.Run(() =>
            {
                _stockfish.SetFenPosition(fen);
                return _stockfish.GetBestMove();
            });
        }

        public async Task<int> GetEvaluationAsync(string fen)
        {
            return await Task.Run(() =>
            {
                _stockfish.SetFenPosition(fen);
                var eval = _stockfish.GetEvaluation();
                return eval.Value;
            });
        }
    }
}
