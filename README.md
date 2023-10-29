# Durable Functions Demo

## Project: DurableFunctionApp1 - Ignore this I forgot to remove it from the solution

## Project: DurableFunctionDemo 

The purpose of this function app is to illustrate how you might create a function project that executes one or more functions in a workflow to complete an objective.

Areas of interest. 

- HttpTrigger Function

This function is the initial function to handle a web request and start the orchestration function

- Orchestration Function

This executes each activity function

- Activity Functions

There is an activity for each task. One to save the blob. One to set metadata on the blob. In the future I may add another activity to record information in a relational database.

Other things not related to Azure Functions

## Azure KeyVault

We are using the appsettings.json file to store a reference to an Azure KeyVault secret. The Azure Function will retrieve this and store it as an environment variable.

## Test Console Applications
- .NET Framework Console App
- .NET Core Console App

Both of these console applications use a .NET Standard 2.0 project that calls the azure function. This illustrates how you could build a compatible library that can be used for legacy systems written in .NET Framework 4.8 as well as .NET Core. 

## Traceability Class Library

Ths class library is a .NET Standard 2.0 library in order to be compatible with legacy systems. It also uses Polly for retry support.

