# Blazor application with external Web API

Currently, we are serving the view and the database interaction using the same application. To make our application more robust and more decoupled we can move our database operation and all business logic into a separate application. And serve it as Web API and talk to that web api from our blazor application.

## Creating new web api with desired actions

* Create a new .net core web api application following by right click on Solution -> Add -> New Project and select ASP .Net Core Web Application.

![web api project creation](https://user-images.githubusercontent.com/24603959/79445318-47213200-7ffe-11ea-9953-d6a6458fdd54.JPG)

* Enter the project name and click on Next.
* Select API template and press Create.
![web api project creation 2](https://user-images.githubusercontent.com/24603959/79445305-44264180-7ffe-11ea-8169-ca3e6db90600.JPG)
* Create a controller inside the Controllers folder and name it as BillsController.
* Add a reference of Domain project.
* Move the dependency registration of BillService from the startup class of MonthlyBillScheduler.Server to startup class of MonthlyBillScheduler.API project.
* Do the dependency injection of BillService inside BillsController. This time we have no access to Inject attribute, and we do the constructor dependency injection.
![Controller dependency injection](https://user-images.githubusercontent.com/24603959/79446075-7be1b900-7fff-11ea-9d2c-f2b06033d5ec.JPG)

* Add actions for get, create, update and delete.
![Bill controller actions](https://user-images.githubusercontent.com/24603959/79447618-f3b0e300-8001-11ea-93c4-9e74dddef873.JPG)

* Only one thing remaining, we need to change our application port to make it static. Go to launchSettings.json (You can find it under properties) and change the applicationUrl to http://localhost:5000.

## Integrate newly created web api in blazor app

* Add new services to integrate with newly created api. We are going to create a new folder inside MonthlyBillScheduler.Server and name it Services.
* Add an interface and name it IBillDataService.

![IBillDataService](https://user-images.githubusercontent.com/24603959/79449549-3b853980-8005-11ea-873e-0e3fb0a34b57.JPG)
* Add new vairable of our api inside appsettings of MonthlyBillScheduler.Server app.
![appsettings](https://user-images.githubusercontent.com/24603959/79449960-fa415980-8005-11ea-97c4-c9ecbdb84a16.JPG)

* Register new dependency of IHttpClient in the startup class of our blazor application. We are also adding the base url of that http client from our appsettings.
![Add http client dependenc](https://user-images.githubusercontent.com/24603959/79450263-8b183500-8006-11ea-978b-324ef68e4ed8.JPG)

* Create a new class named BillDataService and implement IBillDataService.
* Do the HttpClient dependency injection using constructor injection.
* Call our desired api and deserialize it from BillDataService.
![Call api](https://user-images.githubusercontent.com/24603959/79532691-ae3ef500-8097-11ea-8d85-352149724394.JPG)

* Replace the uses of IBillService and use IBillDataService.
* Add ```StateHasChanged()``` after every action. It helps the razor view to detect the changes.
* As we are retrieving data from api, there is some latency available. We need to add a loading indicator before the data retrieving happens.
![Add Loading](https://user-images.githubusercontent.com/24603959/79532922-6f5d6f00-8098-11ea-879a-680b3d200655.JPG)

## Separate models from Domain project

Now our api talk to our domain project. But as we are using the models in blazor application, we are unable to remove the reference. We can move the models in a separate project and completely remove the reference of domain project from our blazor application.

* Create a new class library project named MonthlyBillScheduler.Entities.
* Move model folders from Domain project to newly created project.
* Change the namespace of models.
* Remove project reference of MonthlyBillScheduler.Domain from our MonthlyBillScheduler.Server project.
* Add project reference of MonthlyBillScheduler.Entites.
* Add MonthlyBillScheduler.Entities project reference in MonthlyBillScheduler.Domain project.
* Change the using namespaces, where BillItem class used.
