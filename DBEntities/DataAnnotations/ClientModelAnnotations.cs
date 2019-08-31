using System.ComponentModel.DataAnnotations;

namespace DBEntities
{
    [MetadataType(typeof(ClientModelMetadata))]
    public partial class Client
    {
        // No field here
    }

    internal sealed class ClientModelMetadata
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(5)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(5)]
        public string lastName { get; set; }
    }
}
