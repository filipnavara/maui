using System;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;
using WPanel = Microsoft.UI.Xaml.Controls.Panel;
using WWindow = Microsoft.UI.Xaml.Window;

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public class WindowHandlerStub : WindowHandler
	{
		public WindowHandlerStub()
			: base()
		{
		}

		protected override void ConnectHandler(UI.Xaml.Window platformView)
		{
			if (platformView.Content is null)
				platformView.Content = new TestWindowRootViewContainer(platformView);
			base.ConnectHandler(platformView);
		}

		class TestWindowRootViewContainer : WindowRootViewContainer, AssertionExtensions.IWindowProvider
		{
			public TestWindowRootViewContainer(Window window)
			{
				Window = window;
			}

			public Window Window { get; private set; }
		}
	}
}
