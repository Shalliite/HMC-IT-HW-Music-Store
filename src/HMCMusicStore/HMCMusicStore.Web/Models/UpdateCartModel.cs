namespace HMCMusicStore.Web.Models
{
    public class UpdateCartModel
    {
        public string? UidToUpdate { get; set; }
        public int CountToUpdate { get; set; }

        public UpdateCartModel()
        {
            CountToUpdate = 0;
        }
    }
}
