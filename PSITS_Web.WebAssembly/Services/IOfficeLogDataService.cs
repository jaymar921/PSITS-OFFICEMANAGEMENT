using PSITS_Web.Common;

namespace PSITS_Web.WebAssembly.Services
{
    public interface IOfficeLogDataService
    {
        /// <summary>
        /// Retreives all office logs in a span of <paramref name="min"/> and <paramref name="max"/> <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Task<OfficeLogs> GetAllOfficeLogs(string option = "", DateTime min = new (), DateTime max = new ());

        /// <summary>
        /// Logs-in the User when it's not logged yet.
        /// 
        /// Accepts a userId and will be send in the API for validation,
        /// Cookie Credentials must also be present when using this request.
        /// Therefor, the user must be Authenticated first.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task OpenOfficeLogs();

        /// <summary>
        /// Logs-out the User when it's not logged off yet.
        /// 
        /// Accepts a userId and will be sent in the API for validation.
        /// Cookie Credentials must also be present when using this request.
        /// Therefor the user must be Authenticated first.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task CloseOfficeLog();
    }
}
