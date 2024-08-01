using BAIPetRegMobileApp.Models.PetRegistration;

namespace BAIPetRegMobileApp.Helpers
{
    public class PetRegistrationToVisibilityConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var expandedPet = value as PetRegistration;
            var currentPet = parameter as PetRegistration;

            return currentPet == expandedPet ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
