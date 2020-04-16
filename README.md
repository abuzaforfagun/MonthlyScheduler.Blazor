# Blazor application with external Web API

Currently we are serving the view and the database interaction using a same application. To make our application more robous and more decoupled we can move our database operation and all business logic into a separate application. And serve it as Web API and talk to that web api from our blazor application.

## Creating new web api with desired actions

* Create a new .net core web api application following by right click on Solution -> Add -> New Project and select ASP .Net Core Web Application.

![web api project creation](https://user-images.githubusercontent.com/24603959/79445318-47213200-7ffe-11ea-9953-d6a6458fdd54.JPG)

* Enter the project name and click on Next.
* Select API template and press Create.
![web api project creation 2](https://user-images.githubusercontent.com/24603959/79445305-44264180-7ffe-11ea-8169-ca3e6db90600.JPG)
* Create a controller inside Controllers folder and name it as BillsController.
* Add a reference of Domain project.
* Move the dependency registration of BillService from the startp class of MonthlyBillScheduler.Server to startup class of MonthlyBillScheduler.API project.
* Do the dependency injection of BillService inside BillsController. This time we have no access of Inject attribute, and we do the constractor dependency injection.
![Controller dependency injection](https://user-images.githubusercontent.com/24603959/79446075-7be1b900-7fff-11ea-9d2c-f2b06033d5ec.JPG)

* Add actions for get, create, update and delete.
![Bill controller actions](https://user-images.githubusercontent.com/24603959/79447618-f3b0e300-8001-11ea-93c4-9e74dddef873.JPG)

* Only one thing remaining, we need to change our application port to make it static. Go to launchSettings.json (You can find it under properties) and change the applicationUrl to http://localhost:5000.
