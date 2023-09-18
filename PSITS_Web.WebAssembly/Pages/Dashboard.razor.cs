using Microsoft.AspNetCore.Components;
using PSITS_Web.Common;
using PSITS_Web.WebAssembly.Services;

namespace PSITS_Web.WebAssembly.Pages
{
	public partial class Dashboard
	{
		[Inject]
		private AuthenticationApiService AuthenticationApiService { get; set; }

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		public User User { get; set; } = new User();

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
			
		}
	}
}
