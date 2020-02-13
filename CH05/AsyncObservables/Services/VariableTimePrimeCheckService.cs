namespace AsyncObservables.Services
{
    using System;
    using System.Threading.Tasks;

    internal class VariableTimePrimeCheckService : PrimeCheckService
    {
        private readonly int _numberToDelay;

        public VariableTimePrimeCheckService(int numberToDelay)
        {
            _numberToDelay = numberToDelay;
        }

        public override async Task<bool> IsPrimeAsync(int number)
        {
            if (number == _numberToDelay)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
            return await base.IsPrimeAsync(number);
        }
    }
}