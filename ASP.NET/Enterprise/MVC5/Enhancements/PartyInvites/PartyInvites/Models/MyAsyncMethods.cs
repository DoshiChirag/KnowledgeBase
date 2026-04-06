using System.Net.Http;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class MyAsyncMethods
    {
        public static Task<long> GetPageLength()
        {
            HttpClient Client = new HttpClient();
            var httpTask = Client.GetAsync("http://www.apress.com");
            return httpTask.ContinueWith<long>((Task<HttpResponseMessage> antecedent) =>
            {
                return antecedent.Result.Content.Headers.ContentLength.Value;
            }
                );
        }


        public async static Task<long> GetAsyncPageLength()
        {
            HttpClient Client = new HttpClient();
            var httpMessage = await Client.GetAsync("http://www.apress.com");
            return httpMessage.Content.Headers.ContentLength.Value;
        }
    }
}