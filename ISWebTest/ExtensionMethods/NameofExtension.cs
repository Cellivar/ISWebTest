using System.Web.Mvc;

namespace ISWebTest.ExtensionMethods
{
    public static class NameofExtension
    {
        /// <summary>
        /// Generate a URL Action link avoiding magic strings.
        /// </summary>
        /// <remarks>
        /// The nameof C#6 operator will return the actual name of a controller rather than just the prefix.
        /// Using the regular Url.Action operation requires use of magic strings otherwise.
        /// Using this workaround (slightly modified): http://stackoverflow.com/questions/27444121/how-to-use-c-sharp-nameof-with-asp-net-mvc-url-action
        /// we can avoid either issue with just a little wonky syntax. Unfortunately we lose the compile-time
        /// constant of the nameof operator, but the speed difference in a test application is practically nothing.
        /// </remarks>
        /// <typeparam name="TController">Type of the controller to get the name of.</typeparam>
        /// <param name="urlHelper">The parameter is not used.</param>
        /// <param name="controller">The controller to generate an action from.</param>
        /// <param name="actionName">The action to generate the name from.</param>
        /// <returns></returns>
        public static string Action<TController>(this UrlHelper urlHelper, string actionName) 
            where TController : Controller
        {
            var controllerName = typeof(TController).Name;
            string namePrefix = controllerName.EndsWith("Controller") 
                ? controllerName.Substring(0, controllerName.Length - 10) 
                : controllerName;
            return urlHelper.Action(actionName, namePrefix);
        }
    }
}