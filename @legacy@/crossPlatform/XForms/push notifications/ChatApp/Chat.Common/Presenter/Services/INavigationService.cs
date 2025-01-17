﻿using Chat.Common.Presenter;

namespace Chat.Common
{
   /// <summary>
   ///    Navigation service.
   /// </summary>
   public interface INavigationService
   {
      /// <summary>
      ///    Pushs the presenter.
      /// </summary>
      /// <returns>The presenter.</returns>
      /// <param name="presenter">Presenter.</param>
      void PushPresenter(BasePresenter presenter);

      /// <summary>
      ///    Pops the presenter.
      /// </summary>
      /// <returns>The presenter.</returns>
      /// <param name="animated">Animated.</param>
      void PopPresenter(bool animated);
   }
}