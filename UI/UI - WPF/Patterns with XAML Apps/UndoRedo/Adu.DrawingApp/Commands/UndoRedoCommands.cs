﻿using System.Windows.Input;
using Adu.DrawingApp.Properties;

namespace Adu.DrawingApp.Commands
{
	/// <summary>
	///    Undo/Redo command definitions
	/// </summary>
	public static class UndoRedoCommands
	{
		/// <summary>
		///    Undo routed command
		/// </summary>
		public static RoutedUICommand Undo { get; } = new RoutedUICommand(Resources.UndoLabel, Resources.UndoLabel,
			typeof(UndoRedoCommands), new InputGestureCollection {new KeyGesture(Key.Z, ModifierKeys.Control, "Ctrl+Z")});

		/// <summary>
		///    Redo routed command
		/// </summary>
		public static RoutedUICommand Redo { get; } = new RoutedUICommand(Resources.RedoLabel, Resources.RedoLabel,
			typeof(UndoRedoCommands), new InputGestureCollection {new KeyGesture(Key.Y, ModifierKeys.Control, "Ctrl+Y")});
	}
}