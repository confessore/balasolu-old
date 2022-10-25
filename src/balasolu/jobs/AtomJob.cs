using balasolu.services.interfaces;
using Quartz;
using Serilog;

namespace balasolu.jobs
{
    [DisallowConcurrentExecution]
    sealed class AtomJob : IJob
    {
        readonly IAtomService _atomService;

        public AtomJob(
            IAtomService atomService)
        {
            _atomService = atomService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("executing atom jobs");
            await _atomService.UpdateDefaultFeedsAsync();
            await _atomService.UpdateTwitterFeedsAsync();
        }
    }
}
