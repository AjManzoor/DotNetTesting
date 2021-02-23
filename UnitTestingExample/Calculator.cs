using System;

namespace UnitTestingExample
{
    public class Calculator 
    {
        private readonly IStore _store;
        
        public Calculator(IStore store)
        {
            _store = store;
        }
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return 0;

            var numbers = input.Split(',');
            var total = 0;

            foreach(var number in numbers)
            {
                total += TryParseToInteger(number);
            }

            if(_store != null)
                if (IsPrime(total))
                    _store.Save(total);

            return total;
        }

        private int TryParseToInteger(string input)
        {
            int dest;

            if (!int.TryParse(input, out dest))
                throw new ArgumentException("Incorrect Format");

            return dest;
        }

        private bool IsPrime(int number)
        {
            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            for(int i = 3; i <=(int)(Math.Sqrt(number)); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
