using System;
using System.Collections.Generic;
using System.Linq;
 
namespace CardApps.Common
{
    public class War
    {
        #region Alternate Game Play

        private PlayerObject _player1;
        private PlayerObject _player2;
        
        public int TurnCount;
        public bool Game(string _player1name, string _player2name)
        {
            _player1 = new PlayerObject(_player1name);
            _player2 = new PlayerObject(_player2name);

            var cards = DeckCreator.CreateCards(GameType.war); //Returns a shuffled set of cards

            var deck = _player1.Deal(cards); //Returns _player2's deck.  _player1 keeps his.
            _player2.Deck = deck;

            return true;
        }

        public bool IsEndOfGame()
        {
            if (!_player1.Deck.Any())
            {
                Console.WriteLine(_player1.Name + " is out of cards!  " + _player2.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if (!_player2.Deck.Any())
            {
                Console.WriteLine(_player2.Name + " is out of cards!  " + _player1.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if (TurnCount > 1000)
            {
                Console.WriteLine("Infinite game!  Let's call the whole thing off.");
                return true;
            }
            return false;
        }

        public void PlayTurn()
        {
            Queue<Card2> pool = new Queue<Card2>();

            var _player1card = _player1.Deck.Dequeue();
            var _player2card = _player2.Deck.Dequeue();

            pool.Enqueue(_player1card);
            pool.Enqueue(_player2card);

            Console.WriteLine(_player1.Name + " plays " + _player1card.DisplayName + ", " + _player2.Name + " plays " + _player2card.DisplayName);

            while (_player1card.Value == _player2card.Value)
            {
                Console.WriteLine("WAR!");
                if (_player1.Deck.Count < 4)
                {
                    _player1.Deck.Clear();
                    return;
                }
                if (_player2.Deck.Count < 4)
                {
                    _player2.Deck.Clear();
                    return;
                }

                pool.Enqueue(_player1.Deck.Dequeue());
                pool.Enqueue(_player1.Deck.Dequeue());
                pool.Enqueue(_player1.Deck.Dequeue());
                pool.Enqueue(_player2.Deck.Dequeue());
                pool.Enqueue(_player2.Deck.Dequeue());
                pool.Enqueue(_player2.Deck.Dequeue());

                _player1card = _player1.Deck.Dequeue();
                _player2card = _player2.Deck.Dequeue();

                pool.Enqueue(_player1card);
                pool.Enqueue(_player2card);

                Console.WriteLine(_player1.Name + " plays " + _player1card.DisplayName + ", " + _player2.Name + " plays " + _player2card.DisplayName);
            }

            if (_player1card.Value < _player2card.Value)
            {
                foreach (var item in pool)
                {
                    _player2.Deck.Enqueue(item);
                }
                //_player2.Deck.Enqueue(pool);
                Console.WriteLine(_player2.Name + " takes the hand!");
            }
            else
            {
                foreach (var item in pool)
                {
                    _player1.Deck.Enqueue(item);
                }
                //_player1.Deck.Enqueue(pool);
                Console.WriteLine(_player1.Name + " takes the hand!");
            }

            TurnCount++;
        }
        #endregion
    }
}
