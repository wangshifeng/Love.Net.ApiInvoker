# Love.Net.ApiInvoker
This repo contains the default implementation for interfaces defined in Love.Net.Core by invoking RESTful API.

# How to use
To install Love.Net.ApiInvoker, run the following command in the Package Manager Console

`PM> Install-Package Love.Net.ApiInvoker`

# Configure services

```C#
public void ConfigureServices(IServiceCollection services) {
    services.AddMvcCore();

    services.AddApiInvoker(options => {
        options.AppPushApi = "http://localhost:5000/api/sender/push";
        options.SendEmailApi = "http://localhost:5000/api/sender/email";
        options.SendSmsApi = "http://localhost:5000/api/sender/sms";
    });
}
```