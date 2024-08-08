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
                    BreedName = "Breed: Abyssinian",
                    Colors = "Colors: Ruddy, red, blue, fawn",
                    ImageSource = "abyssinian.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Curious, active, affectionate; known for its playful and energetic nature.",
                    WeightHeight = "Weight / Height: 3.5-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Aegean",
                    Colors = "Colors: White with tabby markings",
                    ImageSource = "aegean.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, active, social; known for its playful and intelligent behavior.",
                    WeightHeight = "Weight / Height: 4-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: American Curl",
                    Colors = "Colors: Variety",
                    ImageSource = "american_curll.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Affectionate, playful, people-oriented; known for its distinctive curled ears.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                 },
                new CatBreedInfo
                {
                    BreedName = "Breed: American Shorthair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "american_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Gentle, easygoing, adaptable; known for its robust health and friendly nature.",
                    WeightHeight = "Weight / Height: 3.5-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: American Wirehair",
                    Colors = "Colors: Variety",
                    ImageSource = "american_wirehair.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 18 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its unique wiry coat.",
                    WeightHeight = "Weight / Height: 3-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Arabian Mau",
                    Colors = "Colors: Variety",
                    ImageSource = "arabian_mau.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Active, friendly, independent; known for being hardy and well-adapted to hot climates.",
                    WeightHeight = "Weight / Height: 4-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Asian",
                    Colors = "Colors: Wide variety, typically solid or shaded",
                    ImageSource = "asian.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 18 years",
                    Temperament = "Temperament: Intelligent, affectionate, playful; known for its social and friendly disposition.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Asian Semi-longhair",
                    Colors = "Colors: Variety",
                    ImageSource = "asian_semi_longhair.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 18 years",
                    Temperament = "Temperament: Gentle, affectionate, playful; similar to the Asian breed but with a semi-long coat.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Australian Mist",
                    Colors = "Colors: Variety, typically spotted or marbled",
                    ImageSource = "australian_mist.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 18 years",
                    Temperament = "Temperament: Affectionate, friendly, people-oriented; known for its calm and tolerant nature.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Balinese",
                    Colors = "Colors: Seal, blue, chocolate, lilac, and more",
                    ImageSource = "balinesee.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for being vocal and social.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Bambino",
                    Colors = "Colors: Variety",
                    ImageSource = "bambino.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Playful, affectionate, social; known for its short legs and hairless body.",
                    WeightHeight = "Weight / Height: 2-4 kg, 18-23 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Bengal",
                    Colors = "Colors: Brown, seal, silver, snow with spotted or marbled patterns",
                    ImageSource = "bengal.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Active, playful, intelligent; known for its wild appearance and energetic nature.",
                    WeightHeight = "Weight / Height: 4-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Birman",
                    Colors = "Colors: Seal, blue, chocolate, lilac, and more",
                    ImageSource = "birmann.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Gentle, affectionate, social; known for its striking blue eyes and friendly demeanor.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Bombay",
                    Colors = "Colors: Black",
                    ImageSource = "bombay.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its sleek black coat and copper eyes.",
                    WeightHeight = "Weight / Height: 3-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Brazilian Shorthair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "brazilian_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 20 years",
                    Temperament = "Temperament: Playful, affectionate, social; known for being agile and friendly.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: British Longhair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "british_longhair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Affectionate, calm, independent; known for its thick, plush coat and round face.",
                    WeightHeight = "Weight / Height: 4-8 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: British Semi-longhair",
                    Colors = "Colors: Variety",
                    ImageSource = "british_semi_longhair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Gentle, affectionate, adaptable; similar to British Longhair but with a shorter coat.",
                    WeightHeight = "Weight / Height: 4-8 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: British Shorthair",
                    Colors = "Colors: Variety, including blue, black, white, red, cream, and more",
                    ImageSource = "british_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 20 years",
                    Temperament = "Temperament: Calm, affectionate, easygoing; known for its round face and dense coat.",
                    WeightHeight = "Weight / Height: 4-8 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Burmese",
                    Colors = "Colors: Sable, champagne, blue, platinum",
                    ImageSource = "burmese.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 17 years",
                    Temperament = "Temperament: Affectionate, vocal, people-oriented; known for its sleek coat and muscular build.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Burmilla",
                    Colors = "Colors: Silver, shaded, and more",
                    ImageSource = "burmilla.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, social; known for its striking appearance and friendly nature.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: California Spangled",
                    Colors = "Colors: Variety of spotted patterns, including silver, bronze, gold, blue, brown, red, black, charcoal",
                    ImageSource = "california_spangledd.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, affectionate, active; known for its wild appearance and affectionate nature.",
                    WeightHeight = "Weight / Height: 3-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Chantilly-Tiffany",
                    Colors = "Colors: Solid colors, often chocolate, blue, cinnamon, lilac, and fawn",
                    ImageSource = "chantilly_tiffany.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 16 years",
                    Temperament = "Temperament: Gentle, affectionate, vocal; known for its silky semi-longhair coat and expressive eyes.",
                    WeightHeight = "Weight / Height: 4-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Chartreux",
                    Colors = "Colors: Blue-gray",
                    ImageSource = "chartreuxx.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Quiet, affectionate, playful; known for its plush blue coat and copper eyes.",
                    WeightHeight = "Weight / Height: 3-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Chausie",
                    Colors = "Colors: Brown tabby, solid black, grizzled tabby",
                    ImageSource = "chausiee.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 14 years",
                    Temperament = "Temperament: Energetic, social, intelligent; known for its wild look and adventurous spirit.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Cheetoh",
                    Colors = "Colors: Variety of spotted or marbled patterns, including snow, blue, and silver",
                    ImageSource = "cheetoh.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, social, active; known for its large size and leopard-like spots.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Colorpoint Shorthair",
                    Colors = "Colors: Variety of point colors, including seal, blue, chocolate, lilac, red, cream, and more",
                    ImageSource = "colorpoint_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Vocal, affectionate, intelligent; known for its elegance and Siamese-like appearance.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Cornish Rex",
                    Colors = "Colors: Wide variety, including solid, bicolor, and more",
                    ImageSource = "cornish_rex.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, active, affectionate; known for its short, wavy coat and slender body.",
                    WeightHeight = "Weight / Height: 2.5-4 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Cymric or Manx Longhair",
                    Colors = "Colors: Wide variety, including solid, tabby, and more",
                    ImageSource = "cymric_or_manx_longhair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Playful, affectionate, intelligent; known for its taillessness and thick coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Cyprus",
                    Colors = "Colors: Variety, often tabby or solid",
                    ImageSource = "cyprus.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, active, independent; known for its adaptability and affectionate nature.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Devon Rex",
                    Colors = "Colors: Wide variety, including solid, bicolor, and more",
                    ImageSource = "devon_rex.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 15 years",
                    Temperament = "Temperament: Playful, affectionate, intelligent; known for its large ears, short curly coat, and mischievous personality.",
                    WeightHeight = "Weight / Height: 2.5-4 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Dragon Li",
                    Colors = "Colors: Brown mackerel tabby",
                    ImageSource = "dragon_li.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Independent, intelligent, playful; known for its agility and hunting skills.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Domestic Long Hair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "domestic_long_hair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 18 years",
                    Temperament = "Temperament: Varies greatly, often friendly and adaptable; known for its long, fluffy coat.",
                    WeightHeight = "Weight / Height: 3-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Domestic Short Hair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "domestic_short_hair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 20 years",
                    Temperament = "Temperament: Varies greatly, often friendly and independent; known for its short, easy-to-care-for coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Dwarf cat or Dwelf",
                    Colors = "Colors: Variety",
                    ImageSource = "dwarf_cat_or_dwelf.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 12 years",
                    Temperament = "Temperament: Playful, affectionate, social; known for its short stature, hairless body, and curled ears.",
                    WeightHeight = "Weight / Height: 2-3.5 kg, 15-20 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Egyptian Mau",
                    Colors = "Colors: Silver, bronze, smoke",
                    ImageSource = "egyptian_mau.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Agile, active, intelligent; known for its spotted coat and speed.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: European Shorthair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "european_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Friendly, adaptable, intelligent; known for its versatility and robust health.",
                    WeightHeight = "Weight / Height: 3.5-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Exotic Shorthair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "exotic_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, gentle, playful; known for its plush, short coat and round face.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Foldex",
                    Colors = "Colors: Variety",
                    ImageSource = "foldex.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Friendly, playful, social; known for its folded ears and round face.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: German Rex",
                    Colors = "Colors: Wide variety, including solid, bicolor, and more",
                    ImageSource = "german_rex.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, affectionate, intelligent; known for its curly coat and social nature.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Havana Brown",
                    Colors = "Colors: Rich mahogany brown",
                    ImageSource = "havana_brown.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its unique brown coat and green eyes.",
                    WeightHeight = "Weight / Height: 2.5-4.5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Highlander",
                    Colors = "Colors: Variety, often tabby or spotted",
                    ImageSource = "highlander.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Playful, social, energetic; known for its tufted ears and curled tail.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Himalayan or Colorpoint Persian",
                    Colors = "Colors: Variety of point colors, including seal, blue, chocolate, lilac, red, and cream",
                    ImageSource = "himalayan.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 15 years",
                    Temperament = "Temperament: Gentle, affectionate, calm; known for its luxurious coat and blue eyes.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Japanese Bobtail",
                    Colors = "Colors: Wide variety, often with a mix of colors",
                    ImageSource = "japanese_bobtail.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Active, intelligent, social; known for its short, pom-pom-like tail.",
                    WeightHeight = "Weight / Height: 2.5-4.5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Javanese",
                    Colors = "Colors: Variety, often with colorpoint patterns",
                    ImageSource = "javaneses.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, vocal, intelligent; known for its long, elegant body and silky coat.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Karelian Bobtail",
                    Colors = "Colors: Variety, often tabby or solid",
                    ImageSource = "karelian_bobtail.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Friendly, active, intelligent; known for its short, bobbed tail and athletic build.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Khao Manee",
                    Colors = "Colors: White",
                    ImageSource = "khao_manee.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Friendly, intelligent, social; known for its pure white coat and striking eyes, often odd-colored.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Korat",
                    Colors = "Colors: Silver-blue",
                    ImageSource = "korat.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 18 years",
                    Temperament = "Temperament: Affectionate, intelligent, playful; known for its silver-blue coat and green eyes.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Korean Bobtail",
                    Colors = "Colors: Variety, often with a mix of colors",
                    ImageSource = "korean_bobtail.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Active, intelligent, social; similar to the Japanese Bobtail, known for its short tail.",
                    WeightHeight = "Weight / Height: 2.5-4.5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Korn Ja",
                    Colors = "Colors: Black, white, blue",
                    ImageSource = "korn_ja.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Friendly, playful, social; known for its distinctive color variations.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Kurilian Bobtail or Kuril Islands Bobtail",
                    Colors = "Colors: Variety, often tabby or solid",
                    ImageSource = "kurilian_bobtail.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Friendly, active, intelligent; known for its bobbed tail and robust build.",
                    WeightHeight = "Weight / Height: 3-7 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: LaPerm",
                    Colors = "Colors: Wide variety, often with curly fur",
                    ImageSource = "lapermm.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its curly coat and outgoing personality.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Lykoi",
                    Colors = "Colors: Roan, with a mix of black and white hairs",
                    ImageSource = "lykoi.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Playful, curious, friendly; known for its unique werewolf-like appearance.",
                    WeightHeight = "Weight / Height: 2.5-4.5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Maine Coon",
                    Colors = "Colors: Wide variety, including solid, tabby, bicolor, and more",
                    ImageSource = "maine_coon.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Gentle, playful, sociable; known for its large size and tufted ears.",
                    WeightHeight = "Weight / Height: 5-9 kg, 25-40 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Manx",
                    Colors = "Colors: Wide variety, including solid, tabby, and more",
                    ImageSource = "manx.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 13 years",
                    Temperament = "Temperament: Friendly, playful, loyal; known for its taillessness or short tail.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Mekong Bobtail",
                    Colors = "Colors: Point colors, similar to Siamese",
                    ImageSource = "mekong_bobtail.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 18 years",
                    Temperament = "Temperament: Affectionate, playful, social; known for its short, kinked tail and pointed coloration.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Minskin",
                    Colors = "Colors: Variety, often with sparse fur on the body",
                    ImageSource = "minskin.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, affectionate, curious; known for its short legs and unique appearance.",
                    WeightHeight = "Weight / Height: 2-3.5 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Munchkin",
                    Colors = "Colors: Wide variety",
                    ImageSource = "munchkin.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Playful, outgoing, friendly; known for its short legs.",
                    WeightHeight = "Weight / Height: 2-4 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Norwegian Forest",
                    Colors = "Colors: Wide variety, including solid, tabby, and more",
                    ImageSource = "norwegian_forest.jpg",
                    LifeExpectancy = "Life Expectancy: 14 - 16 years",
                    Temperament = "Temperament: Independent, friendly, intelligent; known for its thick double coat and tufted ears.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-40 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Nebelung",
                    Colors = "Colors: Blue-gray",
                    ImageSource = "nebelung.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 16 years",
                    Temperament = "Temperament: Gentle, reserved, intelligent; known for its silky, medium-length blue coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Ocicat",
                    Colors = "Colors: Tawny, chocolate, cinnamon, blue, lavender, fawn, silver",
                    ImageSource = "ocicat.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Social, active, playful; known for its spotted coat and wild appearance.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Ojos Azules",
                    Colors = "Colors: Variety, with distinctive blue eyes",
                    ImageSource = "ojas_azules.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 12 years",
                    Temperament = "Temperament: Friendly, affectionate, playful; known for its striking blue eyes.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Oregon Rex",
                    Colors = "Colors: Variety, often with curly coat",
                    ImageSource = "oregons.jpg",
                    LifeExpectancy = "Life Expectancy: 9 - 12 years",
                    Temperament = "Temperament: Playful, social, curious; known for its curly coat.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Oriental Bicolor",
                    Colors = "Colors: Variety, often with contrasting colors",
                    ImageSource = "oriental_bicolor.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Social, affectionate, vocal; known for its elegant body and variety of coat patterns.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Oriental Longhair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "oriental_longhair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, social, affectionate; known for its long, slender body and silky coat.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Oriental Shorthair",
                    Colors = "Colors: Wide variety",
                    ImageSource = "oriental_shorthair.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Intelligent, vocal, social; known for its sleek, elegant body and variety of colors.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Persian (Modern Persian Cat)",
                    Colors = "Colors: Wide variety, including solid, tabby, bicolor, and more",
                    ImageSource = "persian_modern.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 17 years",
                    Temperament = "Temperament: Gentle, affectionate, quiet; known for its round face and long, luxurious coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Persian (Traditional Persian Cat)",
                    Colors = "Colors: Wide variety, including solid, tabby, bicolor, and more",
                    ImageSource = "persian_traditional.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 17 years",
                    Temperament = "Temperament: Gentle, affectionate, quiet; known for its less extreme facial features compared to the modern Persian.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Peterbald",
                    Colors = "Colors: Variety, often hairless or with a fine coat",
                    ImageSource = "peterbald.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Social, affectionate, active; known for its elegant, slim build and often hairless body.",
                    WeightHeight = "Weight / Height: 2.5-4.5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Pixie-bob",
                    Colors = "Colors: Brown spotted tabby",
                    ImageSource = "pixie_bob.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 16 years",
                    Temperament = "Temperament: Friendly, loyal, intelligent; known for its bobbed tail and wild appearance.",
                    WeightHeight = "Weight / Height: 4-7 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Raas",
                    Colors = "Colors: Blue, solid, or bicolor",
                    ImageSource = "raas.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Independent, intelligent, playful; known for its resemblance to the Russian Blue but originating from Indonesia.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Ragamuffin",
                    Colors = "Colors: Wide variety, often solid, bicolor, or tabby",
                    ImageSource = "ragamuffin.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 16 years",
                    Temperament = "Temperament: Affectionate, calm, social; known for its plush coat and friendly disposition.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Ragdoll",
                    Colors = "Colors: Pointed with a variety of colors",
                    ImageSource = "ragdoll.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Gentle, laid-back, affectionate; known for its large size and tendency to go limp when picked up.",
                    WeightHeight = "Weight / Height: 4-9 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Russian Blue",
                    Colors = "Colors: Blue-gray",
                    ImageSource = "russian_blue.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Gentle, intelligent, reserved; known for its short, dense coat and vivid green eyes.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Russian White, Black and Tabby",
                    Colors = "Colors: White, black, tabby",
                    ImageSource = "russian_white_black_tabby.jpg",
                    LifeExpectancy = "Life Expectancy: 15 - 20 years",
                    Temperament = "Temperament: Gentle, intelligent, reserved; similar in personality to the Russian Blue, with different coat colors.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Sam Sawet",
                    Colors = "Colors: Wide variety",
                    ImageSource = "sam_sawet.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Friendly, social, adaptable; known for its smooth coat and medium build.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Savannah",
                    Colors = "Colors: Spotted patterns, often golden with black spots",
                    ImageSource = "savannah.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 20 years",
                    Temperament = "Temperament: Active, social, curious; known for its tall, slender build and wild appearance.",
                    WeightHeight = "Weight / Height: 5-9 kg, 30-45 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Scottish Fold",
                    Colors = "Colors: Wide variety",
                    ImageSource = "scottish_fold.jpg",
                    LifeExpectancy = "Life Expectancy: 11 - 14 years",
                    Temperament = "Temperament: Affectionate, easy-going, intelligent; known for its distinctive folded ears.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Selkirk Rex",
                    Colors = "Colors: Wide variety",
                    ImageSource = "selkirk_rex.jpg",
                    LifeExpectancy = "Life Expectancy: 13 - 15 years",
                    Temperament = "Temperament: Affectionate, patient, playful; known for its curly coat.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Serengeti",
                    Colors = "Colors: Spotted tabby",
                    ImageSource = "serengeti.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 15 years",
                    Temperament = "Temperament: Active, social, curious; known for its tall, slender build and spotted coat.",
                    WeightHeight = "Weight / Height: 4-7 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Serrade petit",
                    Colors = "Colors: Variety",
                    ImageSource = "serrade_petit.jpg",
                    LifeExpectancy = "Life Expectancy: 10 - 14 years",
                    Temperament = "Temperament: Playful, affectionate, friendly; known for its small, compact build and expressive eyes.",
                    WeightHeight = "Weight / Height: 2.5-4 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Siamese",
                    Colors = "Colors: Pointed with a variety of colors",
                    ImageSource = "siamese.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Vocal, social, affectionate; known for its slender build and striking blue eyes.",
                    WeightHeight = "Weight / Height: 2.5-5 kg, 20-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Siberian",
                    Colors = "Colors: Wide variety, including solid, tabby, and more",
                    ImageSource = "siberian.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, intelligent; known for its thick, triple-layered coat.",
                    WeightHeight = "Weight / Height: 4-8 kg, 25-35 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Singapura",
                    Colors = "Colors: Sepia agouti",
                    ImageSource = "singapura.jpg",
                    LifeExpectancy = "Life Expectancy: 12 - 15 years",
                    Temperament = "Temperament: Affectionate, playful, social; known for its small size and large eyes.",
                    WeightHeight = "Weight / Height: 2-3 kg, 20-25 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Scottish Straight",
                    Colors = "Colors: Wide variety",
                    ImageSource = "scottish_straight.jpg",
                    LifeExpectancy = "Life Expectancy: 11 - 14 years",
                    Temperament = "Temperament: Affectionate, easy-going, intelligent; similar to the Scottish Fold but with straight ears.",
                    WeightHeight = "Weight / Height: 3-6 kg, 25-30 cm"
                },
                new CatBreedInfo
                {
                    BreedName = "Breed: Sphynx",
                    Colors = "Colors: Variety, often hairless",
                    ImageSource = "sphynx.jpg",
                    LifeExpectancy = "Life Expectancy: 8 - 14 years",
                    Temperament = "Temperament: Friendly, social, affectionate; known for its hairless body and wrinkled skin.",
                    WeightHeight = "Weight / Height: 3-5 kg, 25-30 cm"
                 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CatBreedInfo
    {
        public string? ImageSource { get; set; }
        public string? BreedName { get; set; }
        public string? LifeExpectancy { get; set; }
        public string? Temperament { get; set; }
        public string? WeightHeight { get; set; }
        public string? Colors { get; set; }
    }
}