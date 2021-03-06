namespace AsyncObservables.Services
{
    using System;
    using System.Threading.Tasks;

    internal class PrimeCheckService
    {
        public virtual async Task<bool> IsPrimeAsync(int number)
        {
            bool check() {
                for (int j = 2; j <= Math.Sqrt(number); j++)
                {
                    if (number % j == 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            return await Task.Run(check);
        }
    }
}