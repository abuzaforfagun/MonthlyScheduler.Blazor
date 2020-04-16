# Using Dialog

Currently, we communicating between pages. We used one page to edit and add a new bill. We can improve user experiences by adding dialog in our application. In edit form, we got the user id and any user can directly navigate to a specific bill edit using the URL. So we are going to keep edit procedure but we can introduce dialog in our add bill procedure.

## Overview of the solution.
We will create 2 new components:

**BillFormCore**: Contains the form, a callback event to notify about saving the form and also takes a BillItem parameter to fill up the form(In edit mode).

**BillFormDialog**: BillFormDialog component contains the BillFormCore and accepts 2 event call back,
* CloseEventCallback: Notify parrent component when the user clicks on the close button.
* SaveEventCallBack: Notify parent component when the user saves the form.

## Step by step development

* Create a new folder named Components.
* Create another folder inside Components and name it BillFormCore. We are going to keep the form inside this component.
* Create a BillFormCore razor component and corresponding base class.
* Move the code from BillFrom.razor to newly created BillFormCore.razor.
* Remove page directive, as we are not exposing this form as a page.
* Copy the code from BillFromBase to BillFormCoreBase class.
* Remove the code relates to editing.
* Create another folder inside Components, name it Dialogs.
* Create a new razor component named BillFormDialog and a class named BillFormDialogBase.
* Here I have added the bootstrap template dialog template.
* Inside the body I have added the BillFormCore component.
* We need to add a reference to the BillFormCore object. So we have created a property in BillFormdialogBase and add the reference in a component named with ```@ref``` attribute.
* We need to reuse our BillFormCore component in the dialog and for editing the existing bill. For creating a new bill, we need to hide the dialog and in the case of editing bill, we need to display some toaster. We can not access parent level components from the child.
* Because of that we have added EventCallBack property and use this as a parameter of BillFormCore component.
* Add a method named BillFormCore_OnSave inside BillFormDialogBase class. Use this method name as the value of callback.
![BillFormDialog](https://user-images.githubusercontent.com/24603959/79426492-0b2da300-7fe5-11ea-958d-0246ee784e94.JPG)
* This dialog also needs to be placed inside another component. And that component needs to get the update of any changes inside this form. So let's add another event call back parameter named SaveEventCallBack. This callback property will be invoked when the user saves the form(BillFormCore).
![BillFormDialogBase](https://user-images.githubusercontent.com/24603959/79426772-724b5780-7fe5-11ea-8968-1bb99f86005a.JPG)
* Add another call back named CloseEventCallback, when a user closes the dialog it will fire, and parent component hide the dialog.
* Our BillFormCore and BillFormDialog components are ready now. Let's use the BillFormDialog in Bill component.
* Add a button inside the Bills component to open the dialog.
* Add a property named IsShowDialog inside BillsBase class. 
* Based on the value of IsShowDialog we need to display the dialog component.
```
@if (IsShowDialog)
{
    <MonthlyBillScheduler.Server.Components.Dialogs.BillFormDialog @ref="BillFormDialog" 
                                                                   CloseEventCallback="BillFormDialog_OnClose" 
                                                                   SaveEventCallBack="BillFormDialog_OnSave"/>
}
```
* BillFormDialog_OnSave method retrieves the data from BillService and hides the dialog component.
* Now BillFormCore and BillForm having almost duplicated data. We can reuse BillFormCore inside the BillForm component.
![Bill Form](https://user-images.githubusercontent.com/24603959/79428248-b5a6c580-7fe7-11ea-8913-536da1aba46b.JPG)
* As we are now only dealing with update scenario. We can remove the logic relates to adding a new bill from our BillForm base class.