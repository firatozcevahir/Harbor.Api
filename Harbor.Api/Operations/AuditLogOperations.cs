using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Harbor.Api.ResponseModels;

namespace Harbor.Api.Operations
{
    public interface IAuditLogOperations
    {
        Task<IList<LogResponse>> ListAuditLogs(int page = 1, int pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));
    }
    public class AuditLogOperations : IAuditLogOperations
    {
        private readonly HarborClient _client;
        public AuditLogOperations(HarborClient client)
        {
            _client = client;
        }

        public async Task<IList<LogResponse>> ListAuditLogs(int page = 1, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                "audit-logs",
                 $"page={page}&page_size={pageSize}",
                cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<IList<LogResponse>>(result.Body);
        }
    }

}
