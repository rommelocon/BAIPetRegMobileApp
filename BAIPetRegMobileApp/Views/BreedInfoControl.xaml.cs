namespace BAIPetRegMobileApp.Views;

public partial class BreedInfoControl : ContentView
{
    public static readonly BindableProperty ImageSourceProperty =
           BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnImageSourceChanged);

    public static readonly BindableProperty BreedNameProperty =
        BindableProperty.Create(nameof(BreedName), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnBreedNameChanged);

    public static readonly BindableProperty LifeExpectancyProperty =
        BindableProperty.Create(nameof(LifeExpectancy), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnLifeExpectancyChanged);

    public static readonly BindableProperty TemperamentProperty =
        BindableProperty.Create(nameof(Temperament), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnTemperamentChanged);

    public static readonly BindableProperty WeightHeightProperty =
        BindableProperty.Create(nameof(WeightHeight), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnWeightHeightChanged);

    public static readonly BindableProperty ColorsProperty =
        BindableProperty.Create(nameof(Colors), typeof(string), typeof(BreedInfoControl), default(string), propertyChanged: OnColorsChanged);

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public string BreedName
    {
        get => (string)GetValue(BreedNameProperty);
        set => SetValue(BreedNameProperty, value);
    }

    public string LifeExpectancy
    {
        get => (string)GetValue(LifeExpectancyProperty);
        set => SetValue(LifeExpectancyProperty, value);
    }

    public string Temperament
    {
        get => (string)GetValue(TemperamentProperty);
        set => SetValue(TemperamentProperty, value);
    }

    public string WeightHeight
    {
        get => (string)GetValue(WeightHeightProperty);
        set => SetValue(WeightHeightProperty, value);
    }

    public string Colors
    {
        get => (string)GetValue(ColorsProperty);
        set => SetValue(ColorsProperty, value);
    }

    public BreedInfoControl()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.ImageControl.Source = (string)newValue;
    }

    private static void OnBreedNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.BreedNameLabel.Text = (string)newValue;
    }

    private static void OnLifeExpectancyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.LifeExpectancyLabel.Text = (string)newValue;
    }

    private static void OnTemperamentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.TemperamentLabel.Text = (string)newValue;
    }

    private static void OnWeightHeightChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.WeightHeightLabel.Text = (string)newValue;
    }

    private static void OnColorsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (BreedInfoControl)bindable;
        control.ColorsLabel.Text = (string)newValue;
    }
}
