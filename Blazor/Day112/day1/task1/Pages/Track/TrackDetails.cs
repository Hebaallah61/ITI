using Microsoft.AspNetCore.Components;
using SharedModel;

namespace task1.Pages.Track
{
    public partial class TrackDetails
    {
        [Parameter]
        public int Id { get; set; }

        public SharedModel.Track? card { get; set; }

        protected override async Task OnInitializedAsync()
        {
            card = LattieData.Tracks.FirstOrDefault(i => i.Id == Id);
            await base.OnInitializedAsync();
        }
    }
}
