# Using Dialog

Currently we communicating between pages. We used one page for edit and add new bill. We can improve user experiences though adding dialog in our application. In edit form we got the user id and any user can directly navigate to a specific bill edit using the url. So we are going to keep edit procedure but we can introduce dialog in our add bill procedure.

* Create new folder named Components.
* Create another folder inside Components and name it BillFormCore. We are going to keep the form inside this component.
* Create a BillFormCore razor component and crosponding base class.
* Move the code from BillFrom.razor to newly created BillFormCore.razor.
* Remove page directive, as we are not exposing this form as a page.
* Copy the code from BillFromBase to BillFormCoreBase class.
* Remove the code relates to edit.
* Create another folder inside Components, name it Dialogs.
* Create a new razor component named BillFormDialog and a class named BillFormDialogBase.
* Here I have added the bootstrap template dialog template.
* Inside the body I have added the BillFormCore component.
* We need to add a reference of BillFormCore object. So we have created a property in BillFormdialogBase and add the reference in component named with ```@ref``` attribute.
* We need to reuse our BillFormCore component in dialog and for editing existing bill. For creating new bill, we need to hide the dialog and in the case of editing bill we need to display some toaster. We can not access parent level components from the child.
* Because of that we have added EventCallBack property and use this as a parameter of BillFormCore component.
* Add a method named BillFormCore_OnSave inside BillFormDialogBase class. Use this method name as the value of callback.
![BillFormDialog](https://user-images.githubusercontent.com/24603959/79426492-0b2da300-7fe5-11ea-958d-0246ee784e94.JPG)
* This dialog also need to be placed inside another component. And that component need to get the update of any changes inside this form. So let's add another event call back parametre named SaveEventCallBack. This call back property will be invoked when user save the form(BillFormCore).
![BillFormDialogBase](https://user-images.githubusercontent.com/24603959/79426772-724b5780-7fe5-11ea-8968-1bb99f86005a.JPG)
* Add another call back named CloseEventCallback, when a user close the dialog it will fire, and parent component hide the dialog.
* Our BillFormCore and BillFormDialog components are ready now. Lets use the BillFormDialog in Bill component.
* Add a button inside Bills component to open the dialog.
* Add a property named IsShowDialog inside BillsBase class. 
* Based on the value of IsShowDialog we need to display the dialog component.
```@if (IsShowDialog)
{
    <MonthlyBillScheduler.Server.Components.Dialogs.BillFormDialog @ref="BillFormDialog" 
                                                                   CloseEventCallback="BillFormDialog_OnClose" 
                                                                   SaveEventCallBack="BillFormDialog_OnSave"/>
}
```
* BillFormDialog_OnSave method retrive the data from BillService and hide the dialog component.
