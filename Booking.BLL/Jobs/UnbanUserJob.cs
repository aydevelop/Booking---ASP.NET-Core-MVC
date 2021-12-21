using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using System;

namespace Booking.BLL.Jobs
{
    public class UnbanUserJob
    {
        public static string Interval = "* */1 * * *";
        private readonly IExplorerRepository _explorerRepository;

        public UnbanUserJob(IExplorerRepository explorerRepository)
        {
            _explorerRepository = explorerRepository;
        }

        public void Run()
        {
            var items = _explorerRepository.GetAll().Result;
            DateTime now = DateTime.Now;
            for (int i = 0; i < items.Count; i++)
            {
                Explorer item = items[i];
                if (item.DateFromState <= now)
                {
                    item.State = ExplorerState.Active;
                    item.DateFromState = null;
                    _explorerRepository.Update(item).Wait();
                }
            }
        }
    }
}
