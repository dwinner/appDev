using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControls
{
	#region Templated parts

	[TemplatePart(Name = "PART_RedSlider", Type = typeof(RangeBase))]
	[TemplatePart(Name = "PART_BlueSlider", Type = typeof(RangeBase))]
	[TemplatePart(Name = "PART_GreenSlider", Type = typeof(RangeBase))]
	[TemplatePart(Name = "PART_PreviewBrush", Type = typeof(SolidColorBrush))]

	#endregion

	public class ColorPicker : Control
	{
		#region Custom routed events

		public static readonly RoutedEvent ColorChangedEvent =
			EventManager.RegisterRoutedEvent(nameof(ColorChanged), RoutingStrategy.Bubble,
				typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

		#endregion

		private Color? _previousColor;

		private void SetUpCommands()
		{
			// Set up command bindings.
			var binding = new CommandBinding(ApplicationCommands.Undo,
				OnUndoCommandExecuted, OnUndoCommandCanExecute);
			CommandBindings.Add(binding);
		}

		private void OnUndoCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
			=> e.CanExecute = _previousColor.HasValue;

		private void OnUndoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			Debug.Assert(_previousColor != null, "previousColor != null");
			Color = (Color) _previousColor;
		}

		private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var colorPicker = (ColorPicker) sender;

			var oldColor = (Color) e.OldValue;
			var newColor = (Color) e.NewValue;
			colorPicker.Red = newColor.R;
			colorPicker.Green = newColor.G;
			colorPicker.Blue = newColor.B;

			colorPicker._previousColor = oldColor;
			colorPicker.OnColorChanged(oldColor, newColor);
		}

		private static void OnColorRgbChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var colorPicker = (ColorPicker) sender;
			var color = colorPicker.Color;
			if (e.Property == RedProperty)
				color.R = (byte) e.NewValue;
			else if (e.Property == GreenProperty)
				color.G = (byte) e.NewValue;
			else if (e.Property == BlueProperty)
				color.B = (byte) e.NewValue;

			colorPicker.Color = color;
		}

		public event RoutedPropertyChangedEventHandler<Color> ColorChanged
		{
			add { AddHandler(ColorChangedEvent, value); }
			remove { RemoveHandler(ColorChangedEvent, value); }
		}

		private void OnColorChanged(Color oldValue, Color newValue)
		{
			var args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue) {RoutedEvent = ColorChangedEvent};
			RaiseEvent(args);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			// Setting up templated parts
			var slider = GetTemplateChild("PART_RedSlider") as RangeBase;
			slider?.SetBinding(RangeBase.ValueProperty, new Binding("Red") {Source = this, Mode = BindingMode.TwoWay});

			slider = GetTemplateChild("PART_GreenSlider") as RangeBase;
			slider?.SetBinding(RangeBase.ValueProperty, new Binding("Green") {Source = this, Mode = BindingMode.TwoWay});

			slider = GetTemplateChild("PART_BlueSlider") as RangeBase;
			slider?.SetBinding(RangeBase.ValueProperty, new Binding("Blue") {Source = this, Mode = BindingMode.TwoWay});

			var brush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;
			if (brush != null)
				SetBinding(ColorProperty, new Binding(nameof(Color)) {Source = brush, Mode = BindingMode.OneWayToSource});
		}

		#region Dependency properties

		public static readonly DependencyProperty ColorProperty;
		public static readonly DependencyProperty RedProperty;
		public static readonly DependencyProperty GreenProperty;
		public static readonly DependencyProperty BlueProperty;

		#endregion

		#region Setting up dependency properties

		static ColorPicker()
		{
			// This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
			// This style is defined in themes\generic.xaml
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker),
				new FrameworkPropertyMetadata(typeof(ColorPicker)));

			ColorProperty = DependencyProperty.Register("Color", typeof(Color),
				typeof(ColorPicker),
				new FrameworkPropertyMetadata(OnColorChanged));

			RedProperty = DependencyProperty.Register("Red", typeof(byte),
				typeof(ColorPicker),
				new FrameworkPropertyMetadata(OnColorRgbChanged));

			GreenProperty = DependencyProperty.Register("Green", typeof(byte),
				typeof(ColorPicker),
				new FrameworkPropertyMetadata(OnColorRgbChanged));

			BlueProperty = DependencyProperty.Register("Blue", typeof(byte),
				typeof(ColorPicker),
				new FrameworkPropertyMetadata(OnColorRgbChanged));
		}

		public ColorPicker()
		{
			//InitializeComponent();
			SetUpCommands();
		}

		#endregion

		#region Properties

		public Color Color
		{
			get { return (Color) GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public byte Red
		{
			get { return (byte) GetValue(RedProperty); }
			set { SetValue(RedProperty, value); }
		}

		public byte Green
		{
			get { return (byte) GetValue(GreenProperty); }
			set { SetValue(GreenProperty, value); }
		}

		public byte Blue
		{
			get { return (byte) GetValue(BlueProperty); }
			set { SetValue(BlueProperty, value); }
		}

		#endregion
	}
}