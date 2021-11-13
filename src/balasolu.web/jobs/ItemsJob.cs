using balasolu.web.services.interfaces;
using Quartz;
using System.Threading.Tasks;

namespace balasolu.web.jobs
{
    [DisallowConcurrentExecution]
    sealed class ItemsJob : IJob
    {
        readonly IItemService _itemService;

        public ItemsJob(
            IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task Execute(IJobExecutionContext context) =>
            await _itemService.PopulateDbTableAsync();
    }
}
