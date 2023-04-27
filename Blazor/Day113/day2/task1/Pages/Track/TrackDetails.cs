using Microsoft.AspNetCore.Components;
using SharedModel;
using task1.Services;

namespace task1.Pages.Track
{
    public partial class TrackDetails
    {
        [Parameter]
        public int Id { get; set; }

        public SharedModel.Track? card { get; set; }
        [Inject]
        public ITrack trackDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            card = await trackDataService.GetTrackDetails(Id);
            await base.OnInitializedAsync();
        }
    }
}
