Develop enterprise based web application with asp.net MVC5

This demo project uses code first to develop asp.net MVC 5 web application.
 
Code first allows us to update database based on the change of the business requirement. For example, if we want to add Customer table to the existing database, we create a Customer entity class and a code first configuration file, then we can run update database command to create a new table in database.

Repository factory allows us to create child repository for different entity classes. For exmple, we have a new Customer entity class and have created a customer table in database, now we can create customer repository class from repository factory class based on Solid principle.

Service classes can be created for communicating with the child repository classes. for example, after customer child repository class is created, we can create a customer service class to deploy the CRUD operation from customer child repository class. Customer child repository class can be injected into service classes via DI container

Actions in MVC controllers now can consume service classes to send request and receive response from backend. for examaple, after customer service class is created, we can inject this class interface into MVC controller via Autofac DI container, MVC controller now can interact with backend via service class interfaces.

Based on the MVC controller of customer, we can create Razor views to reflect the presentation this MVC controller required and the user experience. we can create Customer view model to project data into web browser. Data from service classes normally is entity class based. Therefore, we need a Mapper to map the data from entity class to view model class before data is presented in web browser.

Error handling is in application level, in this project, we simply redirect error operation to default view. log process class is developed to log the critical workflow prcess into a physical file such as txt file in server to track the data flow. For example, if we want to monitor the payment workflow from  customer, we need to log all activities this customer has done in our system such as login, make order, make payment, print invoice, and leave time,etc.

This web application is the loose-couple based modern web application that can be used to build enterprise based and high traffic web site. Repository data access layer provides a reliable gateway for services. Service middle tier can be classes library, web APIs, and other microservices so service middle tier can be scaled up easily. We can host the service components in IIS web server to separate it from database backend.

The default Asp.net MVC front end is Razor view, we can enable mobile responsive capability in Razor view. we also can use other front end technologies to talk with MVC controllers via HTTP service or ajax call such as angualar js , knockout js, react js, and html 5 css 3, etc. Therefore, this enterprise based web application can be expanded with multiple front end technologies for different business requirement.

It is excellent web portal we can develop quickly for businesses.


 
     
































