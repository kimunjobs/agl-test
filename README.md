# AGL Exercise
KD 2017-12-14

## Objective

Write well-structured and testable code where each part of the application single-reponsibility principle. 

## Notes

The app is structured into a data-access/repository layer, logic/domain layer and a presentation layer.

### IOC/DI

I used autofac for the IOC container. I use constructor injection exclusively. 

### Tests

Although I'd typically write more individual components tests inadditon to what you see here. Due to time constraints I just showed a different approach of writing an integration test that tests all parts (excepting presentation) of the system.

Note that the tests inject a local json source and do not make an HTTP request. This is to show a common pattern where you need a faster or local simulated or mocked service so that you can exercise all the parts of the system locally (without a cloud resource), or perhaps against a known dataset for regression test purposes.

## Dependencies (nuget)
* Newtonsoft JSON .NET
* Autofac
