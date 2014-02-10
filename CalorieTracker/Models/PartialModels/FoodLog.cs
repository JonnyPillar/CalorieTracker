using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (FoodLogMetaData))]
    public partial class FoodLog
    {
    }
}