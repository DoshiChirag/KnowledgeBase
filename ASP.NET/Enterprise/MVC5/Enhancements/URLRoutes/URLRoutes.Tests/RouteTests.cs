using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Web;
using  System.Web.Routing;
namespace URLRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }


       
        private void TestRouteMatch(string url, string controller,string action,object routeproperties = null,string httpMethod = "GET")
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            Assert.IsNotNull(result);

            Assert.IsTrue(TestIncomingRouteResult(result, controller,action, routeproperties));
        }


        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertyset =null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => { return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; };
            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"],action);
            if (propertyset != null)
            {
                PropertyInfo[] propInfo = propertyset.GetType().GetProperties();
                foreach(PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) &&
                            valCompare(routeResult.Values[pi.Name],
                    pi.GetValue(propertyset, null)))){
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }


        private void TestRouteFail(string url)
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(CreateHttpContext(url));
            Assert.IsTrue(result == null || result.Route == null);
        }

      
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/Admin/Index", "Admin", "Index");
            TestRouteMatch("~/One/Two", "One", "Two");

            TestRouteFail("~/Admin/Index/Segment");
            TestRouteFail("~/Admin");


        }


        [TestMethod]
        public void TestDefaultIncomingRoutes()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Custom", "Custom", "Index");
            TestRouteMatch("~/Custom/List", "Custom","List");
            //TestRouteFail("~/Custom/List/All");
            


        }


        [TestMethod]
        public void TestStaticIncomingRoutes()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Custom", "Custom", "Index");
            TestRouteMatch("~/Custom/List", "Custom", "List");
           // TestRouteFail("~/Custom/List/All");
            TestRouteMatch("~/Shop/Index", "Home","Index");



        }

        [TestMethod]
        public void TestVariableIncomingRoutes()
        {
            TestRouteMatch("~/Home/Index/DefaultId", "Home", "Index", new {id ="DefaultId" });
            TestRouteMatch("~/Custom/Index/DefaultId", "Custom", "Index", new { id = "DefaultId" });
            TestRouteMatch("~/Custom/List/DefaultId", "Custom", "List", new { id = "DefaultId" });
            TestRouteMatch("~/Custom/List/All", "Custom","List", new { id = "All" });
            //TestRouteFail("~/Custom/List/All/Delete");



        }


        [TestMethod]
        public void TestOptionalURLRouteSegments()
        {

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Custom", "Custom", "Index");
            TestRouteMatch("~/Custom/List", "Custom", "List");
            TestRouteMatch("~/Custom/List/All", "Custom", "List", new { id = "All" });
            //TestRouteFail("~/Custom/List/All/Delete");



        }


        [TestMethod]
        public void TestCatchAllSegmentVariables()
        {

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Custom", "Custom", "Index");
            TestRouteMatch("~/Custom/List", "Custom", "List");
            TestRouteMatch("~/Custom/List/All", "Custom", "List", new { id = "All" });
            TestRouteMatch("~/Custom/List/All/Delete", "Custom", "List", new { id = "All", catchall = "Delete" });
            TestRouteMatch("~/Custom/List/All/Delete/Perm", "Custom", "List", new { id = "All", catchall = "Delete/Perm" });



        }


        [TestMethod]
        public void TestRouteConstraints()
        {

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");

            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About", new { id = "MyId", catchall = "More/Segments" });

            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Account/Index");
            TestRouteFail("~/Account/About");



        }






    }
}
