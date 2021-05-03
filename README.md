# Back-end Interview Challenge Overview

This github repository is setup as a starting point for candidates to display their knowledge of
C# and their ability to leverage this technology to craft API endpoints.

Candidate is encouraged to go into detail with explanations about the why, how, and what
in regards to the steps they're taking (or would take if given more time) when completing this
task.

There might not be a significant amount of time to complete every potential challenge that
arises, and that's fine. The goal is to be able to see the candidates thought process and 
general knowledge while working through the issues presented in this project.


## Details

This repository has a basic setup for HTTP requests, including a GET by Id, GET all, and POST method.

The loads.json file has the mock data that you'll be using to perform the GETs and POST.

Testing of endpoints can be done through built the in Swagger UI.

Please ask any questions as they arise.

Good luck!

## Prerequisites
1. Install [Visual Studio 2019 16.8 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) if using Windows 10 or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac) if using Mac OS.
   * You can also install [Visual Studio Code](https://code.visualstudio.com/download) in either OS if you prefer to use that instead. Just make sure you have the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed as well.

2. Install [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/5.0)

## Starting the Rest API Project
1. Press Ctrl+F5 (Windows) or Control+F5 (Mac) in Visual Studio or Visual Studio Code. If using Visual Studio for Mac, Select **Run > Start Debugging**.

2. Navigate to `https://localhost:<port>/swagger`, where `<port>` is a randomly chosen port number.

3. Run the `/api/Seed` GET endpoint to populate the in-memory database from the loads.json file.
