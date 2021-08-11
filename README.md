# AzureC-function_retry_sample</br>
To run this function locally you will need to have azure cli and azure functions cli</br>
<b>func start</b> command will start the function locally</br></br> 

below commands will build and push container to ACR</br> 
docker build --no-cache --tag [acrname].azurecr.io/azurefunctionsimage:retryenbld . </br>
docker push <acrname>.azurecr.io/azurefunctionsimage:v1.0.0 </br></br>

By downloading below library you will be able to use  retry hint with the function [FixedDelayRetry(5, "00:00:05")] </br>

dotnet add package Microsoft.Azure.WebJobs --version 3.0.27  </br>

After hooking up the uploaded image from ACR by the application you will be able to reach it by following links </br></br>

https://[appname].azurewebsites.net/api/throwsexeption?name=0 will cause error and retry  </br>  
https://[appname].azurewebsites.net/api/throwsexeption?name=10 will execute succesfull </br>

Documentation used - https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-function-linux-custom-image?tabs=bash%2Cportal&pivots=programming-language-csharp
