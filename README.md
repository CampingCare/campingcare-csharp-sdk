![CampingCare](https://storage.googleapis.com/campingcare-static/images/logo-web-small.png) 
# Camping Care C# SDK #

Connect to the Camping.care system to get data. This could be park, accommodation, prices, availability, reservations, invoicing and contact data.
Also you can create reservations, and contact.

## Requirements ##
To use the Camping.care C# SDK, the following things are required:

+ Get yourself a free [Camping.care Account](https://camping.care/). No sign up costs.
+ Create a Camping.care [API key](https://camping.care/settings/api)
+ Now you're ready to use the Camping.care PHP API client in test mode.
+ C# .NET >= 4.5
+ Newtonsoft JSON Nuget Package

## Installation ##

You can checkout or [download all the files](https://github.com/CampingCare/campingcare-csharp-sdk/archive/master.zip), and include the Camping.care C# campingcare-csharp-sdk.dll manually to your (Visual Studio) References.

## Getting started ##

Requiring the included autoloader. If you're using Composer, you can skip this step.

```php
using campingcare;
```

Initializing the Camping.care C# SDK, and setting your API key.

```php
 campingcare_api camping_care = new campingcare_api();
 camping_care.set_api_key("YOUR API Key");
``` 

Getting park information.

```php
$park = $campingcare->get_park();
```

## API documentation ##
If you wish to learn more about our API, please visit the [Camping.care Developer Portal](https://www.camping.care/developer/). API Documentation is available in English.

## License ##
[BSD (Berkeley Software Distribution) License](https://opensource.org/licenses/bsd-license.php).
Copyright (c) 2013-2017, Boekanders B.V.

## Support ##
Contact: [camping.care](https://camping.care) — support@camping.care — + 31 85 065 3614


