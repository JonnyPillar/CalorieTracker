using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (ActivityLogMetaData))]
    public partial class ActivityLog
    {
    }
}