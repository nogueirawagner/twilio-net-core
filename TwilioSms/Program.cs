using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioSms
{
  class Program
  {
    static void Main(string[] args)
    {
      SendSms().Wait();
      Console.Write("Press any key to continue.");
      Console.ReadKey();
    }

    static async Task SendSms()
    {
      var accountSid = "AC568ddd31702c5f008624ed1093819380bf";
      var authToken = "087bec34a199493f9da5bfb69354a3d9dlakd";

      TwilioClient.Init(accountSid, authToken);

      var numeros = new List<string>();
      numeros.Add("+5562992350003");

      foreach(var n in numeros)
      {
        var message = await MessageResource.CreateAsync(
         to: new PhoneNumber(n),
         from: new PhoneNumber("+18339233251"),
         body: "Testando envio de sms.");

        Console.WriteLine(message.Sid);
      }
    }

  }
}
