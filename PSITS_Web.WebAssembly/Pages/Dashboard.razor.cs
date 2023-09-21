using Microsoft.AspNetCore.Components;
using PSITS_Web.Common;
using PSITS_Web.WebAssembly.Services;
using PSITS_Web.WebAssembly.Utils;

namespace PSITS_Web.WebAssembly.Pages
{
	public partial class Dashboard
	{
		[Inject]
		private AuthenticationApiService AuthenticationApiService { get; set; }

		[Inject]
		private NavigationManager NavigationManager { get; set; }

        [Inject]
        public IOfficeLogDataService OfficeLogDataService { get; set; }

        private OfficeLogs OfficeLogs = new();
        private DateTime Date;
        public User User { get; set; } = new User();

        protected override void OnInitialized()
        {
            Date = DateTime.Now;
        }

        protected async override Task OnInitializedAsync()
		{
			// grab the user data from API call
			User _userData = await AuthenticationApiService.GetCurrentUser();

			// check if user is not null, otherwise, return to login page
			if (_userData == null)
			{
				NavigationManager.NavigateTo("/login");
			}
			else
			{
				User = _userData;
			}
            // grab the data
            await LoadOfficeLogs();
        }

        private async Task LoadOfficeLogs()
        {
            OfficeLogs = await OfficeLogDataService.GetAllOfficeLogs("", new DateTime(Date.Year, Date.Month, 1), new DateTime(Date.Year, Date.Month, CalendarUtils.GetNumberOfDaysInMonth(Date.Year, Date.Month)));
            Console.WriteLine($"Loaded Office Logs for [Year: {Date.Year}, Month: {Date.Month}]");
            StateHasChanged();
        }
    }
}
