using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;

namespace BasicWindowsApp.Events
{
    public class RequestNavigationEvent: PubSubEvent<string> { }
}
