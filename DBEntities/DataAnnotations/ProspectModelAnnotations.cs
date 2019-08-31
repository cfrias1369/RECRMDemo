using System.ComponentModel.DataAnnotations;

namespace DBEntities
{
    [MetadataType(typeof(ProspectModelMetadata))]
    public partial class Prospect
    {
        // No field here
    }

    internal sealed class ProspectModelMetadata
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(5)]
        public string name { get; set; }
    }
}
