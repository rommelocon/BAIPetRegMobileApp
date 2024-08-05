using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BAIPetRegMobileApp.ViewModels
{
    public class CatBreedViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CatBreedInfo> Breeds { get; set; }

        public CatBreedViewModel()
        {
            Breeds = new ObservableCollection<CatBreedInfo>
            {

                new CatBreedInfo
                {
                    BreedName = "Breed: ASPIN",
                    Colors = "Colors: Various colors including black, brown, white, tan, and gray.",
                    ImageSource = "aspin.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Loyal, adaptable, and friendly.",
                    WeightHeight = "Weight / Height: 10-20 kg, 35-50 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Affenpinscher",
                    Colors = "Colors: Black, gray, silver, and tan.",
                    ImageSource = "affenpinscher.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Confident, curious, playful.",
                    WeightHeight = "Weight / Height: 2.9-4.5 kg, 23-30 cm"
                },



            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CatBreedInfo
    {
        public string ImageSource { get; set; }
        public string BreedName { get; set; }
        public string LifeExpectancy { get; set; }
        public string Temperament { get; set; }
        public string WeightHeight { get; set; }
        public string Colors { get; set; }
    }
}
