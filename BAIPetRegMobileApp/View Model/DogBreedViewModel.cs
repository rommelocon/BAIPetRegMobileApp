using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BAIPetRegMobileApp.ViewModels
{
    public class DogBreedViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DogBreedInfo> Breeds { get; set; }

        public DogBreedViewModel()
        {
            Breeds = new ObservableCollection<DogBreedInfo>
            {

                new DogBreedInfo
                {
                    BreedName = "Breed: ASPIN",
                    Colors = "Colors: Various colors including black, brown, white, tan, and gray.",
                    ImageSource = "aspin.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Loyal, adaptable, and friendly.",
                    WeightHeight = "Weight / Height: 10-20 kg, 35-50 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Affenpinscher",
                    Colors = "Colors: Black, gray, silver, and tan.",
                    ImageSource = "affenpinscher.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Confident, curious, playful.",
                    WeightHeight = "Weight / Height: 2.9-4.5 kg, 23-30 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Afghan Hound",
                    Colors = "Colors: Black, gray, red, white, tan",
                    ImageSource = "afghan_hound.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Dignified, independent, intelligent; needs regular grooming.",
                    WeightHeight = "Weight / Height: 27-34 kg, 68-74 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Airedate Terrier",
                    Colors = "Colors:  Black, tan, gray, white.",
                    ImageSource = "airedale_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Spirited, intelligent, affectionate; good watchdog.",
                    WeightHeight = "Weight / Height: 5-8 kg, 30-36 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Akita Inu",
                    Colors = "Colors:  White, brindle, red, black.",
                    ImageSource = "akita_inu.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Loyal, courageous, reserved; needs firm training.",
                    WeightHeight = "Weight / Height: 32-59 kg, 61-71 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Alaskan Malamute",
                    Colors = "Colors: Balck, gray, red, sable.",
                    ImageSource = "alaskan_malamute.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Strong, friendly, independent; needs regular exercise.",
                    WeightHeight = "Weight / Height: 34 - 39 kg, 60 - 66 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: African Bulldog",
                    Colors = "Colors: Brindle, white, black, fawn.",
                    ImageSource = "african_bulldog.jpg",
                    LifeExpectancy = "Life Expectancy:  10 - 15 years",
                    Temperament = "Temperament: Protective, loyal, confident; goog with proper trainig.",
                    WeightHeight = "Weight / Height: 25 - 45 kg, 45 - 60 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: American Bully",
                    Colors = "Colors: Black, blue, brindle, fawn",
                    ImageSource = "american_bully.jpg",
                    LifeExpectancy = "Life Expectancy:  years",
                    Temperament = "Temperament: Loyal, confident, loving; needs proper socialization.",
                    WeightHeight = "Weight / Height: 30 - 60 kg, 43 - 51 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Australian Cattle",
                    Colors = "Colors: Blue, red, speckled",
                    ImageSource = "australian_cattle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Intelligent, energetic, loyal; needs lots of exercise.",
                    WeightHeight = "Weight / Height: 15 - 22 kg, 43 - 51 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Australia Dingo",
                    Colors = "Colors: Red, tan, black and tan.",
                    ImageSource = "australia_dingoo.jpg",
                    LifeExpectancy = "Life Expectancy: 10 -12 years",
                    Temperament = "Temperament: Independent, intelligent, adaptable; needs mental simulation.",
                    WeightHeight = "Weight / Height: 13 - 20 kg, 48 - 60 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Australian Kelpie",
                    Colors = "Colors: Black, red, blue, tan.",
                    ImageSource = "australian_kelpie.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Energetic, intelligent, hardworking; requires regular exercise.",
                    WeightHeight = "Weight / Height: 14 - 23 kg, 43 - 51 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Australian Shepherd",
                    Colors = "Colors: Blue, merle, red merle, black, red.",
                    ImageSource = "australian_shepherd.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, energetic, loyal; needs mental and physical stimulation.",
                    WeightHeight = "Weight / Height: 16 - 32 kg, 46 - 58 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed:Australian Silky Terrier",
                    Colors = "Colors: Blue and tan, steel blue, dark blue.",
                    ImageSource = "australian_silky_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Lively, intelligent, affectionate; needs regular grooming.",
                    WeightHeight = "Weight / Height: 2.5 - 4.5 kg, 23 - 26 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Australian Terrier",
                    Colors = "Colors: Blue and tan, red, sandy.",
                    ImageSource = "australian_terrierr.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Spirited, intelligent, alert; good with families.",
                    WeightHeight = "Weight / Height: 3.5 - 4.5 kg, 23 - 30 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Basenji",
                    Colors = "Colors: Red, brindle, black, white.",
                    ImageSource = "basenji.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Independent, intelligent, alert; known for not barking.",
                    WeightHeight = "Weight / Height: 9 - 11 kg, 40 - 43 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Basset Hound",
                    Colors = "Colors: Black and tan, lemon, red and white.",
                    ImageSource = "basset_hound.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Gentle, affectionate, stubborn; great scent hounds.",
                    WeightHeight = "Weight / Height: 20 - 29 kg, 33 - 38 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Beagle",
                    Colors = "Colors: Tri-color, lemon, red and white.",
                    ImageSource = "beagle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: friendly, curious, merry; great with children.",
                    WeightHeight = "Weight / Height: 8 - 14 kg, 33 - 41 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bearded Collie",
                    Colors = "Colors: Blue, gray, brown, fawn",
                    ImageSource = "bearded_collie.jpg",
                    LifeExpectancy = "Life Expectancy: 12 -14 years",
                    Temperament = "Temperament: Friendly, energetic, intelligent; requires grooming.",
                    WeightHeight = "Weight / Height: 25 - 34 kg, 51 - 56 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bedlington",
                    Colors = "Colors: Blue, liver, sandly.",
                    ImageSource = "bedlington.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Gentle, interlligent, affectionate; needs regular grooming.",
                    WeightHeight = "Weight / Height: 8 - 10 kg, 41 - 43 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Belgian Malinois",
                    Colors = "Colors: Fawn, black, mahogany.",
                    ImageSource = "belgian.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Intelligent, energetic, loyal; excels in various roles.",
                    WeightHeight = "Weight / Height: 25 - 30 kg, 60 - 66 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bernese Mountain",
                    Colors = "Colors: Black, white, rust",
                    ImageSource = "bernese_mountain_dog.jpg",
                    LifeExpectancy = "Life Expectancy: 7 - 10 years",
                    Temperament = "Temperament: Gentle, affectionate, calm; great family dog.",
                    WeightHeight = "Weight / Height: 36 - 54 kg, 58 - 70 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bichon Frise",
                    Colors = "Colors: White",
                    ImageSource = "bichon_frise.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Cheerful, playful, affectionate; requires regular grooming.",
                    WeightHeight = "Weight / Height: 5 - 10 kg, 23 - 30 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Biewer",
                    Colors = "Colors: Blue and white, black and white.",
                    ImageSource = "biewer.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; needs regular grooming.",
                    WeightHeight = "Weight / Height: 2.5 - 4.5 kg, 23 - 27 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bloodhound",
                    Colors = "Colors: Black and tan, liver and tan, red",
                    ImageSource = "blood_hound.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Gentle, affectionate, independent; excellent sense of smell.",
                    WeightHeight = "Weight / Height: 36 - 54 kg, 58 - 69 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Border Collie",
                    Colors = "Colors: Black and white, red and white, blue merle.",
                    ImageSource = "border_colliee.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: intelligent, energetic, hardworking; requires mental stimulation.",
                    WeightHeight = "Weight / Height: 12 - 20 kg, 46 - 56 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Borzoi",
                    Colors = "Colors: white, black, gray , tan.",
                    ImageSource = "borzoi.jpg",
                    LifeExpectancy = "Life Expectancy: 10 -12 years",
                    Temperament = "Temperament: Gentle, quiet, intelligent; known for its speed and grace.",
                    WeightHeight = "Weight / Height: 27 - 48 kg, 68 - 86 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Boston Terrier",
                    Colors = "Colors: Black and white, brindle and white.",
                    ImageSource = "boston_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 11 - 13 years",
                    Temperament = "Temperament: Friendly, intelligent, lively; great companion dog.",
                    WeightHeight = "Weight / Height: 4.5 - 11 kg, 38 - 43 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Boxer",
                    Colors = "Colors: Fawn, brindle, white.",
                    ImageSource = "boxer.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Energetic, playful, loyal; needs regular exercise.",
                    WeightHeight = "Weight / Height: 25 - 32 kg, 53 - 63 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Briad",
                    Colors = "Colors:Black , gray, tawny.",
                    ImageSource = "briard.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Loyal, intelligent, protective; needs regular grooming.",
                    WeightHeight = "Weight / Height: 34 - 45 kg, 56 - 68 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: British Bulldog",
                    Colors = "Colors: White, brindle, red",
                    ImageSource = "british_bulldog.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 12 years",
                    Temperament = "Temperament: Calm, courageous, affectionate; known for its distinctive appearance.",
                    WeightHeight = "Weight / Height: 23 - 25 kg, 31 - 36 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bull Mastiff",
                    Colors = "Colors: Fawn, brindle, apricot.",
                    ImageSource = "bull_mastiff.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 10 years",
                    Temperament = "Temperament: Calm, courageous, loyal; requires socialization.",
                    WeightHeight = "Weight / Height: 50 - 91 kg, 61 - 76 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Bull Terrier",
                    Colors = "Colors: White, black, brindle.",
                    ImageSource = "bull_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Playful, energetic, loyal; distinctive egg-shaped head.",
                    WeightHeight = "Weight / Height: 22 - 38 kg, 45 - 55 cm."
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Cairn Terrier",
                    Colors = "Colors: Red, brindle, gray, cream",
                    ImageSource = "cairn.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Confident, spirited, alert; good with children.",
                    WeightHeight = "Weight / Height: 6 - 7 kg, 28 - 31 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Cane Corso",
                    Colors = "Colors: Black, gray, fawn, red",
                    ImageSource = "cane_corso.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Loyal, protective, intelligent; requires training.",
                    WeightHeight = "Weight / Height: 40-50 kg, 60-70 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Cavalier King Charles Spaniel",
                    Colors = "Colors: Blenheim, tricolor, ruby, black and tan",
                    ImageSource = "king_charles_spaniel.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, gentle, friendly; great companion dog.",
                    WeightHeight = "Weight / Height: 5-8 kg, 30-33 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Chihuahua",
                    Colors = "Colors: Any color; single or multi-colored",
                    ImageSource = "chihuahua.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 20 years",
                    Temperament = "Temperament: Lively, confident, alert; great for apartment living",
                    WeightHeight = "Weight / Height: 1.5-3 kg, 15-23 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Chinese Crested Dog",
                    Colors = "Colors: Any color; hairless or powderpuff",
                    ImageSource = "chinese_crested_dog.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 18 years",
                    Temperament = "Temperament: Affectionate, alert, playful; known for its unique appearance.",
                    WeightHeight = "Weight / Height: 2-5 kg, 23-33 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Chow Chow",
                    Colors = "Colors: Red, black, blue, cream, cinnamon",
                    ImageSource = "chow_chow.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 12 years",
                    Temperament = "Temperament: Aloof, independent, loyal; known for its lion-like mane.",
                    WeightHeight = "Weight / Height: 25-38 kg, 46-56 cm"
                },
                new DogBreedInfo
                {
                    BreedName = "Breed: Cotton De Tulear",
                    Colors = "Colors: White, white with black or gray markings",
                    ImageSource = "cotton_de_tulear.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 16 years",
                    Temperament = "Temperament: Playful, affectionate, intelligent; enjoys attention.",
                    WeightHeight = "Weight / Height: 3.5-6 kg, 23-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Cocker Spaniel",
                    Colors = "Colors: Black, red, chocolate, tan",
                    ImageSource = "cocker_spaniels.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Gentle, affectionate, friendly; good with families.",
                    WeightHeight = "Weight / Height: 11-14 kg, 35-38 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Curly Coated Retriever",
                    Colors = "Colors: Black, liver",
                    ImageSource = "curly_coated_retriever.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Intelligent, independent, energetic; excellent retriever.",
                    WeightHeight = "Weight / Height: 25-34 kg, 66-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Dachshund",
                    Colors = "Colors: Red, black and tan, chocolate",
                    ImageSource = "dachshund.jpg",
                    LifeExpectancy = "Life Expectancy: 12 -16 years",
                    Temperament = "Temperament: Curious, lively, brave; good for small spaces.",
                    WeightHeight = "Weight / Height: 4-14 kg, 20-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Dalmatian",
                    Colors = "Colors: White with black or liver spots",
                    ImageSource = "dalmatian.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 13 years",
                    Temperament = "Temperament: Outgoing, energetic, intelligent; known for its spots.",
                    WeightHeight = "Weight / Height: 24-32 kg, 48-61 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Deerhound",
                    Colors = "Colors: Gray, blue, brindle",
                    ImageSource = "deerhound.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 11 years",
                    Temperament = "Temperament: Gentle, friendly, reserved; known for its hunting skills.",
                    WeightHeight = "Weight / Height: 34-50 kg, 71-81 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Doberman Pinscher",
                    Colors = "Colors: Black and tan, blue and tan, red and tan, fawn and tan",
                    ImageSource = "doberman_pinscher.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 13 years",
                    Temperament = "Temperament: Loyal, intelligent, alert; known for its guarding abilities.",
                    WeightHeight = "Weight / Height: 27-45 kg, 61-71 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Dogue de Bordeaux",
                    Colors = "Colors: Red, fawn",
                    ImageSource = "dogue_de_bordeaux.jpg",
                    LifeExpectancy = "Life Expectancy: 5 - 8 years",
                    Temperament = "Temperament: Calm, loyal, courageous; known for its muscular build.",
                    WeightHeight = "Weight / Height: 45-65 kg, 60-68 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Dutch Shepherd",
                    Colors = "Colors: Brindle, gold, silver",
                    ImageSource = "dutch_shepherd.jpg",
                    LifeExpectancy = "Life Expectancy: 11 -15 years",
                    Temperament = "Temperament: Intelligent, active, versatile; excels in various canine sports.",
                    WeightHeight = "Weight / Height: 23-32 kg, 55-65 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: English Bulldog",
                    Colors = "Colors: White, brindle, red, fawn",
                    ImageSource = "english_bulldog.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 12 years",
                    Temperament = "Temperament: Gentle, courageous, friendly; known for its wrinkled face.",
                    WeightHeight = "Weight / Height: 23-25 kg, 31-36 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: English Setter",
                    Colors = "Colors: White with colored patches (e.g., orange, liver)",
                    ImageSource = "english_setterr.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Gentle, friendly, energetic; great for fieldwork.",
                    WeightHeight = "Weight / Height: 20-36 kg, 61-71 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: English Springer Spaniel",
                    Colors = "Colors: Liver and white, black and white",
                    ImageSource = "english_springer_spaniell.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Friendly, energetic, intelligent; excels in hunting and agility.",
                    WeightHeight = "Weight / Height: 18-25 kg, 46-51 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Exotic Bully",
                    Colors = "Colors: Various colors and patterns",
                    ImageSource = "exotic_bully.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 13 years",
                    Temperament = "Temperament: Confident, muscular, loyal; known for its unique appearance.",
                    WeightHeight = "Weight / Height: Varies by individual"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Field Spaniel",
                    Colors = "Colors: Black, liver, red",
                    ImageSource = "field_spaniell.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Gentle, loyal, energetic; good for fieldwork and agility.",
                    WeightHeight = "Weight / Height: 18-27 kg, 46-51 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Finnish Spitz",
                    Colors = "Colors:  Red, golden",
                    ImageSource = "finnish_spitzz.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Alert, lively, friendly; known for its fox-like appearance.",
                    WeightHeight = "Weight / Height: 8-13 kg, 33-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Foxhound",
                    Colors = "Colors: Tri-color, bi-color",
                    ImageSource = "foxhound.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 13 years",
                    Temperament = "Temperament: Friendly, outgoing, energetic; excellent hunting dog.",
                    WeightHeight = "Weight / Height: 29-34 kg, 53-64 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Fox Terrier",
                    Colors = "Colors: White with black or tan",
                    ImageSource = "fox_terrierr.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Energetic, alert, friendly; known for its hunting skills.",
                    WeightHeight = "Weight / Height: 6-9 kg, 33-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: French Bulldog",
                    Colors = "Colors: Brindle, fawn, white, black, or combinations",
                    ImageSource = "french_bulldog.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Affectionate, playful, adaptable; known for its distinctive bat-like ears.",
                    WeightHeight = "Weight / Height: 8-14 kg, 28-33 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: German Pinscher",
                    Colors = "Colors: Black and tan, blue and tan",
                    ImageSource = "german_pinscher.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Energetic, alert, intelligent; known for its sleek appearance.",
                    WeightHeight = "Weight / Height: 4.5-6.8 kg, 30-35 cm\""
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: German Pointer",
                    Colors = "Colors: Liver, orange, black",
                    ImageSource = "germanpointer.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Intelligent, versatile, friendly; excellent hunting dog.",
                    WeightHeight = "Weight / Height: 20-30 kg, 50-65 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: German Shepherd",
                    Colors = "Colors: Black and tan, sable",
                    ImageSource = "german_shepherd.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 13 years",
                    Temperament = "Temperament: Confident, courageous, intelligent; great working dog.",
                    WeightHeight = "Weight / Height: 22-40 kg, 55-65 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Golden Retriever",
                    Colors = "Colors: Golden shades",
                    ImageSource = "golden_retriever.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Friendly, intelligent, devoted; popular family pet.",
                    WeightHeight = "Weight / Height: 25-34 kg, 55-61 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Gordon Setter",
                    Colors = "Colors: Black and tan",
                    ImageSource = "gordon_setterr.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Affectionate, loyal, intelligent; known for its striking appearance.",
                    WeightHeight = "Weight / Height: 25-36 kg, 61-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Great Dane",
                    Colors = "Colors: Various, including black, blue, fawn",
                    ImageSource = "great_dane.jpg",
                    LifeExpectancy = "Life Expectancy: 7 - 10 years",
                    Temperament = "Temperament: Gentle, affectionate, courageous; known for its imposing size.",
                    WeightHeight = "Weight / Height: 45-90 kg, 71-86 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Greyhound",
                    Colors = "Colors: Various, including black, white, brindle",
                    ImageSource = "greyhound.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Gentle, friendly, alert; known for its speed and slender build.",
                    WeightHeight = "Weight / Height: 27-40 kg, 68-76 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Havanese Dog",
                    Colors = "Colors: Various, including white, black, brown",
                    ImageSource = "havanese.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 16 years",
                    Temperament = "Temperament: Various, including white, black, brown",
                    WeightHeight = "Weight / Height: 4.5-7.5 kg, 23-27 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Hungarian Vizsla",
                    Colors = "Colors: Golden rust",
                    ImageSource = "hungarian_vizsla.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Energetic, intelligent, affectionate; known for its versatility.",
                    WeightHeight = "Weight / Height: 20-30 kg, 54-64 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Irish Red and White Setter",
                    Colors = "Colors: Red and white",
                    ImageSource = "irish_white_and_red.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Energetic, friendly, intelligent; known for its beautiful red and white coat.",
                    WeightHeight = "Weight / Height: 22-30 kg, 56-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Irish Setter",
                    Colors = "Colors: Mahogany, red",
                    ImageSource = "irishsetter.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Energetic, friendly, intelligent; known for its distinctive mahogany coat.",
                    WeightHeight = "Weight / Height: 25-32 kg, 60-70 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Irish Wolfhound",
                    Colors = "Colors: Various, including gray, brindle, black",
                    ImageSource = "irish_wolfhound.jpg",
                    LifeExpectancy = "Life Expectancy: 6 - 8 years",
                    Temperament = "Temperament: Gentle, friendly, courageous; known for its impressive size and calm demeanor.",
                    WeightHeight = "Weight / Height: 40-69 kg, 71-91 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Italian Greyhound",
                    Colors = "Colors: Various, including gray, fawn, blue",
                    ImageSource = "italian_greyhound.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 15 years",
                    Temperament = "Temperament: Affectionate, lively, gentle; known for its graceful appearance and small size.",
                    WeightHeight = "Weight / Height: 3-5 kg, 32-38 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Italian Mastiff",
                    Colors = "Colors: Brindle, fawn, black",
                    ImageSource = "italianmastiff.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 11 years",
                    Temperament = "Temperament:  Loyal, protective, affectionate; known for its impressive strength and size.",
                    WeightHeight = "Weight / Height: 40-60 kg, 60-75 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Jack Russell",
                    Colors = "Colors: White with black or brown markings",
                    ImageSource = "jack_russell.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 16 years",
                    Temperament = "Temperament: Energetic, intelligent, bold; known for its high energy and hunting skills.",
                    WeightHeight = "Weight / Height: 5-8 kg, 25-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Japanese Chin",
                    Colors = "Colors: White with black, red, or sable markings",
                    ImageSource = "japanese_chin.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Affectionate, playful, alert; known for its elegant appearance and charming personality.",
                    WeightHeight = "Weight / Height: 1.8-3 kg, 20-27 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Japanese Spitz",
                    Colors = "Colors: White",
                    ImageSource = "japanese_spitz.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Playful, intelligent, alert; known for its fluffy white coat and friendly nature.",
                    WeightHeight = "Weight / Height: 4-10 kg, 30-38 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Keeshond",
                    Colors = "Colors: Gray with black markings",
                    ImageSource = "keeshond.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, alert, intelligent; known for its distinctive ‘spectacles’ and fox-like expression.",
                    WeightHeight = "Weight / Height: 16-17 kg, 43-46 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Kerry Blue",
                    Colors = "Colors: Blue",
                    ImageSource = "kerry_blue.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, lively, loyal; known for its distinctive curly blue-gray coat.",
                    WeightHeight = "Weight / Height: 14-18 kg, 45-51 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Labrador Retriever",
                    Colors = "Colors: Black, yellow, chocolate",
                    ImageSource = "labradorretriever.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Friendly, outgoing, intelligent; known for its great loyalty and trainability.",
                    WeightHeight = "Weight / Height: 25-36 kg, 55-62 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Lhasa Apso",
                    Colors = "Colors: Various, including gold, white, black",
                    ImageSource = "lhasa_apso.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, alert, intelligent; known for its long, flowing coat.",
                    WeightHeight = "Weight / Height: 5-8 kg, 25-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Lowchen",
                    Colors = "Colors: Various, including gold, white, black",
                    ImageSource = "lowchen.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Cheerful, alert, affectionate; known for its distinctive lion-like appearance. ",
                    WeightHeight = "Weight / Height: 4-8 kg, 25-33 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Maltese",
                    Colors = "Colors: White",
                    ImageSource = "maltese.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Gentle, affectionate, playful; known for its long, white coat. ",
                    WeightHeight = "Weight / Height: 1.8-3.6 kg, 20-25 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Mexican Hairless Terrier",
                    Colors = "Colors: Various, including black, gray, brown",
                    ImageSource = "mexicanhairlessdog.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Lively, intelligent, affectionate; known for its hairless coat and adaptability.",
                    WeightHeight = "Weight / Height: 4-7 kg, 25-35 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Miniature Pinscher",
                    Colors = "Colors: Black and tan, red",
                    ImageSource = "miniature_pinscher.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Energetic, alert, confident; known for its small size and lively personality.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 25-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Miniature Poodle",
                    Colors = "Colors: Various, including black, white, apricot",
                    ImageSource = "miniature_poodle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, active, alert; known for its hypoallergenic coat and versatility.",
                    WeightHeight = "Weight / Height: 5-8 kg, 28-38 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Newfoundland",
                    Colors = "Colors: Black, brown, Landseer",
                    ImageSource = "newfoundland.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 10 years",
                    Temperament = "Temperament: Gentle, patient, protective; known for its large size and swimming ability.",
                    WeightHeight = "Weight / Height: 45-68 kg, 66-71 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Norwich Terrier",
                    Colors = "Colors: Red, black and tan, grizzle and tan",
                    ImageSource = "norwich_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, alert, friendly; known for its small size and energetic nature.",
                    WeightHeight = "Weight / Height: 4-5 kg, 25-26 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Old English Sheepdog",
                    Colors = "Colors: Gray, blue, and white",
                    ImageSource = "oldenglishsheepdog.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Gentle, friendly, intelligent; known for its shaggy coat and friendly demeanor.",
                    WeightHeight = "Weight / Height: 27-45 kg, 56-61 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Papillon",
                    Colors = "Colors: Various, including white, sable, black, tan",
                    ImageSource = "papillon.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Intelligent, lively, affectionate; known for its distinctive butterfly-like ears.",
                    WeightHeight = "Weight / Height: 1.8-5 kg, 20-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pekingese",
                    Colors = "Colors: Various, including red, black, white",
                    ImageSource = "pekingese.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Loyal, affectionate, independent; known for its distinctive pushed-in face and long coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 15-23 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pharaoh Hound",
                    Colors = "Colors: Tan, with or without white markings",
                    ImageSource = "pharaohhound.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Affectionate, alert, playful; known for its elegant appearance and agility.",
                    WeightHeight = "Weight / Height: 18-27 kg, 53-63 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pointer",
                    Colors = "Colors: Various, including liver, black, and white",
                    ImageSource = "pointers.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Energetic, intelligent, friendly; known for its hunting skills and enthusiasm.",
                    WeightHeight = "Weight / Height: 20-34 kg, 56-69 cm "
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pomeranian",
                    Colors = "Colors: Various, including orange, black, cream",
                    ImageSource = "pomeranian.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Lively, intelligent, extroverted; known for its fluffy coat and playful personality.",
                    WeightHeight = "Weight / Height: Height: 1.8-3.5 kg, 18-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Portuguese Water Dog",
                    Colors = "Colors: Black, white, brown, or a combination",
                    ImageSource = "portuguese_water_dog.jpg",
                    LifeExpectancy = "Life Expectancy: 11 - 13 years",
                    Temperament = "Temperament: Energetic, intelligent, loyal; known for its curly coat and strong swimming abilities.",
                    WeightHeight = "Weight / Height: 16-27 kg, 43-58 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pug",
                    Colors = "Colors: Fawn, black, silver",
                    ImageSource = "pug.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its distinctive wrinkled face and curled tail.",
                    WeightHeight = "Weight / Height: 6-9 kg, 25-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Puli",
                    Colors = "Colors: Black, white, gray, fako",
                    ImageSource = "puli.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Energetic, intelligent, loyal; known for its unique corded coat and herding abilities.",
                    WeightHeight = "Weight / Height: 11-16 kg, 37-47 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Pyrenean Mountain Dog",
                    Colors = "Colors: White, with possible gray or tan markings",
                    ImageSource = "pyrenean_mountain.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Gentle, loyal, protective; known for its large size and thick, white coat.",
                    WeightHeight = "Weight / Height: 36-54 kg, 65-81 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Rhodesian Ridgeback",
                    Colors = "Colors: Wheaten, with or without black mask",
                    ImageSource = "rhodesian_ridgeback.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Affectionate, intelligent, independent; known for its distinctive ridge of hair along its back.",
                    WeightHeight = "Weight / Height: 30-41 kg, 60-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Rottweiler",
                    Colors = "Colors: Black with tan markings",
                    ImageSource = "rottweiler.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 10 years ",
                    Temperament = "Temperament: Confident, fearless, loyal; known for its strength and guarding abilities.",
                    WeightHeight = "Weight / Height: 35-60 kg, 56-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Rough Collie",
                    Colors = "Colors: Sable, merle, tri-color, blue merle",
                    ImageSource = "roughcollie.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Gentle, loyal, intelligent; known for its distinctive long, flowing coat and friendly demeanor.",
                    WeightHeight = "Weight / Height: 18-34 kg, 56-66 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Saluki",
                    Colors = "Colors: Various, including white, black, tan",
                    ImageSource = "salukiii.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years ",
                    Temperament = "Temperament: Gentle, intelligent, reserved; known for its grace and speed.",
                    WeightHeight = "Weight / Height: 18-27 kg, 58-71 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Samoyed",
                    Colors = "Colors: White, cream",
                    ImageSource = "samoyed.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Friendly, gentle, playful; known for its white, fluffy coat and smiling expression.",
                    WeightHeight = "Weight / Height: 23-30 kg, 48-60 cm"

                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Schnauzer",
                    Colors = "Colors: Black, salt and pepper, white",
                    ImageSource = "schnauzer.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Alert, intelligent, energetic; known for its distinctive beard and eyebrows.",
                    WeightHeight = "Weight / Height: 5-30 kg, 30-70 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Schipperke",
                    Colors = "Colors: Black, sometimes with a small white patch",
                    ImageSource = "schipperke.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 15 years",
                    Temperament = "Temperament: Lively, alert, curious; known for its fox-like appearance and keen watchdog abilities.",
                    WeightHeight = "Weight / Height: 3-9 kg, 25-33 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Scottish Terrier",
                    Colors = "Colors: Black, brindle, wheaten",
                    ImageSource = "cottish_terrierr.jpg",
                    LifeExpectancy = "Life Expectancy: 11 - 13 years",
                    Temperament = "Temperament: Confident, dignified, alert; known for its distinctive silhouette and strong personality.",
                    WeightHeight = "Weight / Height: 8-10 kg, 25-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Shar Pei",
                    Colors = "Colors: Various, including red, black, fawn",
                    ImageSource = "sharpeii.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 12 years",
                    Temperament = "Temperament: Loyal, calm, independent; known for its distinctive wrinkled skin and blue-black tongue.",
                    WeightHeight = "Weight / Height: 16-30 kg, 44-51 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Shetland Sheepdog",
                    Colors = "Colors: Sable, merle, tri-color",
                    ImageSource = "shetland_sheepdog.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Intelligent, energetic, affectionate; known for its herding skills and beautiful coat.",
                    WeightHeight = "Weight / Height: 6-12 kg, 35-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Shiba Inu",
                    Colors = "Colors: Red, sesame, black and tan, cream",
                    ImageSource = "shiba_inu.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Confident, spirited, loyal; known for its fox-like appearance and independence.",
                    WeightHeight = "Weight / Height: 8-10 kg, 35-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Shih Tzu",
                    Colors = "Colors: Various, including white, black, gold",
                    ImageSource = "shih_tzu.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 16 years",
                    Temperament = "Temperament: Affectionate, friendly, outgoing; known for its long, flowing coat and sweet demeanor.",
                    WeightHeight = "Weight / Height: 4-7 kg, 20-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Shih Tzu Poodle",
                    Colors = "Colors: Various, including white, black, brown",
                    ImageSource = "shih_tzu_poodle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Intelligent, friendly, adaptable; combines traits of Shih Tzu and Poodle breeds.",
                    WeightHeight = "Weight / Height: 4-7 kg, 20-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Siberian Husky",
                    Colors = "Colors: Various, including black, gray, red, agouti",
                    ImageSource = "siberian_husky.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, energetic, outgoing; known for its striking appearance and endurance.",
                    WeightHeight = "Weight / Height: 16-27 kg, 50-60 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Smooth Collie",
                    Colors = "Colors: Sable, tri-color, blue merle",
                    ImageSource = "smooth_collie.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Intelligent, gentle, loyal; known for its short coat and versatility. ",
                    WeightHeight = "Weight / Height: 20-30 kg, 51-66 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: St. Bernard",
                    Colors = "Colors: Red and white, brindle",
                    ImageSource = "saint_bernand.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 10 years",
                    Temperament = "Temperament: Gentle, friendly, patient; known for its large size and rescue work.",
                    WeightHeight = "Weight / Height: 54-82 kg, 65-80 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Staffordshire Bull Terrier",
                    Colors = "Colors: Various, including black, blue, brindle",
                    ImageSource = "staffordshire_bull_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Confident, courageous, loyal; known for its strength and affectionate nature.",
                    WeightHeight = "Weight / Height: 11-17 kg, 36-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Standard Poodle",
                    Colors = "Colors: Various, including white, black, apricot",
                    ImageSource = "standard_poodle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, active, alert; known for its hypoallergenic coat and versatility in dog sports.",
                    WeightHeight = "Weight / Height: 20-32 kg, 38-61 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Tibetan Terrier",
                    Colors = "Colors: Various, including white, black, gray",
                    ImageSource = "tibetan_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, intelligent, outgoing; known for its long coat and affectionate nature.",
                    WeightHeight = "Weight / Height: 8-14 kg, 36-41 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Tibetan Spaniel",
                    Colors = "Colors: Various, including gold, cream, black",
                    ImageSource = "tibetan_spaniel.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Alert, affectionate, playful; known for its cheerful personality and small size.",
                    WeightHeight = "Weight / Height: 4-7 kg, 25-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Toy Poodle",
                    Colors = "Colors: Various, including black, white, apricot",
                    ImageSource = "toy_poodle.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, lively, affectionate; known for its small size and hypoallergenic coat.",
                    WeightHeight = "Weight / Height: 2-4 kg, 24-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Weimaraner",
                    Colors = "Colors: Gray, silver-gray",
                    ImageSource = "weimaraner.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Friendly, intelligent, energetic; known for its silver-gray coat and hunting abilities.",
                    WeightHeight = "Weight / Height: 25-40 kg, 61-69 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Welsh Corgi",
                    Colors = "Colors: Various, including red, sable, tri-color",
                    ImageSource = "welsh_corgi.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, affectionate, lively; known for its herding instinct and short legs.",
                    WeightHeight = "Weight / Height: 9-13 kg, 25-30 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: West Highland White Terrier",
                    Colors = "Colors: White",
                    ImageSource = "west_highland_white_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Friendly, confident, playful; known for its distinctive white coat and spunky attitude.",
                    WeightHeight = "Weight / Height: 6-8 kg, 25-28 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Whippet",
                    Colors = "Colors: Various, including brindle, black, white",
                    ImageSource = "whippett.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Gentle, intelligent, friendly; known for its speed and elegant build.",
                    WeightHeight = "Weight / Height: 6-12 kg, 43-51 cm"
                },
                    new DogBreedInfo
                {
                    BreedName = "Breed: Yorkshire Terrier",
                    Colors = "Colors: Blue and tan",
                    ImageSource = "yorkshire_terrier.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Spirited, affectionate, confident; known for its long, silky coat and lively personality.",
                    WeightHeight = "Weight / Height: 2-4 kg, 20-23 cm"
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DogBreedInfo
    {
        public string ImageSource { get; set; }
        public string BreedName { get; set; }
        public string LifeExpectancy { get; set; }
        public string Temperament { get; set; }
        public string WeightHeight { get; set; }
        public string Colors { get; set; }
    }
}
